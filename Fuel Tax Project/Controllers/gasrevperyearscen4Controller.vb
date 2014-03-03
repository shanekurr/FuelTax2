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
    Public Class gasrevperyearscen4Controller
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /gasrevperyearscen4/
        Function Index() As ActionResult
            Return View(db.gasrevperyearscen4.ToList())
        End Function

        ' GET: /gasrevperyearscen4/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen4 As gasrevperyearscen4 = db.gasrevperyearscen4.Find(id)
            If IsNothing(gasrevperyearscen4) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen4)
        End Function

        ' GET: /gasrevperyearscen4/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /gasrevperyearscen4/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,amount")> ByVal gasrevperyearscen4 As gasrevperyearscen4) As ActionResult
            If ModelState.IsValid Then
                db.gasrevperyearscen4.Add(gasrevperyearscen4)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevperyearscen4)
        End Function

        ' GET: /gasrevperyearscen4/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen4 As gasrevperyearscen4 = db.gasrevperyearscen4.Find(id)
            If IsNothing(gasrevperyearscen4) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen4)
        End Function

        ' POST: /gasrevperyearscen4/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,amount")> ByVal gasrevperyearscen4 As gasrevperyearscen4) As ActionResult
            If ModelState.IsValid Then
                db.Entry(gasrevperyearscen4).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevperyearscen4)
        End Function

        ' GET: /gasrevperyearscen4/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen4 As gasrevperyearscen4 = db.gasrevperyearscen4.Find(id)
            If IsNothing(gasrevperyearscen4) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen4)
        End Function

        ' POST: /gasrevperyearscen4/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim gasrevperyearscen4 As gasrevperyearscen4 = db.gasrevperyearscen4.Find(id)
            db.gasrevperyearscen4.Remove(gasrevperyearscen4)
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
