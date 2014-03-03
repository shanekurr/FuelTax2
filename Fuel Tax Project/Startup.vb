Imports Owin
Imports Microsoft.Owin

<Assembly: OwinStartupAttribute(GetType(Global.Fuel_Tax_Project.Startup))> 

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        ConfigureAuth(app)
    End Sub
End Class
