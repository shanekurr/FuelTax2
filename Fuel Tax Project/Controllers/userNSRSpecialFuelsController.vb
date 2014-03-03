﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userNSRSpecialFuelsController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userNSRSpecialFuels/
        Function Index() As ActionResult


            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.taxcollgalls _
                       Select y.year, y.ID _
                       Distinct
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
            'This is where the code to build the chart should be

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

                Dim totalGasClark As Long = 0
                Dim totalGasWashoe As Long = 0
                Dim totalGasRural As Long = 0
                Dim temp As Long = 0

                'This should include the current year months until June and include the months of July-Dec of the previous year 
                If reportType = 2 Then

                    Dim clarkGas = (From y In db.taxcollgalls
                    Where y.CountyN = "Clark" AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim washoeGas = (From y In db.taxcollgalls
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim ruralGas = (From y In db.taxcollgalls
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June")) Or (y.year = startYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    For Each l In clarkGas
                        totalGasClark += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In washoeGas
                        totalGasWashoe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In ruralGas
                        totalGasRural += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next

                    'Federal Fiscal
                ElseIf reportType = 3 Then

                    Dim clarkGas = (From y In db.taxcollgalls
                    Where y.CountyN = "Clark" AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim washoeGas = (From y In db.taxcollgalls
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim ruralGas = (From y In db.taxcollgalls
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso ((y.year = endYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September")) Or (y.year = startYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December")) Or (y.year >= startYear AndAlso y.year < endYear)) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    For Each l In clarkGas
                        totalGasClark += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In washoeGas
                        totalGasWashoe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In ruralGas
                        totalGasRural += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next

                    'This is Calendar year reportType = 1 
                Else

                    Dim clarkGas = (From y In db.taxcollgalls
                    Where y.CountyN = "Clark" AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim washoeGas = (From y In db.taxcollgalls
                    Where (y.CountyN = "Washoe" Or y.CountyN = "Carson City") AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    Dim ruralGas = (From y In db.taxcollgalls
                    Where (y.CountyN <> "Clark" AndAlso y.CountyN <> "Washoe" AndAlso y.CountyN <> "Carson City" AndAlso y.CountyN <> "Totals") AndAlso (y.year >= startYear AndAlso y.year <= endYear) _
                    Select y.LPG, y.CNG, y.A55, y.Diesel, y.year)

                    For Each l In clarkGas
                        totalGasClark += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In washoeGas
                        totalGasWashoe += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next
                    For Each l In ruralGas
                        totalGasRural += l.LPG + l.CNG + l.A55 + l.Diesel
                    Next

                End If


                temp1 = totalGasClark / (totalGasClark + totalGasWashoe + totalGasRural)
                temp2 = totalGasWashoe / (totalGasClark + totalGasWashoe + totalGasRural)
                temp3 = totalGasRural / (totalGasClark + totalGasWashoe + totalGasRural)

                List.Add(New CChartData With {.ValueString = "Clark", .ValueLong = totalGasClark, .ValueDbl = Math.Round(temp1 * 100, 2)})
                List.Add(New CChartData With {.ValueString = "Washoe/Carson City", .ValueLong = totalGasWashoe, .ValueDbl = Math.Round(temp2 * 100, 2)})
                List.Add(New CChartData With {.ValueString = "Rural", .ValueLong = totalGasRural, .ValueDbl = Math.Round(temp3 * 100, 2)})
                ViewData("perCla") = temp1
                ViewData("perWas") = temp2
                ViewData("perRur") = temp3


            End If
            Return View(List)

        End Function

    End Class
End Namespace
