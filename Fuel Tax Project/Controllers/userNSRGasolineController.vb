Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userNSRGasolineController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userNSRGasoline/
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

            Return View()
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be


            'get the radio button value
            ' Calendar = 1, State Fiscal = 2, Federal Fiscal = 3
            Dim reportType As Integer = ed1.RadioValue

            Dim taxYear As Integer
            taxYear = ed1.startDD()

            Dim List As New List(Of CChartData)
            Dim valQ = (From y In db.gasolinegbycous
                        Where y.year = taxYear
                        Select y.CountyN, y.Gallon)

            '.Union(From e In db.taxcollgalls _
            'Where e.year = taxYear
            'Select e.CountyN)

            For Each k In valQ
                List.Add(New CChartData With {.ValueS1 = k.Gallon, .ValueString = k.CountyN})
            Next

            Dim DistinctList = List.GroupBy(Function(x) x.ValueString).[Select](Function(y) y.First())

            Return View(DistinctList)
        End Function



    End Class
End Namespace
