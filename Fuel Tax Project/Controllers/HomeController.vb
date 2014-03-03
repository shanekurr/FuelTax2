Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Dim _db As fueltaxEntities = _
        New fueltaxEntities


    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function StateTotalG() As ActionResult
        ViewData("Message") = "Graph of State Highway Fund - Total Gallons"

        Return View()
    End Function

    Function StateGasolineG() As ActionResult
        ViewData("Message") = "Graph of State Highway Fund - Gasoline Gallons"
        Return View()
    End Function

    Function StateSpecialG()
        ViewData("Message") = "Graph of State Highway Fund - Special Fuels Gallons"
        Return View()
    End Function

    Function StateTotalR()
        ViewData("Message") = "Graph of State Highway Fund - Total Revenue"
        Return View()
    End Function

    Function StateGasolineR()
        ViewData("Message") = "Graph of State Highway Fund - Gasoline Revenue"
        Return View()
    End Function

    Function StateSpecialR()
        ViewData("Message") = "Graph of State Highway Fund - Special Fuels Revenue"
        Return View()
    End Function

    Function CountyTotalG()
        ViewData("Message") = "Graph of County - Total Gallons"
        Return View()
    End Function

    Function CountyGasolineG()
        ViewData("Message") = "Graph of County - Gasoline Gallons"
        Return View()
    End Function

    Function CountySpecialG()
        ViewData("Message") = "Graph of County - Special Fuels Gallons"
        Return View()
    End Function

    Function CountyTotalT()
        ViewData("Message") = "Graph of County - Total Tax"
        Return View()
    End Function

    Function PercentagesTG()
        ViewData("Message") = "North, South Rural Percentages Graph"
        Return View()
    End Function

    Function PercentagesG()
        ViewData("Message") = "North, South, Rural Percentages Graph"
        Return View()
    End Function

    Function PercentagesS()
        ViewData("Message") = "North, South, Rural Percentages Graph"
        Return View()
    End Function

    Function PercentagesTR()
        ViewData("Message") = "North, South, Rural Percentages Graph"
        Return View()
    End Function

    Function HistoricalData()
        ViewData("Message") = "Historical Data"
        Return View()
    End Function

    Function LinearRegression()
        ViewData("Message") = "Linear Regression Graph"
        Return View()
    End Function

    Function CustomScenarios()
        ViewData("Message") = "Custom Scenarios Graph"
        Return View()
    End Function

End Class
