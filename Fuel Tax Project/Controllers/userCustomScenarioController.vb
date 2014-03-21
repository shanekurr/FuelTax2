Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userCustomScenarioController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userCustomScenario/
        Function Index() As ActionResult

            Dim List As New List(Of SelectListItem)
            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.gasrevperyears _
                       Select y.year, y.ID _
                       Order By year

            For Each k In valQ
                List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
            Next


            Dim IntList As New List(Of SelectListItem)
            For i As Integer = 0 To 100
                IntList.Add(New SelectListItem With {.Text = i, .Value = i})
            Next

            ViewData("IntList") = IntList

            Return View()

        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be
            Dim Scen1R, Scen2R, Scen3R, Scen4R As Nullable(Of Integer)
            Dim Scen1Value, Scen2Value, Scen3Value, Scen4Value As Nullable(Of Integer)
            Dim Scen1Mult, Scen2Mult, Scen3Mult, Scen4Mult As Nullable(Of Decimal)

            Dim List As New List(Of CChartData)
            Dim valQ = From y In db.gasrevperyears
                        Select y.year, y.amount
                        Order By year


            Scen1Value = ed1.Scen1DD
            Scen1R = ed1.Scen1Radio

            Scen2Value = ed1.Scen2DD
            Scen2R = ed1.Scen2Radio

            Scen3Value = ed1.Scen3DD
            Scen3R = ed1.Scen3Radio

            Scen4Value = ed1.Scen4DD
            Scen4R = ed1.Scen4Radio

            If Scen1R IsNot Nothing Then
                If Scen1R = 1 Then
                    Scen1Mult = 1 + (Scen1Value * 0.01)
                End If
                If Scen1R = 2 Then
                    Scen1Mult = 1 - (Scen1Value * 0.01)
                End If
            End If

            If Scen2R IsNot Nothing Then
                If Scen2R = 1 Then
                    Scen2Mult = 1 + (Scen2Value * 0.01)
                End If
                If Scen2R = 2 Then
                    Scen2Mult = 1 - (Scen2Value * 0.01)
                End If
            End If

            If Scen3R IsNot Nothing Then
                If Scen3R = 1 Then
                    Scen3Mult = 1 + (Scen3Value * 0.01)
                End If
                If Scen3R = 2 Then
                    Scen3Mult = 1 - (Scen3Value * 0.01)
                End If
            End If

            If Scen4R IsNot Nothing Then
                If Scen4R = 1 Then
                    Scen4Mult = 1 + (Scen4Value * 0.01)
                End If
                If Scen4R = 2 Then
                    Scen4Mult = 1 - (Scen4Value * 0.01)
                End If
            End If

            For Each k In valQ
                List.Add(New CChartData With {.Year = k.year, .ValueS1 = k.amount, .ValueS2 = (k.amount * Scen1Mult),
                                              .ValueS3 = (k.amount * Scen2Mult), .ValueS4 = (k.amount * Scen3Mult),
                                              .ValueS5 = (k.amount * Scen4Mult)})
            Next

            Return View(List)

        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
