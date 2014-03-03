Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class NSandRuralTotRevController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /NSandRuralTotRev/
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
            ViewData("endDD") = DistinctList

            Return View()

        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be

            Dim List As New List(Of CChartData)

            Dim startYear, endYear As Integer
            startYear = ed1.startDD
            endYear = ed1.endDD

            Dim valQ = From y In db.taxcolmoney2
                        Where y.year >= startYear AndAlso endYear >= y.year
                        Select y.year, y.AmountD
                        Order By year

            '.Union(From e In db.taxcollgalls _
            'Where e.year = taxYear
            'Select e.CountyN)

            For Each k In valQ
                List.Add(New CChartData With {.ValueS1 = k.AmountD, .Year = k.year})
            Next

            Dim DistinctList = List.GroupBy(Function(x) x.ValueString).[Select](Function(y) y.First())

            Return View(DistinctList)

        End Function

    End Class
End Namespace
