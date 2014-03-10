Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.IO


Namespace Fuel_Tax_Project
    Public Class userHistoricalController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /Historical/
               Function Index() As ActionResult


            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "DMV Statistical Reports", .Value = "DMV"})
            List.Add(New SelectListItem With {.Text = "FHWA 551M Reports", .Value = "FHWA"})


            Dim MonthsList As New List(Of SelectListItem)
            MonthsList.Add(New SelectListItem With {.Text = "All", .Value = "", .Selected = True})
            MonthsList.Add(New SelectListItem With {.Text = "January", .Value = "January"})
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

        ' GET: /Historical/Delete/5
        Function Download(ed1 As FileData) As ActionResult

            Dim radio As Integer = ed1.radio '1 - final report; 2-source data for FHWA
            Dim year As Integer = ed1.years
            Dim report As String = ed1.report
            Dim month As String = ed1.months
            Dim filePaths() As String = {""}
            Dim files As New List(Of FileData)
            Dim msg As String = ""

            'get source files for FHWA reports
            If radio = 2 And report = "FHWA" Then
                report = "Source"
            End If

            If Directory.Exists(Server.MapPath("~/Reports/" & report & "/" & year & "/" & month & "/")) Then
                filePaths = Directory.GetFiles(Server.MapPath("~/Reports/" & report & "/" & year & "/" & month & "/"))

                For Each fpath As String In filePaths
                    files.Add(New FileData With {.fName = Path.GetFileName(fpath), .FilePath = fpath, .months = month, .years = year, .report = report})
                Next

                If filePaths.Length = 0 And month <> "" Then
                    msg = "There are no reports for the selected period. Please try again with different dates."
                ElseIf month = "" Then
                    'code to get all months reports for the selected year
                    Dim mon() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
                    For Each value As String In mon
                        If Directory.Exists(Server.MapPath("~/Reports/" & report & "/" & year & "/" & value & "/")) Then
                            filePaths = Directory.GetFiles(Server.MapPath("~/Reports/" & report & "/" & year & "/" & value & "/"))

                            For Each fpath As String In filePaths
                                files.Add(New FileData With {.fName = Path.GetFileName(fpath), .FilePath = fpath, .months = value, .years = year, .report = report})
                            Next
                        Else
                            'skip to next item
                        End If
                    Next
                End If
                If files.Count = 0 Then
                    msg = "There are no reports for the selected period. Please try again with different dates."
                End If
            Else
                msg = "There are no reports for the selected period. Please try again with different dates."

            End If

            ViewData("msg") = msg
            ViewData("files") = files
            Return View(files)

        End Function



        Function GetFile(down As FileData) As ActionResult

            Dim finalPath As String = down.FilePath
            Dim fname As String = down.fName

            Dim year As Integer = down.years
            Dim report As String = down.report
            Dim month As String = down.months

            'file download code
            Dim filename As String = fname
            Response.ContentType = "application/octet-stream"
            Response.AppendHeader("Content-Disposition", "attachment; filename=""" & filename & """")
            'Dim aaa As String = Server.MapPath("~/Reports/" & report & "/" & year & "/" & month & "/" & filename)
            Response.TransmitFile(Server.MapPath("~/Reports/" & report & "/" & year & "/" & month & "/" & filename))
            Response.[End]()


            Return View()
        End Function

    End Class
End Namespace
