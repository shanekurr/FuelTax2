Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userTotalTaxByCountyController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userTotalTaxByCounty/
        Function Index() As ActionResult
            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.taxcolmoney2 _
                       Select y.year, y.ID _
                       Order By year

            For Each k In valQ
                List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
            Next

            Dim DistinctList = List.GroupBy(Function(x) x.Value).[Select](Function(y) y.First())

            ViewData("startDD") = DistinctList

            Return View()

        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be

            Dim yearType As String
            Dim taxYear As Integer

            taxYear = ed1.startDD()
            yearType = ed1.RadioValue()

            'Dim List As New List(Of CChartData)
            Dim List2 As New List(Of CChartData)


            If (yearType = 2) Then
                'This should include the current year months until June and include the months of July-Dec of the previous year 
                Dim valQ = (From y In db.taxcolmoney2
                Where y.year = taxYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June") _
                Select y.CountyN, y.AmountD, y.year)

                Dim valQ2 = (From y In db.taxcolmoney2
                Where y.year = taxYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December") _
                Select y.CountyN, y.AmountD, y.year)


                Dim tempValue As Double
                For Each l In valQ
                    For Each i In valQ2
                        If (l.CountyN = i.CountyN) Then
                            If (l.AmountD <> i.AmountD) Then
                                tempValue = l.AmountD + i.AmountD
                                List2.Add(New CChartData With {.ValueS1 = tempValue, .ValueString = l.CountyN})
                            Else
                                List2.Add(New CChartData With {.ValueS1 = l.AmountD, .ValueString = l.CountyN})
                            End If
                        End If
                    Next
                Next

            End If

            If (yearType = 3) Then
                'This should include the current year months until October and include the months of Oct-Dec of the previous year
                Dim valQ = (From y In db.taxcolmoney2
                Where y.year = taxYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September") _
                Select y.CountyN, y.AmountD, y.year)

                Dim valQ2 = (From y In db.taxcolmoney2
                Where y.year = taxYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December") _
                Select y.CountyN, y.AmountD, y.year)

                Dim tempValue As Double
                For Each l In valQ
                    For Each i In valQ2
                        If (l.CountyN = i.CountyN) Then
                            If (l.AmountD <> i.AmountD) Then
                                tempValue = l.AmountD + i.AmountD
                                List2.Add(New CChartData With {.ValueS1 = tempValue, .ValueString = l.CountyN})
                            Else
                                List2.Add(New CChartData With {.ValueS1 = l.AmountD, .ValueString = l.CountyN})
                            End If
                        End If
                    Next
                Next

            End If

            If (yearType = 1) Then

                Dim valQ = (From y In db.taxcolmoney2
                Where y.year = taxYear
                Select y.CountyN, y.AmountD)

                For Each k In valQ
                    List2.Add(New CChartData With {.ValueS1 = k.AmountD, .ValueString = k.CountyN})
                Next

            End If



            Dim DistinctList = List2.GroupBy(Function(x) x.ValueString).[Select](Function(y) y.First())

            Return View(DistinctList)

        End Function

    End Class
End Namespace
