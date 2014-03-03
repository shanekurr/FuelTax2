Imports Microsoft.AspNet.Identity.EntityFramework

' You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits User

End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContextWithCustomUser(Of ApplicationUser)
End Class