Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Helpers

Namespace Fuel_Tax_Project
    <Authorize>
    Public Class gasvsgasoholeController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /gasvsgasohole/
        Function Index() As ActionResult
            Return View(db.gasvsgasoholes.ToList())
        End Function

        ' GET: /gasvsgasohole/Details/5
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

        ' GET: /gasvsgasohole/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /gasvsgasohole/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,gasoline,gasohole,total")> ByVal gasvsgasohole As gasvsgasohole) As ActionResult
            If ModelState.IsValid Then
                db.gasvsgasoholes.Add(gasvsgasohole)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasvsgasohole)
        End Function

        ' GET: /gasvsgasohole/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasvsgasohole As gasvsgasohole = db.gasvsgasoholes.Find(id)
            If IsNothing(gasvsgasohole) Then
                Return HttpNotFound()
            End If
            Return View(gasvsgasohole)
        End Function

        ' GET: /gasvsgasohole/DrawChart/5
        Function DrawChart(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim gasvsgasohole As gasvsgasohole = db.gasvsgasoholes.Find(id)

            'Start Chart
            'Dim dbdata = Database.Query("SELECT year, total FROM gasvsgasohole")
            'Dim myChart = New Chart(600, 400)
            'myChart.AddTitle("Testing")
            'myChart.DataBindTable(dbdata, "year")
            'myChart.Write()
            'End Chart
            If IsNothing(gasvsgasohole) Then
                Return HttpNotFound()
            End If
            Return View(gasvsgasohole)
        End Function



        ' POST: /gasvsgasohole/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,gasoline,gasohole,total")> ByVal gasvsgasohole As gasvsgasohole) As ActionResult
            If ModelState.IsValid Then
                db.Entry(gasvsgasohole).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasvsgasohole)
        End Function

        ' GET: /gasvsgasohole/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasvsgasohole As gasvsgasohole = db.gasvsgasoholes.Find(id)
            If IsNothing(gasvsgasohole) Then
                Return HttpNotFound()
            End If
            Return View(gasvsgasohole)
        End Function

        ' POST: /gasvsgasohole/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim gasvsgasohole As gasvsgasohole = db.gasvsgasoholes.Find(id)
            db.gasvsgasoholes.Remove(gasvsgasohole)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
