Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security

<Authorize>
Public Class AccountController
    Inherits Controller
    Public Sub New()
        IdentityManager = New AuthenticationIdentityManager(New IdentityStore())
    End Sub

    Public Sub New(manager As AuthenticationIdentityManager)
        IdentityManager = manager
    End Sub

    Public Property IdentityManager As AuthenticationIdentityManager

    Private ReadOnly Property AuthenticationManager() As Microsoft.Owin.Security.IAuthenticationManager
        Get
            Return HttpContext.GetOwinContext().Authentication
        End Get
    End Property

    '
    ' GET: /Account/Login
    <AllowAnonymous>
    Public Function Login(returnUrl As String) As ActionResult
        ViewBag.ReturnUrl = returnUrl
        Return View()
    End Function

    '
    ' POST: /Account/Login
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function Login(model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)
        If ModelState.IsValid Then
            ' Validate the password
            Dim result As IdentityResult = Await IdentityManager.Authentication.CheckPasswordAndSignInAsync(AuthenticationManager, model.UserName, model.Password, model.RememberMe)
            If result.Success Then
                Return RedirectToLocal(returnUrl)
            Else
                AddErrors(result)
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' GET: /Account/Register
    <AllowAnonymous>
    Public Function Register() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Account/Register
    <AllowAnonymous>
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Register(model As RegisterViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            ' Create a local login before signing in the user
            Dim user = New User(model.UserName)
            Dim result = Await IdentityManager.Users.CreateLocalUserAsync(user, model.Password)
            If result.Success Then
                Await IdentityManager.Authentication.SignInAsync(AuthenticationManager, user.Id, isPersistent:=False)
                Return RedirectToAction("Index", "Home")
            Else
                AddErrors(result)
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' POST: /Account/Disassociate
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Disassociate(loginProvider As String, providerKey As String) As Task(Of ActionResult)
        Dim message As String = Nothing
        Dim result As IdentityResult = Await IdentityManager.Logins.RemoveLoginAsync(User.Identity.GetUserId(), loginProvider, providerKey)
        If result.Success Then
            message = "The external login was removed."
        Else
            message = result.Errors.FirstOrDefault()
        End If

        Return RedirectToAction("Manage", New With {
            .Message = message
        })
    End Function

    '
    ' GET: /Account/Manage
    Public Async Function Manage(message As String) As Task(Of ActionResult)
        ViewBag.StatusMessage = If(message, "")
        ViewBag.HasLocalPassword = Await IdentityManager.Logins.HasLocalLoginAsync(User.Identity.GetUserId())
        ViewBag.ReturnUrl = Url.Action("Manage")
        Return View()
    End Function

    '
    ' POST: /Account/Manage
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Manage(model As ManageUserViewModel) As Task(Of ActionResult)
        Dim userId As String = User.Identity.GetUserId()
        Dim hasLocalLogin As Boolean = Await IdentityManager.Logins.HasLocalLoginAsync(userId)
        ViewBag.HasLocalPassword = hasLocalLogin
        ViewBag.ReturnUrl = Url.Action("Manage")
        If hasLocalLogin Then
            If ModelState.IsValid Then
                Dim result As IdentityResult = Await IdentityManager.Passwords.ChangePasswordAsync(User.Identity.GetUserName(), model.OldPassword, model.NewPassword)
                If result.Success Then
                    Return RedirectToAction("Manage", New With {
                        .Message = "Your password has been changed."
                    })
                Else
                    AddErrors(result)
                End If
            End If
        Else
            ' User does not have a local password so remove any validation errors caused by a missing OldPassword field
            Dim state As ModelState = ModelState("OldPassword")
            If state IsNot Nothing Then
                state.Errors.Clear()
            End If

            If ModelState.IsValid Then
                ' Create the local login info and link it to the user
                Dim result As IdentityResult = Await IdentityManager.Logins.AddLocalLoginAsync(userId, User.Identity.GetUserName(), model.NewPassword)
                If result.Success Then
                    Return RedirectToAction("Manage", New With {
                        .Message = "Your password has been set."
                    })
                Else
                    AddErrors(result)
                End If
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '
    ' POST: /Account/ExternalLogin
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Function ExternalLogin(provider As String, returnUrl As String) As ActionResult
        ' Request a redirect to the external login provider
        Return New ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", New With {
            .loginProvider = provider,
            .ReturnUrl = returnUrl
        }))
    End Function

    '
    ' GET: /Account/ExternalLoginCallback
    <AllowAnonymous>
    Public Async Function ExternalLoginCallback(loginProvider As String, returnUrl As String) As Task(Of ActionResult)
        Dim id As ClaimsIdentity = Await IdentityManager.Authentication.GetExternalIdentityAsync(AuthenticationManager)
        ' Sign in this external identity if its already linked
        Dim result As IdentityResult = Await IdentityManager.Authentication.SignInExternalIdentityAsync(AuthenticationManager, id)
        If result.Success Then
            Return RedirectToLocal(returnUrl)
        ElseIf User.Identity.IsAuthenticated Then
            ' Try to link if the user is already signed in
            result = Await IdentityManager.Authentication.LinkExternalIdentityAsync(id, User.Identity.GetUserId())
            If result.Success Then
                Return RedirectToLocal(returnUrl)
            Else
                Return View("ExternalLoginFailure")
            End If
        Else
            ' Otherwise prompt to create a local user
            ViewBag.ReturnUrl = returnUrl
            ViewBag.LoginProvider = loginProvider
            Return View("ExternalLoginConfirmation", New ExternalLoginConfirmationViewModel() With {
                .UserName = id.Name
            })
        End If
    End Function

    '
    ' POST: /Account/ExternalLoginConfirmation
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function ExternalLoginConfirmation(model As ExternalLoginConfirmationViewModel, returnUrl As String) As Task(Of ActionResult)
        If User.Identity.IsAuthenticated Then
            Return RedirectToAction("Manage")
        End If

        If ModelState.IsValid Then
            ' Get the information about the user from the external login provider
            Dim result As IdentityResult = Await IdentityManager.Authentication.CreateAndSignInExternalUserAsync(AuthenticationManager, New User(model.UserName))
            If result.Success Then
                Return RedirectToLocal(returnUrl)
            Else
                AddErrors(result)
            End If
        End If

        ViewBag.ReturnUrl = returnUrl
        Return View(model)
    End Function

    '
    ' POST: /Account/LogOff
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function LogOff() As ActionResult
        AuthenticationManager.SignOut()
        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/ExternalLoginFailure
    <AllowAnonymous>
    Public Function ExternalLoginFailure() As ActionResult
        Return View()
    End Function

    <AllowAnonymous>
    <ChildActionOnly>
    Public Function ExternalLoginsList(returnUrl As String) As ActionResult
        ViewBag.ReturnUrl = returnUrl
        Return DirectCast(PartialView("_ExternalLoginsListPartial", New List(Of AuthenticationDescription)(AuthenticationManager.GetExternalAuthenticationTypes())), ActionResult)
    End Function

    <ChildActionOnly>
    Public Function RemoveAccountList() As ActionResult
        Return Task.Run(Async Function()
                            Dim linkedAccounts = New List(Of IUserLogin)(Await IdentityManager.Logins.GetLoginsAsync(User.Identity.GetUserId()))
                            ViewBag.ShowRemoveButton = linkedAccounts.Count > 1
                            Return DirectCast(PartialView("_RemoveAccountPartial", linkedAccounts), ActionResult)
                        End Function).Result
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso IdentityManager IsNot Nothing Then
            IdentityManager.Dispose()
            IdentityManager = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Helpers"
    Private Sub AddErrors(result As IdentityResult)
        For Each [error] As String In result.Errors
            ModelState.AddModelError("", [error])
        Next
    End Sub

    Private Function RedirectToLocal(returnUrl As String) As ActionResult
        If Url.IsLocalUrl(returnUrl) Then
            Return Redirect(returnUrl)
        Else
            Return RedirectToAction("Index", "Home")
        End If
    End Function

    Private Class ChallengeResult
        Inherits HttpUnauthorizedResult
        Public Sub New(provider As String, redirectUrl As String)
            Me.LoginProvider = provider
            Me.RedirectUrl = redirectUrl
        End Sub

        Public Property LoginProvider As String
        Public Property RedirectUrl As String

        Public Overrides Sub ExecuteResult(context As ControllerContext)
            context.HttpContext.GetOwinContext().Authentication.Challenge(New AuthenticationProperties() With {
                .RedirectUrl = RedirectUrl
            }, LoginProvider)
        End Sub
    End Class
#End Region
End Class
