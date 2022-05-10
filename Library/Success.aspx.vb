Imports System.Data.SqlClient
Public Class Success
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'stringbuilder to create table

            Dim strBuilder As StringBuilder = New StringBuilder()

            'create table

            strBuilder.Append("<table class =""results"">")

            'add table header row

            strBuilder.Append("<tr class =""results"">")
            strBuilder.Append("<th class=""results""> Title </th>")
            strBuilder.Append("<th class=""results""> Author </th>")
            strBuilder.Append("<th class=""results""> Publisher </th>")
            strBuilder.Append("<th class=""results""> ISBN </th>")
            strBuilder.Append("<th class=""results""> Value </th>")

            'close header row
            strBuilder.Append("</tr>")

            'add table data row
            Dim ds As DataSet = Querydb()
            Dim dsAuthors As DataSet = QuerydbAuthor()
            Dim dsBookAuthors As DataSet = Querydbbookauthors()

            For Each row As DataRow In ds.Tables(0).Rows

                strBuilder.Append("<tr class=""results"">")
                strBuilder.Append("<td class=""results"">" & row(1) & "</td>")
                strBuilder.Append("<td class=""results"">" & " " & "</td>")
                strBuilder.Append("<td class=""results"">" & row(2) & "</td>")
                strBuilder.Append("<td class=""results"">" & row(3) & "</td>")
                strBuilder.Append("<td class=""results"">" & row(4) & "</td>")

                'close table row
                strBuilder.Append("</tr>")

            Next

            'close table and add to placeholder
            strBuilder.Append("</table>")

            plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

            strBuilder.Clear()

        Catch ex As Exception

            Response.Redirect("index.aspx")

        End Try
    End Sub

    Private Function Querydb() As DataSet

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        'create new sql statement
        Dim strSQL As String = "SELECT * FROM books WHERE [Bid] = " & Session("Bid")

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill ds
            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

        Catch ex As Exception
            'error message

            MsgBox("An Eror has occured (06)")

            Response.Redirect("Index.aspx")

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

    Private Function QuerydbAuthor() As DataSet

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        'create new sql statement
        Dim strSQL As String = "SELECT * FROM authors WHERE [Aid] =  " & Session("Aid")

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill ds
            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

        Catch ex As Exception
            'error message

            MsgBox("An Eror has occured (07)")

            Response.Redirect("Index.aspx")

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

    Private Function Querydbbookauthors() As DataSet

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        'create new sql statement
        Dim strSQL As String = "SELECT * FROM bookauthors"

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill ds
            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

        Catch ex As Exception
            'error message

            MsgBox("An Eror has occured (08)")

            Response.Redirect("Index.aspx")

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

End Class