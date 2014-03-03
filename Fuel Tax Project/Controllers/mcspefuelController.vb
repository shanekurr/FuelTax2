Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    <Authorize>
    Public Class mcspefuelController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /mcspefuel/
        Function Index() As ActionResult
            Return View(db.mcspefuels.ToList())
        End Function

        ' GET: /mcspefuel/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mcspefuel As mcspefuel = db.mcspefuels.Find(id)
            If IsNothing(mcspefuel) Then
                Return HttpNotFound()
            End If
            Return View(mcspefuel)
        End Function

        ' GET: /mcspefuel/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /mcspefuel/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,amount")> ByVal mcspefuel As mcspefuel) As ActionResult
            If ModelState.IsValid Then
                db.mcspefuels.Add(mcspefuel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(mcspefuel)
        End Function

        ' GET: /mcspefuel/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mcspefuel As mcspefuel = db.mcspefuels.Find(id)
            If IsNothing(mcspefuel) Then
                Return HttpNotFound()
            End If
            Return View(mcspefuel)
        End Function

        ' POST: /mcspefuel/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,amount")> ByVal mcspefuel As mcspefuel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(mcspefuel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(mcspefuel)
        End Function

        ' GET: /mcspefuel/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mcspefuel As mcspefuel = db.mcspefuels.Find(id)
            If IsNothing(mcspefuel) Then
                Return HttpNotFound()
            End If
            Return View(mcspefuel)
        End Function

        ' POST: /mcspefuel/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim mcspefuel As mcspefuel = db.mcspefuels.Find(id)
            db.mcspefuels.Remove(mcspefuel)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
