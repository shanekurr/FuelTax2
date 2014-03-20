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
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel
Imports System.Reflection

Namespace Fuel_Tax_Project
    '<Authorize>
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

        '<Authorize>
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

            Dim tempPath As String = "~/Reports/" & report & "/" & year & "/" & month & "/"

            ' store the file inside       
            Dim path_1 = Path.Combine(Server.MapPath(tempPath), filename)
            ' this is the string you have to save in your DB
            Dim filepathToSave As String = "Reports/" & Convert.ToString(filename)

            'could add code here to check if last 4 letters are excel file
            If filename = "" Then
                errMsg = "Error. No file selected. Please try again."
            Else




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

            'Here is where the upload to tables will be.
            Try
                'open the DMV file and read data
                '###################################
                If report = "DMV" Then

                    Dim DMVApp As Excel.Application
                    Dim DMVwb As Workbook
                    Dim DMVws As Worksheet
                    DMVApp = New Excel.Application
                    DMVwb = DMVApp.Workbooks.Open(path_1)
                    DMVws = DMVwb.Worksheets(1)

                    Dim DMVusedRange = DMVws.UsedRange()
                    Dim DMVusedRangeAs2DArray As Object(,) = DMVusedRange.Value2
                    DMVwb.Save()
                    DMVwb.Close()
                    DMVApp.Quit()
                    'Marshal.ReleaseComObject(Application)

                    'create integer variables to parse excel sheet
                    Dim startCell As Integer = 0
                    Dim endCell As Integer = 0


                    'create new queries to insert new data
                    '###################################

                    ' Remove old data from the tables before inserting updated data
                    Dim removeOldData = From o In db.taxcolmoney2 _
                                        Where o.year = year AndAlso o.month = month _
                                        Select o
                    Dim removeOldData2 = From o In db.taxcollgalls _
                                        Where o.year = year AndAlso o.month = month _
                                        Select o
                    Dim removeOldData3 = From o In db.gasolinegbycous _
                                        Where o.year = year AndAlso o.month = month _
                                        Select o

                    Dim List2 As New List(Of SelectListItem)

                    ' test loop to ensure data is removed
                    For Each k In removeOldData
                        List2.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
                    Next

                    'delete from taxcolmoney2
                    For Each l In removeOldData
                        db.taxcolmoney2.Remove(l)
                        db.SaveChanges()

                    Next

                    'delete from taxcolgalls
                    For Each l In removeOldData2
                        db.taxcollgalls.Remove(l)
                        db.SaveChanges()

                    Next

                    'delete from gasolinebycous
                    For Each l In removeOldData3
                        db.gasolinegbycous.Remove(l)
                        db.SaveChanges()

                    Next

                    'submit the changes to the database

                    Dim List As New List(Of SelectListItem)

                    ' test loop to ensure data is removed
                    For Each k In removeOldData
                        List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
                    Next

                    ViewData("testList") = List
                    ViewData("testListBefore") = List2


                    ' Insert new data into each table
                    If year >= 2006 Then
                        'set sheet to tab 8 (maybe 7 depending on PHP starting point)
                    End If

                    If year = 2005 AndAlso month = "August" Then
                        'use tab three to upload data


                    Else
                        'use tab 4 to upload data


                    End If

                    If year = 2004 Or (year = 2005 AndAlso month = "January" Or month = "February" Or month = "March" Or month = "April" Or month = "May" Or month = "June") Then
                        ' start at 10
                        ' end at 26

                    ElseIf year = 2005 AndAlso (month = "July" Or month = "August" Or month = "September" Or month = "October") Then
                        ' start at 2
                        ' end at 18

                    End If

                    ' start the insert statement
                    For m As Integer = startCell To endCell


                        'db.taxcollgalls.Add()

                    Next
                    ' finish the if statement for 2011 and 2010 and ensure Jan and Feb are not inlcuded if the year is 2010
                    If year >= 2011 Or (year = 2010 AndAlso month IsNot "January" AndAlso month IsNot "February") Then
                        ' start at 12
                        ' end at 28

                    End If

                End If


                'submit changes to the database
                db.SaveChanges()


                GC.Collect()


            Catch e As System.Exception
                errMsg = "Something went bad. Try again"
            End Try

            'end the uploading to tables function
            ViewData("err") = errMsg

            Return View()
        End Function

        '<Authorize>
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
