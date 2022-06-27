Imports System.Data.SqlClient

Public Class Search

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click

        If ddlCategory.Text = "--Choose--" Then

            MsgBox("Choose a type to search")

            Exit Sub

        End If

        'Search(ddlCategory.Text)

    End Sub

    Private Function SearchAll(type As String)

        Dim strSQL As String

        If type = "Books" Then

            strSQL = "SELECT title FROM books"

        ElseIf type = "Publisher" Then

            strSQL = "SELECT publisher FROM books"

        ElseIf type = "Author" Then

            strSQL = "SELECT * FROM authors"

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
            sqlcmd = New SqlCommand(strSQL, sqlconn)

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

        If DdlSearchAll.Text = "--Choose--" Then

            MsgBox("Not quite")

            Exit Sub

        End If

        Dim ds As DataSet = SearchAll(DdlSearchAll.Text)

        MsgBox(ds.Tables(0).Rows(0).Item(0))

    End Sub

End Class