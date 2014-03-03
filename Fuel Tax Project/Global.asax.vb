Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing

' Note: For instructions on enabling IIS7 classic mode, 
' visit http://go.microsoft.com/fwlink/?LinkId=303675
Public Class MvcApplication
    Inherits System.Web.HttpApplication
    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class

