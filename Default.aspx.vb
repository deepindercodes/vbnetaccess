
Imports System.Data
Imports System.Data.OleDb

Partial Class _Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim objMDB As DbConn = New DbConn

            Dim objdbconn As OleDbConnection = New OleDbConnection(objMDB.DbConnection)

            Dim objda As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM tblarticles WHERE status='E' ORDER BY id", objdbconn)

            Dim objdt As DataTable = New DataTable
            objda.Fill(objdt)

            If objdt.Rows.Count <> 0 Then

                reparticles.DataSource = objdt
                reparticles.DataBind()

            End If

        End If

    End Sub

End Class
