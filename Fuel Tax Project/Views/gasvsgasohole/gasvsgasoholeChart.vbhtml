@ModelType IEnumerable(Of gasvsgasohole)
@Code
    ViewData("Title") = "Index"

End Code



@Code
    Dim db = Database.Open("fueltax")
    Dim dbdata = db.Query("SELECT year, total FROM gasvsgasohole")
    Dim myChart = New Chart(600, 400)
    myChart.AddTitle("Testing")
    myChart.DataBindTable(dbdata, "year")
    myChart.Write()
End Code