Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI.Page
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace Fuel_Tax_Project
    '<Authorize>
    Public Class userCreateReportController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        'Private Property Missing As Object

        ' GET: /CreateReport/
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

            'get and set variables
            Dim year As Integer = ed1.years
            Dim month As String = ed1.months


            Dim m, mg, mg2 As Integer
            m = 0
            Dim begin As String = Nothing
            Dim finish As String = Nothing
            Select Case month
                Case "July"
                    m = 12
                    mg = 15
                    mg2 = 8
                    begin = "7/1/" & year
                    finish = "7/31/" & year
                Case "August"
                    m = 13
                    mg = 16
                    mg2 = 9
                    begin = "8/1/" & year
                    finish = "8/31/" & year
                Case "September"
                    m = 14
                    mg = 17
                    mg2 = 10
                    begin = "9/1/" & year
                    finish = "9/31/" & year
                Case "October"
                    m = 15
                    mg = 18
                    mg2 = 11
                    begin = "10/1/" & year
                    finish = "10/31/" & year
                Case "July"
                    m = 12
                    mg = 15
                    mg2 = 8
                    begin = "7/1/" & year
                    finish = "7/31/" & year
                Case "November"
                    m = 16
                    mg = 19
                    mg2 = 12
                    begin = "11/1/" & year
                    finish = "11/31/" & year
                Case "December"
                    m = 17
                    mg = 20
                    mg2 = 13
                    begin = "12/1/" & year
                    finish = "12/31/" & year
                Case "January"
                    m = 18
                    mg = 9
                    mg2 = 2
                    begin = "1/1/" & year
                    finish = "1/31/" & year
                Case "February"
                    m = 19
                    mg = 10
                    mg2 = 3
                    begin = "2/1/" & year
                    finish = "2/31/" & year
                Case "March"
                    m = 20
                    mg = 11
                    mg2 = 4
                    begin = "3/1/" & year
                    finish = "3/31/" & year
                Case "April"
                    m = 21
                    mg = 12
                    mg2 = 5
                    begin = "4/1/" & year
                    finish = "4/31/" & year
                Case "May"
                    m = 22
                    mg = 13
                    mg2 = 6
                    begin = "5/1/" & year
                    finish = "5/31/" & year
                Case "June"
                    m = 23
                    mg = 14
                    mg2 = 7
                    begin = "6/1/" & year
                    finish = "6/31/" & year
            End Select

            'adjust for offset due to converting sheet to a data array
            mg2 = mg2 + 1
            mg = mg - 3
            ' m = m +- ??

            'Get the file by name tag, not the id tag
            Dim pf As HttpPostedFileBase = Request.Files("ExcelFile")
            Dim pf2 As HttpPostedFileBase = Request.Files("ExcelFile2")
            Dim errMsg As String = "Report Created Successfully."
            Dim filename As String = Path.GetFileName(pf.FileName) 'Fuel Tax 
            Dim filename2 As String = Path.GetFileName(pf2.FileName) 'gasgal
            Dim path_1 As String = Nothing
            Dim path_2 As String = Nothing
            Dim errMsg1 As String = Nothing
            'could add code here to check if files are excel !!
            If filename = "" Or filename2 = "" Then
                errMsg1 = " No file selected."
            Else

                Dim tempPath As String = "~/Reports/" & "NewReport/" & year & "/" & month & "/"

                ' store the file inside ~/Reports/Newreport         
                path_1 = Path.Combine(Server.MapPath(tempPath), filename)
                path_2 = Path.Combine(Server.MapPath(tempPath), filename2)
                ' this is the string you have to save in your DB
                'Dim filepathToSave As String = "Reports/" & Convert.ToString(filename)

                'if the directory doesn't exist, create it first and then save file, else will give an error
                If Not Directory.Exists(Server.MapPath(tempPath)) Then
                    Directory.CreateDirectory(Server.MapPath(tempPath))
                End If
                'save file to server
                pf.SaveAs(path_1)
                pf2.SaveAs(path_2)

                'create new excel file
            End If


            Try
                'open the Fiscal Year file and read data
                Dim fisApp As Excel.Application
                Dim fiswb As Workbook
                Dim LPGfisws, Dieselfisws As Worksheet
                fisApp = New Excel.Application
                fiswb = fisApp.Workbooks.Open(path_1)
                LPGfisws = fiswb.Worksheets(3) 'sets worksheet to LPG 
                Dieselfisws = fiswb.Worksheets(4) 'sets worksheet to Diesel

                Dim fisusedRange3 = LPGfisws.UsedRange()  ' 3 - for worksheet 3 - LPG
                Dim fisusedRange4 = Dieselfisws.UsedRange()  ' 4 - for worksheet 4 - Diesel
                Dim LPGArray As Object(,) = fisusedRange3.Value2
                Dim DieselArray As Object(,) = fisusedRange4.Value2

                fiswb.Save()
                fiswb.Close()
                fisApp.Quit()
                Marshal.ReleaseComObject(fiswb)
                Marshal.ReleaseComObject(fisApp)
                GC.Collect()

                'open the Gasgal file and read data
                Dim gasApp As Excel.Application
                Dim gaswb As Workbook
                Dim gasws As Worksheet
                gasApp = New Excel.Application
                gaswb = gasApp.Workbooks.Open(path_2)
                gasws = gaswb.Worksheets(1)

                Dim gasusedRange = gasws.UsedRange
                Dim GasArray As Object(,) = gasusedRange.Value2
                gaswb.Save()
                gaswb.Close()
                gasApp.Quit()
                Marshal.ReleaseComObject(gaswb)
                Marshal.ReleaseComObject(gasApp)
                GC.Collect()



                'create new excel workbook and fill in the data
                Dim oXL As Excel.Application
                Dim oWB As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                Dim oRng As Excel.Range

                ' Start Excel and get Application object.
                oXL = CreateObject("Excel.Application")
                ' set to false to disable user interaction
                oXL.Visible = False
                oXL.UserControl = False
                oXL.DisplayAlerts = False

                ' Get a new workbook.
                oWB = oXL.Workbooks.Add
                oSheet = oWB.ActiveSheet

                'set column width
                oSheet.Range("B1").ColumnWidth = 20
                oSheet.Range("D1").ColumnWidth = 15
                oSheet.Range("E1").ColumnWidth = 15
                oSheet.Range("F1").ColumnWidth = 15
                oSheet.Range("G1").ColumnWidth = 15
                oSheet.Range("H1").ColumnWidth = 15

                'fill cells
                oSheet.Range("A1").Value = "The public report burden for this information collection is estimated to average 6 hours"
                oSheet.Range("B5").Value = ("MONTHLY MOTOR-FUEL CONSUMPTION")
                oSheet.Range("A17").Value = "1. Gross Volume Reported"
                oSheet.Range("A18").Value = "2. Fully"
                oSheet.Range("A19").Value = "   Tax"
                oSheet.Range("A20").Value = "   Exempt"
                oSheet.Range("A28").Value = "3. Gross Volume Taxed (1.-2.j.)"
                oSheet.Range("A29").Value = "4. Fully"
                oSheet.Range("A30").Value = " Refunded"
                oSheet.Range("A49").Value = "5. Net"
                oSheet.Range("A50").Value = "    Volume"
                oSheet.Range("A51").Value = "    Taxed"
                oSheet.Range("A53").Value = "(Partial"
                oSheet.Range("A54").Value = "Exemption"
                oSheet.Range("A55").Value = "or"
                oSheet.Range("A56").Value = "Refund)"
                oSheet.Range("A59").Value = "6. Source"
                oSheet.Range("A61").Value = "Form FHWA-551M (Rev. 10/2005)"
                oSheet.Range("A66").Value = "   NOTES AND TECHNICAL INFORMATION"
                oSheet.Range("A71").Value = "1. Rate of tax at end of month, in cents per gallon or liter."
                oSheet.Range("A72").Value = "   (If tax is ad valorem, post percentage, and briefly explain basis"
                oSheet.Range("A73").Value = "below.)"
                oSheet.Range("A88").Value = "2. Rate of Optional Tax at end of month (in cents per gallon)"
                oSheet.Range("A97").Value = "3. Computation of gross volume reported (page1, item1.)"
                oSheet.Range("A101").Value = "  Gross sales from sellers returns"
                oSheet.Range("A102").Value = " Plus: IFTA fuel used in State (from users returns)"
                oSheet.Range("A103").Value = " Less: IFTA fuel purchased tax paid in State (from users returns) "
                oSheet.Range("A104").Value = " =  Net consumption in State (Enter on page 1, item 1.)"
                oSheet.Range("A106").Value = "  Interstate motor-carrier (fuel use tax) fuel volume shown above "
                oSheet.Range("A107").Value = "  covers the following period: (Specify month or months covered)"
                oSheet.Range("A110").Value = "4. Stratification of Gasohol by Blend Ratio"
                oSheet.Range("A112").Value = "The gasohol volume shown on page 1, column (2) includes:"
                oSheet.Range("A113").Value = "(Show actual/estimated volume or percentage shares)"
                oSheet.Range("A121").Value = "5. Notes and Comments"
                oSheet.Range("A122").Value = "Other under 'Rate of tax at the end of month' refers to Aviation Gas."
                oSheet.Range("A123").Value = "Gasohol is reported in total as 10+% alcohol because we do not have an accurate breakdown of the actual percentages."
                oSheet.Range("A127").Value = "Form FHWA-551M (Rev. 10/2005)"

                oSheet.Range("B13").Value = "Item"
                oSheet.Range("B18").Value = "a.Losses-Flat%"
                oSheet.Range("B19").Value = "b.Losses-Actual"
                oSheet.Range("B20").Value = "c.Federal"
                oSheet.Range("B21").Value = "d.Transit Use"
                oSheet.Range("B27").Value = "j.Total"
                oSheet.Range("B29").Value = "a.Agriculture"
                oSheet.Range("B30").Value = "b.Aviation"
                oSheet.Range("B31").Value = "c.Industrial"
                oSheet.Range("B32").Value = "d.Construction"
                oSheet.Range("B33").Value = "e.Boating"
                oSheet.Range("B34").Value = "f.Tribal Refunds"
                oSheet.Range("B48").Value = "t.Total"
                oSheet.Range("B49").Value = "a.At Full Rate"
                oSheet.Range("B50").Value = "b.Aviation"
                oSheet.Range("B58").Value = "j.Total"
                oSheet.Range("B59").Value = "a.Agency Preparing this Report"
                oSheet.Range("B60").Value = "b.Compiled under Direction of."
                oSheet.Range("B75").Value = "Fuel Type"
                oSheet.Range("B76").Value = "a.Gasoline"
                oSheet.Range("B77").Value = "b.Gasogol"
                oSheet.Range("B78").Value = "c.Diesel"
                oSheet.Range("B79").Value = "d.LPG"
                oSheet.Range("B80").Value = "e.CNG"
                oSheet.Range("B81").Value = "f.M85"
                oSheet.Range("B82").Value = "g. E85"
                oSheet.Range("B83").Value = "h. LNG"
                oSheet.Range("B84").Value = "i.Biodiesel"
                oSheet.Range("B85").Value = "j.Other"
                oSheet.Range("B90").Value = "Rate Name"
                oSheet.Range("B91").Value = "Inspection Fee"
                oSheet.Range("B92").Value = "Environmental Fee"
                oSheet.Range("B93").Value = "Local Tax"
                oSheet.Range("B94").Value = "Other"
                oSheet.Range("B115").Value = "% Alcohol"
                oSheet.Range("B117").Value = "5.7-7.6%"
                oSheet.Range("B118").Value = "7.7-9.9%"
                oSheet.Range("B119").Value = "+10 %"

                oSheet.Range("C13").Value = "Line No"
                oSheet.Range("C17").Value = "01"
                oSheet.Range("C18").Value = "21"
                oSheet.Range("C19").Value = "22"
                oSheet.Range("C20").Value = "23"
                oSheet.Range("C21").Value = "24"
                oSheet.Range("C22").Value = "25"
                oSheet.Range("C23").Value = "26"
                oSheet.Range("C24").Value = "27"
                oSheet.Range("C25").Value = "28"
                oSheet.Range("C26").Value = "29"
                oSheet.Range("C27").Value = "30"
                oSheet.Range("C28").Value = "40"
                oSheet.Range("C29").Value = "51"
                oSheet.Range("C30").Value = "52"
                oSheet.Range("C31").Value = "53"
                oSheet.Range("C32").Value = "54"
                oSheet.Range("C33").Value = "55"
                oSheet.Range("C34").Value = "56"
                oSheet.Range("C35").Value = "57"
                oSheet.Range("C36").Value = "58"
                oSheet.Range("C37").Value = "59"
                oSheet.Range("C38").Value = "60"
                oSheet.Range("C39").Value = "61"
                oSheet.Range("C40").Value = "62"
                oSheet.Range("C41").Value = "63"
                oSheet.Range("C42").Value = "64"
                oSheet.Range("C43").Value = "65"
                oSheet.Range("C44").Value = "66"
                oSheet.Range("C45").Value = "67"
                oSheet.Range("C46").Value = "68"
                oSheet.Range("C47").Value = "69"
                oSheet.Range("C48").Value = "70"
                oSheet.Range("C49").Value = "81"
                oSheet.Range("C50").Value = "82"
                oSheet.Range("C51").Value = "83"
                oSheet.Range("C52").Value = "84"
                oSheet.Range("C53").Value = "85"
                oSheet.Range("C54").Value = "86"
                oSheet.Range("C55").Value = "87"
                oSheet.Range("C56").Value = "88"
                oSheet.Range("C57").Value = "89"
                oSheet.Range("C58").Value = "90"
                oSheet.Range("D13").Value = "Gasoline"
                oSheet.Range("D16").Value = "-1-"

                Dim C11G As Double = GasArray(mg, 3)
                Dim D17 As Double = C11G + GasArray(43, mg2)
                oSheet.Range("D17").Value = CDec(D17)

                oSheet.Range("D27").Formula = "=SUM(D18:D26)"
                oSheet.Range("D28").Value = CDec(D17 - oSheet.Range("D27").Value)

                Dim D11G As Double = GasArray(mg, 4)
                Dim E46G As Double = GasArray(43, mg2)
                Dim AA11G As Double = GasArray(mg, 27)
                Dim AB11G As Double = GasArray(mg, 28)
                Dim AC11G As Double = GasArray(mg, 29)
                Dim AA30G As Double = 0.806
                Dim AA31G As Double = 0.194
                Dim R11G As Double = GasArray(mg, 18)
                Dim S11G As Double = GasArray(mg, 19)
                Dim U11G As Double = GasArray(mg, 21)
                Dim V11G As Double = GasArray(mg, 22)



                Dim T37 As Double = C11G / (C11G + D11G)
                Dim M37 As Double = AA11G / (AA11G + AB11G + AC11G)
                Dim O37 As Double = M37 * (U11G + V11G)
                Dim T47 As Double = 0.1765
                Dim Q37 As Double = O37 / T47
                Dim D29 As Double = Q37 * T37
                oSheet.Range("D29").Value = CDec(D29)

                Dim M39 As Double = AB11G / (AA11G + AB11G + AC11G)
                Dim O39 As Double = M39 * (U11G + V11G)
                Dim Q39 As Double = O39 / T47
                Dim D31 As Double = Q39 * T37
                oSheet.Range("D31").Value = CDec(D31)

                Dim M42 As Double = AC11G / (AA11G + AB11G + AC11G)
                Dim O42 As Double = M42 * (U11G + V11G)
                Dim Q42 As Double = O42 / T47
                Dim D34 As Double = Q42 * T37
                oSheet.Range("D34").Value = CDec(D34)

                oSheet.Range("D48").Formula = "=SUM(D29:D47)"
                oSheet.Range("D50").Value = E46G
                oSheet.Range("D58").Value = oSheet.Range("D28").Value - oSheet.Range("D48").Value
                oSheet.Range("D49").Formula = "=SUM(D50:D57)"
                oSheet.Range("D49").Value = oSheet.Range("D58").Value - oSheet.Range("D49").Value

                oSheet.Range("D59").Value = "Nevada Department of Transportation"
                oSheet.Range("D60").Value = "Rudy Malfabon"
                oSheet.Range("D75").Value = "Rate(cents)"
                oSheet.Range("D76").Value = "24"
                oSheet.Range("D77").Value = "24"
                oSheet.Range("D78").Value = "27"
                oSheet.Range("D79").Value = "22"
                oSheet.Range("D80").Value = "21"
                oSheet.Range("D85").Value = "02"
                oSheet.Range("D90").Value = "Rate(cents)"
                oSheet.Range("D91").Value = "00.055"
                oSheet.Range("D94").Value = "00.750"
                oSheet.Range("D115").Value = "Volume"

                oSheet.Range("D118").Value = D11G * AA31G
                oSheet.Range("D119").Value = D11G * AA30G
                oSheet.Range("D127").Value = 2

                oSheet.Range("E13").Value = "Gashol"
                oSheet.Range("E16").Value = "-2-"

                Dim E17 As Double = D11G
                oSheet.Range("E17").Value = D11G

                ' is this really supposed to be D11G - D27?
                oSheet.Range("E27").Formula = "=SUM(E18:E26)"
                oSheet.Range("E28").Value = CDec(D11G - oSheet.Range("D27").Value)

                Dim V37 As Double = D11G / (D11G + C11G)
                Dim E29 As Double = Q37 * V37
                oSheet.Range("E29").Value = E29
                Dim E31 As Double = Q39 * V37
                oSheet.Range("E31").Value = E31

                M42 = AC11G / (AA11G + AB11G + AC11G)
                O42 = M42 * (U11G + V11G)
                Q42 = O42 / T47
                Dim E34 As Double = Q42 * V37
                oSheet.Range("E34").Value = E34

                oSheet.Range("E48").Formula = "=SUM(E29:E47)"
                oSheet.Range("E58").Value = oSheet.Range("E28").Value - oSheet.Range("E48").Value
                oSheet.Range("E49").Formula = "=SUM(E50:E57)"
                oSheet.Range("E49").Value = oSheet.Range("E58").Value - oSheet.Range("E49").Value

                oSheet.Range("E75").Value = "Effective Date"
                oSheet.Range("E76").Value = "10/1/1992"
                oSheet.Range("E77").Value = "10/1/1992"
                oSheet.Range("E78").Value = "10/1/1992"
                oSheet.Range("E79").Value = "7/1/1997"
                oSheet.Range("E80").Value = "7/1/1997"
                oSheet.Range("E85").Value = "7/1/1997"

                oSheet.Range("E90").Value = "Effective Date"
                oSheet.Range("E91").Value = "7/1/1997"
                oSheet.Range("E94").Value = "7/1/1995"
                oSheet.Range("E115").Value = "Percentage Share"

                oSheet.Range("G2").Value = "State Name"
                oSheet.Range("G3").Value = "Nevada"
                oSheet.Range("G4").Value = "Year"
                oSheet.Range("G5").Value = year
                oSheet.Range("G6").Value = "Month of Sale or Transfer"
                oSheet.Range("G7").Value = month
                oSheet.Range("G8").Value = "Units(check one)"
                oSheet.Range("G9").Value = "Gallons"
                oSheet.Range("G10").Value = "Liters"
                oSheet.Range("G13").Value = "Alternate"
                oSheet.Range("G14").Value = "Fuels"
                oSheet.Range("G16").Value = "-4-"

                Dim G17 As Double = LPGArray(m, 42)
                oSheet.Range("G17").Value = G17
                Dim G21 As Double = LPGArray(m, 46)
                oSheet.Range("G21").Value = G21

                oSheet.Range("G27").Formula = "=SUM(G18:G26)"
                oSheet.Range("G28").Value = oSheet.Range("G17").Value - oSheet.Range("G27").Value
                oSheet.Range("G48").Formula = "=SUM(G29:G47)"
                oSheet.Range("G58").Value = oSheet.Range("G28").Value - oSheet.Range("G48").Value
                oSheet.Range("G49").Formula = "=SUM(F50:F57)"
                oSheet.Range("G49").Value = oSheet.Range("G58").Value - oSheet.Range("G49").Value

                oSheet.Range("G64").Value = "State Name"
                oSheet.Range("G65").Value = "Nevada "
                oSheet.Range("G66").Value = "Year"
                oSheet.Range("G67").Value = year
                oSheet.Range("G68").Value = "Month of Sale or Transfer"
                oSheet.Range("G69").Value = month
                oSheet.Range("G99").Value = "Diesel/Kerosence"

                Dim G101 As Double = DieselArray(m, 43)
                Dim G102 As Double = DieselArray(m, 44)
                Dim G103 As Double = DieselArray(m, 45)
                Dim G104 As Double = G101 + G102 - G103
                oSheet.Range("G101").Value = G101
                oSheet.Range("G102").Value = G102
                oSheet.Range("G103").Value = G103
                oSheet.Range("G104").Value = G104

                oSheet.Range("F12").Value = "Private and Commercial"
                oSheet.Range("F13").Value = "Highway"
                oSheet.Range("F14").Value = "Diesel "
                oSheet.Range("F16").Value = "-3-"
                Dim F17 As Double = G104
                oSheet.Range("F17").Value = F17
                Dim F21 As Double = DieselArray(m, 47)
                oSheet.Range("F21").Value = F21

                oSheet.Range("F27").Formula = "=SUM(F18:F26)"
                oSheet.Range("F28").Value = oSheet.Range("F17").Value - oSheet.Range("F27").Value
                oSheet.Range("F48").Formula = "=SUM(F29:F47)"
                oSheet.Range("F58").Value = oSheet.Range("F28").Value - oSheet.Range("F48").Value
                oSheet.Range("F49").Formula = "=SUM(F50:F57)"
                oSheet.Range("F49").Value = oSheet.Range("F58").Value - oSheet.Range("F49").Value

                oSheet.Range("F90").Value = " Inspection Fee Comment(s);"
                oSheet.Range("F94").Value = "State Petroleum Cleanup Fund"
                oSheet.Range("F99").Value = "Gasoline"
                oSheet.Range("F106").Value = "Begining"
                oSheet.Range("F107").Value = begin
                oSheet.Range("G106").Value = "End"
                oSheet.Range("G107").Value = finish
                oSheet.Range("H13").Value = "Total"
                oSheet.Range("H16").Value = "-5-"

                Dim H17 As Double = D17 + E17 + F17 + G17
                oSheet.Range("H17").Value = H17
                Dim H21 As Double = F21 + G21
                oSheet.Range("H21").Value = H21

                oSheet.Range("H27").Value = oSheet.Range("F27").Value + oSheet.Range("G27").Value

                oSheet.Range("H28").Value = oSheet.Range("D28").Value + oSheet.Range("E28").Value + oSheet.Range("F28").Value + oSheet.Range("G28").Value

                oSheet.Range("H29").Value = D29 + E29
                oSheet.Range("H31").Value = D31 + E31
                oSheet.Range("H34").Value = D34 + E34
                oSheet.Range("H48").Value = oSheet.Range("D48").Value + oSheet.Range("E48").Value

                oSheet.Range("H49").Value = oSheet.Range("D49").Value + oSheet.Range("E49").Value + oSheet.Range("F49").Value + oSheet.Range("G49").Value
                oSheet.Range("H50").Value = oSheet.Range("D50").Value
                oSheet.Range("H58").Value = oSheet.Range("D58").Value + oSheet.Range("E58").Value + oSheet.Range("F58").Value + oSheet.Range("G58").Value


                'applying a fill backcolor
                Dim style As Excel.Style = oSheet.Application.ActiveWorkbook.Styles.Add("background")
                'style.Font.Bold = True
                style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
                oSheet.Range("F18", "G19").Style = "background"
                oSheet.Range("F29", "G33").Style = "background"
                oSheet.Range("A75", "A86").Style = "background"
                oSheet.Range("C75", "C86").Style = "background"
                oSheet.Range("B86").Style = "background"
                oSheet.Range("D86").Style = "background"
                oSheet.Range("E86").Style = "background"
                oSheet.Range("F75", "H86").Style = "background"
                oSheet.Range("H99", "H104").Style = "background"
                oSheet.Range("H107").Style = "background"
                oSheet.Range("A116", "A119").Style = "background"
                oSheet.Range("C116", "C119").Style = "background"
                oSheet.Range("F116", "H119").Style = "background"
                oSheet.Range("A91", "A94").Style = "background"
                oSheet.Range("C91", "C94").Style = "background"
                ' EXAMPLE Format A1:D1 as bold, vertical alignment = center.
                'With oSheet.Range("A1", "D1")
                '.Font.Bold = True
                '.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                'End With


                ' change the color
                Dim style1 As Excel.Style = oSheet.Application.ActiveWorkbook.Styles.Add("bluefont")
                style1.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)

                oSheet.Range("G3").Style = "bluefont"
                oSheet.Range("G5").Style = "bluefont"
                oSheet.Range("G7").Style = "bluefont"
                oSheet.Range("D17", "G17").Style = "bluefont"
                oSheet.Range("B21").Style = "bluefont"
                oSheet.Range("F21", "G22").Style = "bluefont"
                oSheet.Range("D29", "E29").Style = "bluefont"
                oSheet.Range("D31", "E31").Style = "bluefont"
                oSheet.Range("B34").Style = "bluefont"
                oSheet.Range("D34", "E34").Style = "bluefont"
                oSheet.Range("D50").Style = "bluefont"
                oSheet.Range("D59", "D60").Style = "bluefont"
                oSheet.Range("G65").Style = "bluefont"
                oSheet.Range("G67").Style = "bluefont"
                oSheet.Range("G69").Style = "bluefont"
                oSheet.Range("D76", "D80").Style = "bluefont"
                oSheet.Range("D85").Style = "bluefont"
                oSheet.Range("D91").Style = "bluefont"
                oSheet.Range("D94").Style = "bluefont"
                oSheet.Range("F94").Style = "bluefont"
                oSheet.Range("G101", "G103").Style = "bluefont"
                oSheet.Range("D118", "D119").Style = "bluefont"

                'set the borders
                Dim style2 As Excel.Style = oSheet.Application.ActiveWorkbook.Styles.Add("border")
                style2.Borders(XlBordersIndex.xlEdgeBottom).Weight = 3

                oSheet.Range("B17", "I58").Borders(XlBordersIndex.xlInsideVertical).Weight = 3
                'xlInsideVertical xlInsideHorizontal xlEdgeLeft/Top/Right
                'oSheet.Range("C17", "H58").Style = "border"
                oSheet.Range("B16", "H61").Borders(XlBordersIndex.xlInsideHorizontal).Weight = 3
                'oSheet.Range("C17", "H58").Borders(XlBordersIndex.xlInsideHorizontal).Weight = 3
                oSheet.Range("A121", "H128").Borders(XlBordersIndex.xlInsideHorizontal).Weight = 3
                oSheet.Range("A1", "A127").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("H1", "H127").Borders(XlBordersIndex.xlEdgeRight).Weight = 3
                oSheet.Range("A127", "H127").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A1", "H1").Borders(XlBordersIndex.xlEdgeTop).Weight = 3

                oSheet.Range("A10", "H10").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("G3", "H3").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("G5", "H5").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("G7", "H7").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("F12", "G12").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3

                oSheet.Range("A16", "A17").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A27", "A28").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A48").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A58").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A60").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A16").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3

                oSheet.Range("A63", "H63").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A69", "H69").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("G65", "H65").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("G67", "H67").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A74", "H74").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("B75").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("D75", "E75").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("B85").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("D85", "E85").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3

                oSheet.Range("A90", "H90").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("F98", "H98").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("F104", "H104").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("F106", "H106").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("F107", "H107").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A108", "H108").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A115", "H115").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A119", "H119").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("A94", "H94").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3
                oSheet.Range("G1", "G10").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("H11", "H16").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("G13", "G16").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("F11", "F16").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("E11", "E16").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("D11", "D16").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("C11", "C16").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("A86", "H86").Borders(XlBordersIndex.xlEdgeBottom).Weight = 3

                oSheet.Range("B18", "B27").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("B29", "B60").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("D59", "D60").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3

                oSheet.Range("G64", "G69").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3

                'up to here
                oSheet.Range("B75", "B85").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("C75", "C85").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("D75", "D85").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("E75", "E85").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("F75", "F85").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3

                oSheet.Range("B91", "B94").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("C91", "C94").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("D91", "D94").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3

                oSheet.Range("E91", "E94").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("F91", "F94").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3

                oSheet.Range("B116", "B119").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("C116", "C119").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("D116", "D119").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("E116", "E119").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("F116", "F119").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3

                oSheet.Range("F99", "F104").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("G99", "G104").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("H99", "H104").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3


                oSheet.Range("F107").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("G107").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3
                oSheet.Range("H107").Borders(XlBordersIndex.xlEdgeLeft).Weight = 3



                'saves a copy of the workbook to the server
                oWB.SaveCopyAs(Server.MapPath("~/Reports/NewReport/" & year & month & ".xlsx"))


                'download file
                Dim downfname As String = year & month & ".xlsx"
                Response.ContentType = "application/octet-stream"
                Response.AppendHeader("Content-Disposition", "attachment; filename=""" & downfname & """")
                'Dim aaa As String = Server.MapPath("~/Reports/" & report & "/" & year & "/" & month & "/" & filename)
                Response.TransmitFile(Server.MapPath("~/Reports/NewReport/" & downfname))
                Response.[End]()


                ' Make sure that you release object references.
                oRng = Nothing
                oSheet = Nothing
                oWB = Nothing
                oXL.Quit()
                oXL = Nothing
                Marshal.ReleaseComObject(oWB)
                Marshal.ReleaseComObject(oXL)
                GC.Collect()

            Catch e As System.Exception
                errMsg = "There was an error. Report could not be generated. Please go back and try again."
            End Try

            ViewData("err") = errMsg & errMsg1

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
