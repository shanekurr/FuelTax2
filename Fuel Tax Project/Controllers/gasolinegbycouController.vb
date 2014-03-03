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
    Public Class gasolinegbycouController
        Inherits System.Web.Mvc.Controller

        Private db As New fueltaxEntities

        ' GET: /gasolinegbycou/
        Function Index() As ActionResult
            ' Dim List As New List(Of db.gasrevperyear.year)
            Return View(db.gasolinegbycous.ToList())
        End Function

        ' GET: /gasolinegbycou/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasolinegbycou As gasolinegbycou = db.gasolinegbycous.Find(id)
            If IsNothing(gasolinegbycou) Then
                Return HttpNotFound()
            End If
            Return View(gasolinegbycou)
        End Function

        ' GET: /gasolinegbycou/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /gasolinegbycou/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,year,month,CountyN,Gallon,perTotal")> ByVal gasolinegbycou As gasolinegbycou) As ActionResult
            If ModelState.IsValid Then
                db.gasolinegbycous.Add(gasolinegbycou)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasolinegbycou)
        End Function

        ' GET: /gasolinegbycou/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasolinegbycou As gasolinegbycou = db.gasolinegbycous.Find(id)
            If IsNothing(gasolinegbycou) Then
                Return HttpNotFound()
            End If
            Return View(gasolinegbycou)
        End Function

        ' POST: /gasolinegbycou/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,year,month,CountyN,Gallon,perTotal")> ByVal gasolinegbycou As gasolinegbycou) As ActionResult
            If ModelState.IsValid Then
                db.Entry(gasolinegbycou).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(gasolinegbycou)
        End Function

        ' GET: /gasolinegbycou/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim gasolinegbycou As gasolinegbycou = db.gasolinegbycous.Find(id)
            If IsNothing(gasolinegbycou) Then
                Return HttpNotFound()
            End If
            Return View(gasolinegbycou)
        End Function

        ' POST: /gasolinegbycou/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim gasolinegbycou As gasolinegbycou = db.gasolinegbycous.Find(id)
            db.gasolinegbycous.Remove(gasolinegbycou)
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
