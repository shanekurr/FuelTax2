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
    Public Class newsController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /news/
        Function Index() As ActionResult
            Return View(db.news.ToList())
        End Function

        ' GET: /news/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim news As news = db.news.Find(id)
            If IsNothing(news) Then
                Return HttpNotFound()
            End If
            Return View(news)
        End Function

        ' GET: /news/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /news/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Titre,contenu")> ByVal news As news) As ActionResult
            If ModelState.IsValid Then
                db.news.Add(news)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(news)
        End Function

        ' GET: /news/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim news As news = db.news.Find(id)
            If IsNothing(news) Then
                Return HttpNotFound()
            End If
            Return View(news)
        End Function

        ' POST: /news/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Titre,contenu")> ByVal news As news) As ActionResult
            If ModelState.IsValid Then
                db.Entry(news).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(news)
        End Function

        ' GET: /news/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim news As news = db.news.Find(id)
            If IsNothing(news) Then
                Return HttpNotFound()
            End If
            Return View(news)
        End Function

        ' POST: /news/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim news As news = db.news.Find(id)
            db.news.Remove(news)
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
