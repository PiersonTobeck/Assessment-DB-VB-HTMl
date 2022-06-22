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


        'create new sql statement
        Dim strSQL As String = "SELECT * FROM books"

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter

        Dim dss As DataSet()

        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            'run query for authors

            strSQL = "SELECT * FROM authors"
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds2)

            'run query for bookauthors

            strSQL = "SELECT * FROM bookauthors"
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds3)

            dss(0) = ds
            dss(1) = ds2
            dss(2) = ds3
        Catch ex As Exception

            MsgBox("An Eror has occured (02)")

        Finally

            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()
            ds2.Dispose()
            ds3.Dispose()

            'check connection status and close

            If sqlconn.State = ConnectionState.Open Then

                sqlconn.Close()

            End If

        End Try

        Return dss

    End Function

    Protected Sub BtnSearchAll_Click(sender As Object, e As EventArgs) Handles BtnSearchAll.Click

        If DdlSearchAll.Text = "--choose--" Then

            MsgBox("Not quite")

            Exit Sub

        End If

        Dim dataset = SearchAll(DdlSearchAll.Text)

    End Sub

End Class