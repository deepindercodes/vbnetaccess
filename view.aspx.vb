
Imports System.Data
Imports System.Data.OleDb

Partial Class view
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id As Int32 = Convert.ToInt32(Request("id"))

        Dim objMDB As DbConn = New DbConn

        Dim objdbconn As OleDbConnection = New OleDbConnection(objMDB.DbConnection)

        Dim objda As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM tblarticles WHERE id=" & id & "", objdbconn)

        Dim objdt As DataTable = New DataTable
        objda.Fill(objdt)

        litarticletitle.Text = objdt.Rows(0)("articletitle")
        litarticleauthor.Text = objdt.Rows(0)("articleauthor")
        litarticlebody.Text = objdt.Rows(0)("articlebody")

        If objdt.Rows(0)("articleimage") & "" <> "" Then
            divimage.Visible = True
            imgarticle.ImageUrl = objdt.Rows(0)("articleimage")
        End If

        Page.Title = litarticletitle.Text

    End Sub
End Class
