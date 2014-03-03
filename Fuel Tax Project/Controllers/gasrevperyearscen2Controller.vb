Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Fuel_Tax_Project
    <Authorize>
    Public Class gasrevperyearscen2Controller
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /gasrevperyearscen2/
        Function Index() As ActionResult
            Return View(db.gasrevperyearscen2.ToList())
        End Function

        ' GET: /gasrevperyearscen2/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen2 As gasrevperyearscen2 = db.gasrevperyearscen2.Find(id)
            If IsNothing(gasrevperyearscen2) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen2)
        End Function

        ' GET: /gasrevperyearscen2/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /gasrevperyearscen2/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,amount")> ByVal gasrevperyearscen2 As gasrevperyearscen2) As ActionResult
            If ModelState.IsValid Then
                db.gasrevperyearscen2.Add(gasrevperyearscen2)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevperyearscen2)
        End Function

        ' GET: /gasrevperyearscen2/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen2 As gasrevperyearscen2 = db.gasrevperyearscen2.Find(id)
            If IsNothing(gasrevperyearscen2) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen2)
        End Function

        ' POST: /gasrevperyearscen2/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,amount")> ByVal gasrevperyearscen2 As gasrevperyearscen2) As ActionResult
            If ModelState.IsValid Then
                db.Entry(gasrevperyearscen2).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevperyearscen2)
        End Function

        ' GET: /gasrevperyearscen2/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen2 As gasrevperyearscen2 = db.gasrevperyearscen2.Find(id)
            If IsNothing(gasrevperyearscen2) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen2)
        End Function

        ' POST: /gasrevperyearscen2/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim gasrevperyearscen2 As gasrevperyearscen2 = db.gasrevperyearscen2.Find(id)
            db.gasrevperyearscen2.Remove(gasrevperyearscen2)
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
