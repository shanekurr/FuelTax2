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
    <Authorize>
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

            For m As Integer = 1998 To 2025
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
            Dim count As Integer = 0 ' use this count to increment through county array

            'Get the file by name tag, not the id tag
            Dim pf As HttpPostedFileBase = Request.Files("ExcelFile")
            Dim errMsg As String = "File was uploaded successfully to the database."
            Dim filename As String = Path.GetFileName(pf.FileName)
            Dim path_1 As String = Nothing

            Dim tempPath As String = "~/Reports/" & report & "/" & year & "/" & month & "/"

            ' store the file inside       
            path_1 = Path.Combine(Server.MapPath(tempPath), filename)
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
            'Try
            'open the DMV file and read data
            '###################################
            If report = "DMV" Then

                Dim DMVApp As Excel.Application
                Dim DMVwb As Workbook
                Dim tab9, tab4, tab5, tab17 As Worksheet

                DMVApp = New Excel.Application
                DMVwb = DMVApp.Workbooks.Open(path_1)


                ' loads data from tab 9 (Total Tax Collected) into 2d array 
                tab9 = DMVwb.Worksheets(9)
                Dim tab9usedRange = tab9.UsedRange()
                Dim tab9Array As Object(,) = tab9usedRange.Value2

                ' loads data from tab 4 into 2d array
                tab4 = DMVwb.Worksheets(4)
                Dim tab4usedRange = tab4.UsedRange()
                ' Dim tab4Array As Object(,) = tab4usedRange.Value2

                ' loads data from tab 5 into 2d array
                tab5 = DMVwb.Worksheets(5)
                Dim tab5usedRange = tab5.UsedRange()
                'Dim tab5Array As Object(,) = tab5usedRange.Value2

                tab17 = DMVwb.Worksheets(17)
                Dim tab17usedRange = tab5.UsedRange()
                'Dim tab17Array As Object(,) = tab17usedRange.Value2

                Dim currentTab As Object(,)

                'Create an array of counties. Not sure why. Need to ask the people that built the prototype
                Dim countyArray As String() = {"Carson City", "Churchill", "County Total", "Clark", "County Total", "Douglas", "Elko", "County Total", "Esmeralda", "Eureka", "Humboldt", "County Total", "Lincoln", "County Total", "Lyon", "County Total", "Mineral", "Nye", "County Total", "Pershing", "County Total", "Storey", "Washoe", "County Total", "White Pine", "County Total"}


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

                    'submit the changes to the database
                    db.SaveChanges()

                Next

                'delete from taxcolgalls
                For Each l In removeOldData2
                    db.taxcollgalls.Remove(l)

                    'submit the changes to the database
                    db.SaveChanges()

                Next

                'delete from gasolinebycous
                For Each l In removeOldData3
                    db.gasolinegbycous.Remove(l)

                    'submit the changes to the database
                    db.SaveChanges()

                Next

                '################### TEST REMOVE BEFORE PRODUCTION ########################
                Dim List As New List(Of SelectListItem)
                ' test loop to ensure data is removed
                For Each k In removeOldData
                    List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
                Next

                ViewData("testList") = List
                ViewData("testListBefore") = List2
                '##########################################################################

                ' Insert new data into each table
                If year >= 2006 Then

                    ' create temp object to store values
                    Dim tempTable As New taxcolmoney2()

                    'set sheet to tab 9 

                    startCell = 13
                    endCell = 79

                    For l As Integer = startCell To endCell

                        'compare the strings in the excel sheet to the columns in the table 
                        tempTable.CountyN = tab9Array(l, 1)

                        'String.Compare(string a, string b, boolean ignoreCase)
                        If (String.Compare(countyArray(count), tempTable.CountyN, True)) Then

                            'grab each cell and set variable to the corresponding column in the table
                            tempTable.AmountD = tab9Array(l, 8)
                            tempTable.month = month
                            tempTable.year = year

                            db.taxcolmoney2.Add(tempTable)
                            db.SaveChanges()
                            ' you may have to only save changes at the end of the function. But to be safe, go ahead and save every chance you get.
                        End If
                    Next
                    'insert into taxcollgal year month CountyN AmountD

                End If

                If year = 2005 AndAlso month = "August" Then
                    'use tab three to upload data
                    currentTab = tab4usedRange.Value2

                Else
                    'use tab 4 to upload data
                    currentTab = tab5usedRange.Value2

                End If

                If year = 2004 Or (year = 2005 AndAlso month = "January" Or month = "February" Or month = "March" Or month = "April" Or month = "May" Or month = "June") Then
                    startCell = 10
                    endCell = 26

                ElseIf year = 2005 AndAlso (month = "July" Or month = "August" Or month = "September" Or month = "October") Then

                    startCell = 2
                    endCell = 18

                Else
                    startCell = 12
                    endCell = 28

                End If

                Dim tempGasolineByCounty = New gasolinegbycou()

                ' start the insert statement
                For m As Integer = startCell To endCell

                    tempGasolineByCounty.CountyN = currentTab(1, m)
                    tempGasolineByCounty.Gallon = currentTab(2, m)
                    tempGasolineByCounty.perTotal = currentTab(3, m)
                    tempGasolineByCounty.month = month
                    tempGasolineByCounty.year = year

                    'insert values into table
                    db.gasolinegbycous.Add(tempGasolineByCounty)
                    db.SaveChanges()


                Next
                ' finish the if statement for 2011 and 2010 and ensure Jan and Feb are not inlcuded if the year is 2010
                If year >= 2011 Or (year = 2010 AndAlso month IsNot "January" AndAlso month IsNot "February") Then

                    Dim tempTaxCollGall As New taxcollgall()
                    currentTab = tab17usedRange.Value2
                    startCell = 12
                    endCell = 28
                    For m As Integer = startCell To endCell

                        tempTaxCollGall.CountyN = currentTab(m, 1)
                        tempTaxCollGall.Diesel = currentTab(m, 2)
                        tempTaxCollGall.LPG = currentTab(m, 3)
                        tempTaxCollGall.A55 = currentTab(m, 4)
                        tempTaxCollGall.month = month
                        tempTaxCollGall.year = year

                        db.taxcollgalls.Add(tempTaxCollGall)
                        db.SaveChanges()

                    Next

                End If

            End If


            'submit changes to the database
            db.SaveChanges()


            GC.Collect()


            'Catch e As System.Exception
            'errMsg = "Something went bad. Try again"
            'End Try

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
