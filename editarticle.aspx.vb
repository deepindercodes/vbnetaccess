Imports System.Data
Imports System.Data.OleDb

Partial Class editarticle
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim id As Int32 = Convert.ToInt32(Request("id"))

            Dim objMDB As DbConn = New DbConn

            Dim objdbconn As OleDbConnection = New OleDbConnection(objMDB.DbConnection)

            Dim objda As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM tblarticles WHERE id=" & id & "", objdbconn)

            Dim objdt As DataTable = New DataTable
            objda.Fill(objdt)

            txtarticletitle.Text = objdt.Rows(0)("articletitle")
            txtarticleauthor.Text = objdt.Rows(0)("articleauthor")
            txtarticlebody.Text = objdt.Rows(0)("articlebody")
            hdnarticleimage.Value = objdt.Rows(0)("articleimage")

        End If
    End Sub



    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)

        Dim id As Int32 = Convert.ToInt32(Request("id"))

        Dim articletitle As String = txtarticletitle.Text

        Dim articleauthor As String = txtarticleauthor.Text

        Dim articlebody As String = txtarticlebody.Text

        Dim articleimage As String = hdnarticleimage.Value

        Dim articleExists As Boolean = False

        Dim objMDB As DbConn = New DbConn

        Dim objdbconn As OleDbConnection = New OleDbConnection(objMDB.DbConnection)

        objdbconn.Open()
        Dim comm As OleDbCommand = New OleDbCommand("UPDATE tblarticles SET articletitle='" & articletitle & "',articleauthor='" & articleauthor & "',articlebody='" & articlebody & "',articleimage='" & articleimage & "',modifiedonUTC='" & DateTime.UtcNow.ToString() & "' WHERE id=" & ID & "", objdbconn)
        comm.ExecuteNonQuery()
        objdbconn.Close()

        Response.Write("<script type='text/javascript'>parent.ArticleEdited();</script>")
        Response.End()

    End Sub

End Class
