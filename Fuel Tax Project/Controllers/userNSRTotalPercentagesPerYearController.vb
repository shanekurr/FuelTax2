Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userNSRTotalPercentagesPerYearController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userNSRTotalPercentagesPerYear/
        Function Index() As ActionResult

           Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.gasolinegbycous _
                       Select y.year, y.ID
                       Order By year

            For Each k In valQ
                List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
            Next

            Dim DistinctList = List.GroupBy(Function(x) x.Value).[Select](Function(y) y.First())

            ViewData("startDD") = DistinctList
            ViewData("endDD") = DistinctList

            Return View()
        End Function


<AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult

            ' Calendar = 1, State Fiscal = 2, Federal Fiscal = 3
            Dim reportType As Integer = ed1.RadioValue

            Dim startYear, endYear As Integer
            startYear = ed1.startDD()
            endYear = ed1.endDD()

            Dim temp1, temp2, temp3 As Double
            Dim List As New List(Of CChartData)

            Dim errMessage As String = ""
            If startYear > endYear Then
                errMessage = "Invalid input! Your start date must be before end date."
                ViewData("errMessage") = errMessage
            Else

                Dim totalGasClarkSpe As Long = 0
                Dim totalGasWashoeSpe As Long = 0
                Dim totalGasRuralSpe As Long = 0
                Dim totalGasClark As Long = 0
                Dim totalGasWashoe As Long = 0
                Dim totalGasRural As Long = 0



                '##################################################################
                'This should include the current year months until June and include the months of July-Dec of the previous year 
                If reportType = 2 Then

                    Dim clarkGasSpe = (From y In db.taxcollgalls
                    Where y.CountyN = "Clark" AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim washoeGasSpe = (From y In db.taxcollgalls
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim ruralGasSpe = (From y In db.taxcollgalls
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim clarkGas = (From y In db.gasolinegbycous
                    Where y.CountyN = "Clark" AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.Gallon, y.year)
                    Dim washoeGas = (From y In db.gasolinegbycous
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.Gallon, y.year)
                    Dim ruralGas = (From y In db.gasolinegbycous
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.Gallon, y.year)



                    For Each l In clarkGasSpe
                        totalGasClarkSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In washoeGasSpe
                        totalGasWashoeSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In ruralGasSpe
                        totalGasRuralSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In clarkGas
                        totalGasClark += l.Gallon
                    Next
                    For Each l In washoeGas
                        totalGasWashoe += l.Gallon
                    Next
                    For Each l In ruralGas
                        totalGasRural += l.Gallon
                    Next


                    '##################################################################
                    'Federal Fiscal
                ElseIf reportType = 3 Then

                    Dim clarkGasSpe = (From y In db.taxcollgalls
                    Where y.CountyN = "Clark" AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim washoeGasSpe = (From y In db.taxcollgalls
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim ruralGasSpe = (From y In db.taxcollgalls
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim clarkGas = (From y In db.gasolinegbycous
                    Where y.CountyN = "Clark" AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.Gallon, y.year)
                    Dim washoeGas = (From y In db.gasolinegbycous
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.Gallon, y.year)
                    Dim ruralGas = (From y In db.gasolinegbycous
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.Gallon, y.year)

                    For Each l In clarkGasSpe
                        totalGasClarkSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In washoeGasSpe
                        totalGasWashoeSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In ruralGasSpe
                        totalGasRuralSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In clarkGas
                        totalGasClark += l.Gallon
                    Next
                    For Each l In washoeGas
                        totalGasWashoe += l.Gallon
                    Next
                    For Each l In ruralGas
                        totalGasRural += l.Gallon
                    Next


                    '##################################################################
                    'This is Calendar year reportType = 1 
                Else

                    Dim clarkGasSpe = (From y In db.taxcollgalls
                    Where y.CountyN = "Clark" AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim washoeGasSpe = (From y In db.taxcollgalls
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)
                    Dim ruralGasSpe = (From y In db.taxcollgalls
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim clarkGas = (From y In db.gasolinegbycous
                    Where y.CountyN = "Clark" AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.Gallon, y.year)
                    Dim washoeGas = (From y In db.gasolinegbycous
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.Gallon, y.year)
                    Dim ruralGas = (From y In db.gasolinegbycous
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.Gallon, y.year)

                    For Each l In clarkGasSpe
                        totalGasClarkSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In washoeGasSpe
                        totalGasWashoeSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In ruralGasSpe
                        totalGasRuralSpe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In clarkGas
                        totalGasClark += l.Gallon
                    Next
                    For Each l In washoeGas
                        totalGasWashoe += l.Gallon
                    Next
                    For Each l In ruralGas
                        totalGasRural += l.Gallon
                    Next

                End If


                '##################################################################

                temp1 = (totalGasClarkSpe + totalGasClark) / (totalGasClarkSpe + totalGasWashoeSpe + totalGasRuralSpe + totalGasClark + totalGasRural + totalGasWashoe)
                temp2 = (totalGasWashoeSpe + totalGasWashoe) / (totalGasClarkSpe + totalGasWashoeSpe + totalGasRuralSpe + totalGasClark + totalGasRural + totalGasWashoe)
                temp3 = (totalGasRuralSpe + totalGasRural) / (totalGasClarkSpe + totalGasWashoeSpe + totalGasRuralSpe + totalGasClark + totalGasRural + totalGasWashoe)

                List.Add(New CChartData With {.ValueString = "Clark", .ValueLong = (totalGasClarkSpe + totalGasClark), .ValueDbl = temp1 * 100})
                List.Add(New CChartData With {.ValueString = "Washoe/Carson City", .ValueLong = (totalGasWashoeSpe + totalGasWashoe), .ValueDbl = temp2 * 100})
                List.Add(New CChartData With {.ValueString = "Rural", .ValueLong = (totalGasRuralSpe + totalGasRural), .ValueDbl = temp3 * 100})
                ViewData("perCla") = temp1
                ViewData("perWas") = temp2
                ViewData("perRur") = temp3

            End If


            Return View(List)

        End Function
       

    End Class
End Namespace
