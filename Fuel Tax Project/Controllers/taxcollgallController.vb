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
    Public Class taxcollgallController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /taxcollgall/
        Function Index() As ActionResult
            Return View(db.taxcollgalls.ToList())
        End Function

        ' GET: /taxcollgall/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim taxcollgall As taxcollgall = db.taxcollgalls.Find(id)
            If IsNothing(taxcollgall) Then
                Return HttpNotFound()
            End If
            Return View(taxcollgall)
        End Function

        ' GET: /taxcollgall/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /taxcollgall/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,month,CountyN,Diesel,CNG,LPG,A55")> ByVal taxcollgall As taxcollgall) As ActionResult
            If ModelState.IsValid Then
                db.taxcollgalls.Add(taxcollgall)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(taxcollgall)
        End Function

        ' GET: /taxcollgall/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim taxcollgall As taxcollgall = db.taxcollgalls.Find(id)
            If IsNothing(taxcollgall) Then
                Return HttpNotFound()
            End If
            Return View(taxcollgall)
        End Function

        ' POST: /taxcollgall/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,month,CountyN,Diesel,CNG,LPG,A55")> ByVal taxcollgall As taxcollgall) As ActionResult
            If ModelState.IsValid Then
                db.Entry(taxcollgall).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(taxcollgall)
        End Function

        ' GET: /taxcollgall/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim taxcollgall As taxcollgall = db.taxcollgalls.Find(id)
            If IsNothing(taxcollgall) Then
                Return HttpNotFound()
            End If
            Return View(taxcollgall)
        End Function

        ' POST: /taxcollgall/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim taxcollgall As taxcollgall = db.taxcollgalls.Find(id)
            db.taxcollgalls.Remove(taxcollgall)
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
