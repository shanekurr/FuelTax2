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
    Public Class gasrevtohwyfndController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /gasrevtohwyfnd/
        Function Index() As ActionResult
            Return View(db.gasrevtohwyfnds.ToList())
        End Function

        ' GET: /gasrevtohwyfnd/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevtohwyfnd As gasrevtohwyfnd = db.gasrevtohwyfnds.Find(id)
            If IsNothing(gasrevtohwyfnd) Then
                Return HttpNotFound()
            End If
            Return View(gasrevtohwyfnd)
        End Function

        ' GET: /gasrevtohwyfnd/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /gasrevtohwyfnd/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,month,amount,total")> ByVal gasrevtohwyfnd As gasrevtohwyfnd) As ActionResult
            If ModelState.IsValid Then
                db.gasrevtohwyfnds.Add(gasrevtohwyfnd)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevtohwyfnd)
        End Function

        ' GET: /gasrevtohwyfnd/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevtohwyfnd As gasrevtohwyfnd = db.gasrevtohwyfnds.Find(id)
            If IsNothing(gasrevtohwyfnd) Then
                Return HttpNotFound()
            End If
            Return View(gasrevtohwyfnd)
        End Function

        ' POST: /gasrevtohwyfnd/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,month,amount,total")> ByVal gasrevtohwyfnd As gasrevtohwyfnd) As ActionResult
            If ModelState.IsValid Then
                db.Entry(gasrevtohwyfnd).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasrevtohwyfnd)
        End Function

        ' GET: /gasrevtohwyfnd/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasrevtohwyfnd As gasrevtohwyfnd = db.gasrevtohwyfnds.Find(id)
            If IsNothing(gasrevtohwyfnd) Then
                Return HttpNotFound()
            End If
            Return View(gasrevtohwyfnd)
        End Function

        ' POST: /gasrevtohwyfnd/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim gasrevtohwyfnd As gasrevtohwyfnd = db.gasrevtohwyfnds.Find(id)
            db.gasrevtohwyfnds.Remove(gasrevtohwyfnd)
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
