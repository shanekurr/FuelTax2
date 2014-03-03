Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userSFRevPerYearController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userSFRevPerYear/
        Function Index() As ActionResult
            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.mcspefuels _
                       Select y.year, y.ID _
                       Order By year

            For Each k In valQ
                List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
            Next

            ViewData("startDD") = List
            ViewData("endDD") = List

            Return View()
        End Function

        ' GET: /userSFRevPerYear/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mcspefuel As mcspefuel = db.mcspefuels.Find(id)
            If IsNothing(mcspefuel) Then
                Return HttpNotFound()
            End If
            Return View(mcspefuel)
        End Function


        <AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be

            Dim startYear, endYear As Integer
            startYear = ed1.startDD
            endYear = ed1.endDD

            Dim List As New List(Of CChartData)
            Dim valQ = From y In db.mcspefuels
                        Where y.year >= startYear AndAlso endYear >= y.year
                        Select y.year, y.amount
                        Order By year

            For Each k In valQ
                List.Add(New CChartData With {.Year = k.year, .ValueS1 = k.amount})
            Next


            Return View(List)
        End Function

        
    End Class
End Namespace
