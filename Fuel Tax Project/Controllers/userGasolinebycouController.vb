Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userGasolinebycouController
   
                Inherits System.Web.Mvc.Controller

                Private db As New fueltaxEntities

                ' GET: /userTotalGallonsByCounty/
                Function Index() As ActionResult
                    Dim List As New List(Of SelectListItem) ' Year query to populate dropdown
                    List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
                    Dim valQ = From y In db.gasolinegbycous _
                               Select y.year, y.ID _
                               Order By year

                    Dim List2 As New List(Of SelectListItem) ' County query to populate dropdown
                    List2.Add(New SelectListItem With {.Text = "Select a County", .Value = 0}) ' Adds first value as "Select a County"
                    Dim valQ2 = From y In db.gasolinegbycous _
                               Select y.CountyN, y.ID _
                               Order By CountyN

                    For Each k In valQ
                        List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
                    Next

                    For Each k In valQ2
                        List2.Add(New SelectListItem With {.Text = k.CountyN, .Value = k.CountyN})
                    Next

                    Dim DistinctList = List.GroupBy(Function(x) x.Value).[Select](Function(y) y.First())

                    Dim DistinctList2 = List2.GroupBy(Function(k) k.Text).[Select](Function(p) p.First())

                    ViewData("startDD") = DistinctList
                    ViewData("endDD") = DistinctList

                    ViewData("county") = DistinctList2

                    Return View()

                End Function

                <AcceptVerbs(HttpVerbs.Post)>
                Function Chart1(ed1 As DropDownData) As ActionResult
                    'This is where the code to build the chart should be

                    Dim yearType As String
                    Dim taxYear As Integer

                    taxYear = ed1.startDD()
                    yearType = ed1.RadioValue()

                    'Dim List As New List(Of CChartData)
                    Dim List2 As New List(Of CChartData)


                    If (yearType = 2) Then
                        'This should include the current year months until June and include the months of July-Dec of the previous year 
                        Dim valQ = (From y In db.gasolinegbycous
                        Where y.year = taxYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June") _
                        Select y.CountyN, y.Gallon, y.year)

                        Dim valQ2 = (From y In db.gasolinegbycous
                        Where y.year = taxYear - 1 AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December") _
                        Select y.CountyN, y.Gallon, y.year)


                        Dim tempValue As Double
                        For Each l In valQ
                            For Each i In valQ2
                                If (l.CountyN = i.CountyN) Then
                                    If (l.Gallon <> i.Gallon) Then
                                        tempValue = l.Gallon + i.Gallon
                                        List2.Add(New CChartData With {.ValueS1 = tempValue, .ValueString = l.CountyN})
                                    Else
                                        List2.Add(New CChartData With {.ValueS1 = l.Gallon, .ValueString = l.CountyN})
                                    End If
                                End If
                            Next
                        Next

                    End If

                    If (yearType = 3) Then
                        'This should include the current year months until October and include the months of Oct-Dec of the previous year
                        Dim valQ = (From y In db.gasolinegbycous
                        Where y.year = taxYear AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September") _
                        Select y.CountyN, y.Gallon, y.year)

                        Dim valQ2 = (From y In db.gasolinegbycous
                        Where y.year = taxYear - 1 AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December") _
                        Select y.CountyN, y.Gallon, y.year)

                        Dim tempValue As Double
                        For Each l In valQ
                            For Each i In valQ2
                                If (l.CountyN = i.CountyN) Then
                                    If (l.Gallon <> i.Gallon) Then
                                        tempValue = l.Gallon + i.Gallon
                                        List2.Add(New CChartData With {.ValueS1 = tempValue, .ValueString = l.CountyN})
                                    Else
                                        List2.Add(New CChartData With {.ValueS1 = l.Gallon, .ValueString = l.CountyN})
                                    End If
                                End If
                            Next
                        Next

                    End If

                    If (yearType = 1) Then

                        Dim valQ = (From y In db.gasolinegbycous
                        Where y.year = taxYear
                        Select y.CountyN, y.Gallon)

                        For Each k In valQ
                            List2.Add(New CChartData With {.ValueS1 = k.Gallon, .ValueString = k.CountyN})
                        Next

                    End If



                    Dim DistinctList = List2.GroupBy(Function(x) x.ValueString).[Select](Function(y) y.First())

                    Return View(DistinctList)

                End Function

                '' ******************************** BEGIN SECOND CHART *****************************************
                <AcceptVerbs(HttpVerbs.Post)>
                Function Chart2(ed1 As DropDownData) As ActionResult
                    'This is where the code to build the chart should be

                    Dim county As String
                    Dim year As Integer

                    year = ed1.startDD()
                    county = ed1.county()

                    'Dim List As New List(Of CChartData)
                    Dim List As New List(Of CChartData)

                    'This should include the current year months until June and include the months of July-Dec of the previous year 
                    Dim valQ = (From y In db.gasolinegbycous
                    Where y.year = year AndAlso y.CountyN = county _
                    Select y.month, y.Gallon)

                    For Each l In valQ
                        List.Add(New CChartData With {.ValueS1 = l.Gallon, .ValueString = l.month})

                    Next



                    Return View(List)
                End Function

                <AcceptVerbs(HttpVerbs.Post)>
                Function Chart3(ed1 As DropDownData) As ActionResult
                    'This is where the code to build the chart should be

                    Dim yearType As String
                    Dim county As String

                    Dim startYear As Integer
                    Dim endYear As Integer

                    startYear = ed1.startDD()
                    endYear = ed1.endDD()
                    yearType = ed1.RadioValue()
                    county = ed1.county()
                    'Dim List As New List(Of CChartData)
                    Dim List2 As New List(Of CChartData)


                    If (yearType = 2) Then
                        'This should include the current year months until June and include the months of July-Dec of the previous year 
                        Dim valQ = (From y In db.gasolinegbycous
                        Where y.year >= startYear AndAlso y.year <= endYear AndAlso y.CountyN = county AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June") _
                        Select y.CountyN, y.Gallon, y.year)

                        Dim valQ2 = (From y In db.gasolinegbycous
                        Where y.year >= startYear - 1 AndAlso y.year <= endYear AndAlso y.CountyN = county AndAlso (y.month = "July" Or y.month = "August" Or y.month = "September" Or y.month = "October" Or y.month = "November" Or y.month = "December") _
                        Select y.CountyN, y.Gallon, y.year)


                        Dim tempValue As Double
                        For Each l In valQ
                            For Each i In valQ2
                                If (l.CountyN = i.CountyN) Then
                                    If (l.Gallon <> i.Gallon) Then
                                        tempValue = l.Gallon + i.Gallon
                                        List2.Add(New CChartData With {.ValueS1 = tempValue, .ValueS2 = l.year})
                                    Else
                                        List2.Add(New CChartData With {.ValueS1 = l.Gallon, .ValueS2 = l.year})
                                    End If
                                End If
                            Next
                        Next

                    End If

                    If (yearType = 3) Then
                        'This should include the current year months until October and include the months of Oct-Dec of the previous year
                        Dim valQ = (From y In db.gasolinegbycous
                        Where y.year >= startYear AndAlso y.year <= endYear AndAlso y.CountyN = county AndAlso (y.month = "January" Or y.month = "February" Or y.month = "March" Or y.month = "April" Or y.month = "May" Or y.month = "June" Or y.month = "July" Or y.month = "August" Or y.month = "September") _
                        Select y.CountyN, y.Gallon, y.year)

                        Dim valQ2 = (From y In db.gasolinegbycous
                        Where y.year >= startYear - 1 AndAlso y.year <= endYear - 1 AndAlso y.CountyN = county AndAlso (y.month = "October" Or y.month = "November" Or y.month = "December") _
                        Select y.CountyN, y.Gallon, y.year)

                        Dim tempValue As Double
                        For Each l In valQ
                            For Each i In valQ2
                                If (l.CountyN = i.CountyN) Then
                                    If (l.Gallon <> i.Gallon) Then
                                        tempValue = l.Gallon + i.Gallon
                                        List2.Add(New CChartData With {.ValueS1 = tempValue, .ValueS2 = l.year})
                                    Else
                                        List2.Add(New CChartData With {.ValueS1 = l.Gallon, .ValueS2 = l.year})
                                    End If
                                End If
                            Next
                        Next

                    End If

                    If (yearType = 1) Then

                        Dim valQ = (From y In db.gasolinegbycous
                        Where y.year >= startYear AndAlso y.year <= endYear AndAlso y.CountyN = county
                        Select y.year, y.Gallon)

                        For Each k In valQ
                            List2.Add(New CChartData With {.ValueS1 = k.Gallon, .ValueS2 = k.year})
                        Next

                    End If



                    Dim DistinctList = List2.GroupBy(Function(x) x.ValueS2).[Select](Function(y) y.First())

                    Return View(DistinctList)

                End Function
            End Class
        End Namespace

