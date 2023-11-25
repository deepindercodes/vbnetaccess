Imports System.Data
Imports System.Data.OleDb

Partial Class addnewarticle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        diverror.Visible = False
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

        Dim articletitle As String = txtarticletitle.Text

        Dim articleauthor As String = txtarticleauthor.Text

        Dim articlebody As String = txtarticlebody.Text

        Dim articleimage As String = hdnarticleimage.Value

        Dim articleExists As Boolean = False

        Dim objMDB As DbConn = New DbConn

        Dim objdbconn As OleDbConnection = New OleDbConnection(objMDB.DbConnection)

        Dim objda As OleDbDataAdapter = New OleDbDataAdapter("SELECT id FROM tblarticles WHERE articletitle=@articletitle", objdbconn)
        objda.SelectCommand.Parameters.Add(New OleDbParameter("@articletitle", articletitle))

        Dim objdt As DataTable = New DataTable
        objda.Fill(objdt)

        If objdt.Rows.Count <> 0 Then

            articleExists = True

        End If

        If articleExists = True Then

            lblerror.Text = "Article Already Exists."
            diverror.Visible = True

        Else

            objdbconn.Open()
            Dim comm As OleDbCommand = New OleDbCommand("INSERT INTO tblarticles (articletitle,articleauthor,articlebody,articleimage,status,createdonUTC) VALUES (@articletitle,@articleauthor,@articlebody,@articleimage,'E','" & DateTime.UtcNow.ToString() & "');", objdbconn)
            comm.Parameters.Add(New OleDbParameter("@articletitle", articletitle))
            comm.Parameters.Add(New OleDbParameter("@articleauthor", articleauthor))
            comm.Parameters.Add(New OleDbParameter("@articlebody", articlebody))
            comm.Parameters.Add(New OleDbParameter("@articleimage", articleimage))
            comm.ExecuteNonQuery()
            objdbconn.Close()

            Response.Write("<script type='text/javascript'>parent.newArticleAdded();</script>")
            Response.End()

        End If



    End Sub


End Class
