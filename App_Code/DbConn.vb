Public Class DbConn

    Public Function DbConnection() As String

        Dim dbPath As String = HttpContext.Current.Server.MapPath("/db/vbnetaccessdb.MDB")

        Dim dbConnectionString As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath & ""

        Return dbConnectionString

    End Function

End Class
