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
    Public Class gasrevperyearscen5Controller
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /gasrevperyear5/
        Function Index() As ActionResult
            Return View(db.gasrevperyearscen5.ToList())
        End Function

        ' GET: /gasrevperyear5/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen5 As gasrevperyearscen5 = db.gasrevperyearscen5.Find(id)
            If IsNothing(gasrevperyearscen5) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen5)
        End Function

        ' GET: /gasrevperyear5/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /gasrevperyear5/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,amount")> ByVal gasrevperyearscen5 As gasrevperyearscen5) As ActionResult
            If ModelState.IsValid Then
                db.gasrevperyearscen5.Add(gasrevperyearscen5)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevperyearscen5)
        End Function

        ' GET: /gasrevperyear5/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen5 As gasrevperyearscen5 = db.gasrevperyearscen5.Find(id)
            If IsNothing(gasrevperyearscen5) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen5)
        End Function

        ' POST: /gasrevperyear5/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,amount")> ByVal gasrevperyearscen5 As gasrevperyearscen5) As ActionResult
            If ModelState.IsValid Then
                db.Entry(gasrevperyearscen5).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevperyearscen5)
        End Function

        ' GET: /gasrevperyear5/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevperyearscen5 As gasrevperyearscen5 = db.gasrevperyearscen5.Find(id)
            If IsNothing(gasrevperyearscen5) Then
                Return HttpNotFound()
            End If
            Return View(gasrevperyearscen5)
        End Function

        ' POST: /gasrevperyear5/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim gasrevperyearscen5 As gasrevperyearscen5 = db.gasrevperyearscen5.Find(id)
            db.gasrevperyearscen5.Remove(gasrevperyearscen5)
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
