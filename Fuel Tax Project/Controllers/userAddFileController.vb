Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI.WebControls
Imports System.IO

Namespace Fuel_Tax_Project
    Public Class userAddFileController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        Function Index() As ActionResult

            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "DMV Statistical Reports", .Value = "DMV"})
            List.Add(New SelectListItem With {.Text = "FHWA 551M Reports", .Value = "FHWA"})

            Dim MonthsList As New List(Of SelectListItem)
            MonthsList.Add(New SelectListItem With {.Text = "January", .Value = "January", .Selected = True})
            MonthsList.Add(New SelectListItem With {.Text = "February", .Value = "February"})
            MonthsList.Add(New SelectListItem With {.Text = "March", .Value = "March"})
            MonthsList.Add(New SelectListItem With {.Text = "April", .Value = "April"})
            MonthsList.Add(New SelectListItem With {.Text = "May", .Value = "May"})
            MonthsList.Add(New SelectListItem With {.Text = "June", .Value = "June"})
            MonthsList.Add(New SelectListItem With {.Text = "July", .Value = "July"})
            MonthsList.Add(New SelectListItem With {.Text = "August", .Value = "August"})
            MonthsList.Add(New SelectListItem With {.Text = "September", .Value = "September"})
            MonthsList.Add(New SelectListItem With {.Text = "October", .Value = "October"})
            MonthsList.Add(New SelectListItem With {.Text = "November", .Value = "November"})
            MonthsList.Add(New SelectListItem With {.Text = "December", .Value = "December"})

            Dim YearList As New List(Of SelectListItem)

            For m As Integer = 1998 To 2020
                If m = 2014 Then
                    YearList.Add(New SelectListItem With {.Text = m, .Value = m, .Selected = True})
                Else
                    YearList.Add(New SelectListItem With {.Text = m, .Value = m})
                End If
            Next

            ViewData("MonthsPicker") = MonthsList
            ViewData("YearsPicker") = YearList
            ViewData("ReportPicker") = List

            Return View()

        End Function


        'ContentUpload controller, ContentUpload action, Post
        <AcceptVerbs(HttpVerbs.Post)>
        Function ContentUpload_Post(ed1 As FileData) As ActionResult

            Dim year As Integer = ed1.years
            Dim report As String = ed1.report
            Dim month As String = ed1.months

            'Get the file by name tag, not the id tag
            Dim pf As HttpPostedFileBase = Request.Files("ExcelFile")
            Dim errMsg As String = "File was uploaded successfully to the database."
            Dim filename As String = Path.GetFileName(pf.FileName)

            'could add code here to check if last 4 letters are excel file
            If filename = "" Then
                errMsg = "Error. No file selected. Please try again."
            Else

                Dim tempPath As String = "~/Reports/" & report & "/" & year & "/" & month & "/"

                ' store the file inside ~/images/User-Image folder          
                Dim path_1 = Path.Combine(Server.MapPath(tempPath), filename)
                ' this is the string you have to save in your DB
                Dim filepathToSave As String = "Reports/" & Convert.ToString(filename)

                'if the directory doesn't exist, create it first and then save file, else will give an error
                If Not Directory.Exists(Server.MapPath(tempPath)) Then
                    Directory.CreateDirectory(Server.MapPath(tempPath))
                End If
                'save file to server
                pf.SaveAs(path_1)

            End If
            '--------------------------------------------
            ' you can get more information about the upload file use HttpPostedFileBase method. 
            ' Add Code here to save file path in DB -> filepathToSave
            '----------------------------------------------
            ViewData("err") = errMsg

            Return View()
        End Function


        Function GetFile(down As FileData) As ActionResult

            'file download code
            Dim filename As String = down.fName
            Response.ContentType = "application/octet-stream"
            Response.AppendHeader("Content-Disposition", "attachment; filename=""" & filename & """")
            'Dim aaa As String = Server.MapPath("~/Reports/" & report & "/" & year & "/" & month & "/" & filename)
            Response.TransmitFile(Server.MapPath("~/Reports/" & filename))
            Response.[End]()


            Return View()
        End Function




    End Class
End Namespace
