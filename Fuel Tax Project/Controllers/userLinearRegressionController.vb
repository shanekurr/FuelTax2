Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    Public Class userLinearRegressionController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /userLinearRegression/
        Function Index() As ActionResult
            Dim List As New List(Of SelectListItem)
            Dim dateNow As Integer
            dateNow = Date.Today.Year

            List.Add(New SelectListItem With {.Text = "Select a Year", .Value = 0}) ' Adds first value as "Select a Year"
            Dim valQ = From y In db.gasrevperyears _
                       Where y.year >= dateNow
                       Select y.year, y.ID _
                       Order By year

            For Each k In valQ
                List.Add(New SelectListItem With {.Text = k.year, .Value = k.year})
            Next


            ViewData("endDD") = List

            Return View()
        End Function

        Function Chart(ed1 As DropDownData) As ActionResult
            'This is where the code to build the chart should be

            Dim startYear, endYear As Integer
            startYear = 1990
            endYear = ed1.endDD
            Dim dateNow As Integer
            dateNow = Date.Today.Year

            Dim List As New List(Of CChartData)
            Dim yearList As New List(Of Integer)
            Dim amountList As New List(Of Integer)
            Dim size, oldSize As Integer
            Dim amountMean, yearMean, d, c, a, b, beta1, beta0, yearCurr, newSize As Double
            size = 0

            Dim valQ = From y In db.gasrevperyears
                        Where y.year >= startYear AndAlso endYear >= y.year
                        Select y.year, y.amount
                        Order By year

            For Each k In valQ
                List.Add(New CChartData With {.Year = k.year, .ValueS1 = k.amount})
                yearList.Add(k.year)
                amountList.Add(k.amount)
                size = size + 1
            Next

            amountMean = Mean(amountList, size)
            yearMean = Mean(yearList, size)

            d = 0
            c = 0

            For i As Integer = 0 To (size - 1)
                a = yearList(i) - yearMean
                b = amountList(i) - amountMean
                d = d + (a * b)
                c = c + (a * a)
            Next

            beta1 = d / c
            beta0 = amountMean - (beta1 * (yearMean - startYear))

            yearCurr = startYear
            newSize = endYear - startYear + 1
            oldSize = dateNow - startYear + 1
            Dim newList As New List(Of Double)



            For k As Integer = 0 To (newSize - 1)
                yearList(k) = yearCurr
                newList.Add(beta0 + (k * beta1))
                yearCurr = yearCurr + 1
            Next

            'For Each k In newList
            'newList(k) = Math.Round(newList(k))
            'Next

            Dim testList As New List(Of CChartData)

            For k As Integer = 0 To (newSize - 1)
                testList.Add(New CChartData With {.Year = yearList(k), .newVal = Math.Round(newList(k)), .size = oldSize, .newSize = newSize, .oldVal = amountList(k)})
            Next

            For k As Integer = oldSize To (newSize - 1)
                testList(k).oldVal = Nothing
            Next

            Return View(testList)
        End Function

        Function Mean(list As List(Of Integer), size As Integer)
            Dim sum, mean1 As Double
            sum = 0
            For Each k In list
                sum = sum + k
            Next
            mean1 = sum / size
            Return mean1
        End Function

    End Class
End Namespace
