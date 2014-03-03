Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userTotalTaxRevPerYearController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userTotalTaxRevPerYear/
        Function Index() As ActionResult

            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.gasrevperyears _
                       Select y.year, y.ID _
                       Order By year

            For Each k In valQ
                List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
            Next

            ViewData("startDD") = List
            ViewData("endDD") = List

            Return View()
        End Function

        ' GET: /userTotalTaxRevPerYear/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasvsgasohole As gasvsgasohole = db.gasvsgasoholes.Find(id)
            If IsNothing(gasvsgasohole) Then
                Return HttpNotFound()
            End If
            Return View(gasvsgasohole)
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be

            Dim startYear, endYear As Integer
            startYear = ed1.startDD
            endYear = ed1.endDD

            Dim List As New List(Of CChartData)
            Dim List2 As New List(Of CChartData)

            Dim valQ = From y In db.gasrevperyears
                        Where y.year >= startYear AndAlso endYear >= y.year
                        Select y.year, y.amount
                        Order By year

            Dim valQ2 = From y In db.mcspefuels
                        Where y.year >= startYear AndAlso endYear >= y.year
                        Select y.year, y.amount
                        Order By year

            Dim tempValue As Double

            For Each k In valQ
                For Each j In valQ2
                    If (k.year = j.year) Then
                        If (k.amount <> j.amount) Then
                            tempValue = (k.amount + j.amount)
                            List.Add(New CChartData With {.ValueS1 = tempValue, .Year = k.year})
                        Else
                            List.Add(New CChartData With {.ValueS1 = k.amount, .Year = k.year})
                        End If
                    End If
                Next
            Next



            Return View(List)
        End Function
        

        
    End Class
End Namespace
