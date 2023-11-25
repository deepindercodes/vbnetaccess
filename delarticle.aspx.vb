
Imports System.Data.OleDb

Partial Class delarticle
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id As Int32 = Convert.ToInt32(Request("id"))

        Dim objMDB As DbConn = New DbConn

        Dim objdbconn As OleDbConnection = New OleDbConnection(objMDB.DbConnection)

        objdbconn.Open()
        Dim comm As OleDbCommand = New OleDbCommand("DELETE FROM tblarticles WHERE id=" & id & "", objdbconn)
        comm.ExecuteNonQuery()
        objdbconn.Close()

        Response.Redirect("/")

    End Sub
End Class
