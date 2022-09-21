Imports System.Data.SqlClient
Public Class Search

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Function SearchAll(type As String)


        Dim strSQL As String

        'check for type of input

        If type = "Author" Then

            strSQL = "SELECT * FROM authors"

        End If

        If type = "Book" Then

            strSQL = "SELECT * FROM books"

        End If

        If type = "Publisher" Then

            strSQL = "SELECT DISTINCT Publisher FROM BOOKS"

        End If

        'create new sql statement
        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter

        Dim ds As New DataSet

        Try
            'open connection
            sqlconn.Open()
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            sqlcmd = New SqlCommand(strSQL, sqlconn)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

        Catch ex As Exception

            MsgBox("An Eror has occured (02)")

        Finally

            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

            'check connection status and close

            If sqlconn.State = ConnectionState.Open Then

                sqlconn.Close()

            End If

        End Try

        Return ds

    End Function

    Protected Sub BtnSearchAll_Click(sender As Object, e As EventArgs) Handles BtnSearchAll.Click

        'simple search function

        If DdlSearchAll.Text = "--Choose--" Then

            MsgBox("Not quite")

            Exit Sub

        End If

        Session("Search") = SearchAll(DdlSearchAll.Text)

        Session("Type") = DdlSearchAll.Text

        Response.Redirect("results.aspx")


    End Sub

End Class