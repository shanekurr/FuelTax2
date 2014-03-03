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
    Public Class taxcolmoneyController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /taxcolmoney/
        Function Index() As ActionResult
            Return View(db.taxcolmoneys.ToList())
        End Function

        ' GET: /taxcolmoney/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim taxcolmoney As taxcolmoney = db.taxcolmoneys.Find(id)
            If IsNothing(taxcolmoney) Then
                Return HttpNotFound()
            End If
            Return View(taxcolmoney)
        End Function

        ' GET: /taxcolmoney/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /taxcolmoney/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,CountyN,AmountD")> ByVal taxcolmoney As taxcolmoney) As ActionResult
            If ModelState.IsValid Then
                db.taxcolmoneys.Add(taxcolmoney)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(taxcolmoney)
        End Function

        ' GET: /taxcolmoney/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim taxcolmoney As taxcolmoney = db.taxcolmoneys.Find(id)
            If IsNothing(taxcolmoney) Then
                Return HttpNotFound()
            End If
            Return View(taxcolmoney)
        End Function

        ' POST: /taxcolmoney/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,CountyN,AmountD")> ByVal taxcolmoney As taxcolmoney) As ActionResult
            If ModelState.IsValid Then
                db.Entry(taxcolmoney).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(taxcolmoney)
        End Function

        ' GET: /taxcolmoney/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim taxcolmoney As taxcolmoney = db.taxcolmoneys.Find(id)
            If IsNothing(taxcolmoney) Then
                Return HttpNotFound()
            End If
            Return View(taxcolmoney)
        End Function

        ' POST: /taxcolmoney/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim taxcolmoney As taxcolmoney = db.taxcolmoneys.Find(id)
            db.taxcolmoneys.Remove(taxcolmoney)
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
