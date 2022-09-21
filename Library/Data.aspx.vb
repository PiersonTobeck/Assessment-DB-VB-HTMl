Imports System.Data.SqlClient
Public Class Data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'create variables and grab information from previous page

        Dim Id = Request.QueryString("id")

        Dim Type = Request.QueryString("type")

        Dim title = Request.QueryString("title")

        Dim bookinfo As ArrayList

        Dim pubinfo As ArrayList

        Dim authinfo As ArrayList

        Dim isbn As String

        ' user accidentally accessed this page

        If Id = Nothing And Type = Nothing And title = Nothing Then

            Response.Redirect("Index.aspx")

        End If

        ' select type and do applicable subroutines

        If Type = "Book" Then

            bookinfo = displaybookinfo(Type, Id)

            isbn = findisbn(Id)

            actuallydisplay(bookinfo, Type, title, isbn)

        ElseIf Type = "Publisher" Then

                pubinfo = displaypubinfo(Type, title)

            actuallydisplay(pubinfo, Type, title, Nothing)

        ElseIf Type = "Author" Then

                authinfo = displayauthinfo(Type, Id)

            actuallydisplay(authinfo, Type, title, Nothing)

        End If


    End Sub

    Public Function displaybookinfo(type, id) As ArrayList

        Dim strSQL As String = "SELECT AID FROM bookauthors WHERE [BID] = " & id

        'create new sql statement
        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter

        Dim ds As New DataSet

        Dim names As New ArrayList() 'String()
        Dim AIDs As New ArrayList

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                AIDs.Add(ds.Tables(0).Rows(i).ItemArray(0))

            Next

        Catch ex As Exception

            MsgBox("An Eror has occured (02)")

        Finally
            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

            ds.Clear()

        End Try

        For i As Integer = 0 To AIDs.Count - 1

            strSQL = "SELECT FirstName, Lastname FROM authors WHERE [Aid] = " & AIDs(i)

            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            For x As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 2

#Disable Warning BC42104 ' Variable is used before it has been assigned a value

                'fill the list of names for putting into table

                names.Add(ds.Tables(0).Rows(i).ItemArray(1).ToString)  '.ItemArray(1).ToString

                names.Add(ds.Tables(0).Rows(i).ItemArray(2).ToString) '.ItemArray(2).ToString

#Enable Warning BC42104 ' Variable is used before it has been assigned a value

            Next

        Next

        'Catch ex As Exception

        ' MsgBox("An Eror has occured (09)")

        'Finally

        If sqlconn.State = ConnectionState.Open Then

            sqlconn.Close()

        End If

        'End Try

        Return names

    End Function

    Public Function displaypubinfo(type, title) As ArrayList

        Dim strSQL As String = "SELECT Title FROM books WHERE [Publisher] = '" & title & "'"

        'create new sql statement
        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter

        Dim ds As New DataSet

        Dim names As New ArrayList() 'String()

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                names.Add(ds.Tables(0).Rows(i).ItemArray(0))

            Next

        Catch ex As Exception

            MsgBox("An Eror has occured (02)")

        Finally
            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

        End Try

        If sqlconn.State = ConnectionState.Open Then

            sqlconn.Close()

        End If

        'End Try

        Return names

    End Function

    Public Function displayauthinfo(type, id) As ArrayList


        Dim strSQL As String = "SELECT * FROM bookauthors"

        'create new sql statement
        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter

        Dim ds As New DataSet
        Dim ds2 As New DataSet

        Dim names As New ArrayList() 'String()
        Dim BIDs As New ArrayList

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)


            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                If ds.Tables(0).Rows(i).ItemArray(1) = id Then

                    BIDs.Add(ds.Tables(0).Rows(i).ItemArray(0))

                End If

            Next

            sqlDA.Dispose()
            ds.Clear()
            ds.Dispose()

        Catch ex As Exception

            MsgBox("An Eror has occured (02)")

        End Try

        For i As Integer = 0 To BIDs.Count - 1

            strSQL = "SELECT * FROM books WHERE [Bid] = " & BIDs(i)

            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds2)

            names.Add(ds2.Tables(0).Rows(0).ItemArray(1))

            ds2.Clear()

        Next

        ds2.Dispose()

        'Catch ex As Exception

        ' MsgBox("An Eror has occured (09)")

        'Finally

        If sqlconn.State = ConnectionState.Open Then

            sqlconn.Close()

        End If

        'End Try

        Return names

    End Function

    Public Sub actuallydisplay(names As ArrayList, type As String, Title As String, isbn As String)

        If type = "Book" Then

            Dim ids As New ArrayList

            'stringbuilder to create table

            Dim strBuilder As StringBuilder = New StringBuilder()

                'create table

                strBuilder.Append("<table class =""results"">")

                'add table header row

                strBuilder.Append("<tr class =""results"">")
            strBuilder.Append("<th class=""results""> " & "Authors of " & Title & " </th>")
            strBuilder.Append("<th class=""isbn""> ISBN </th>")

            'close header row
            strBuilder.Append("</tr>")

            'add table data row
            Dim numAuthors As Integer = (names.Count - 1) / 2

            For i As Integer = 0 To numAuthors Step 2

                Dim firstname As String = names(i)

                firstname = firstname.Replace(" ", String.Empty)

                Dim lastname As String = names(i + 1)

                lastname = lastname.Replace(" ", String.Empty)

                ids.Add(searchforAid(firstname, lastname, type))

                ids.Add(Nothing)

                strBuilder.Append("<tr class=""results"">")
                strBuilder.Append("<td class=""results""><a href='data.aspx?id=" & ids(i) & "&type=Author&title=" & firstname & " " & lastname & "'</a>" & firstname & " " & lastname & "</td>")

                If numAuthors = 1 Then
                    strBuilder.Append("<td class=""isbn"">" & isbn & "</td>")
                ElseIf i = 0 Then
                    strBuilder.Append("<td class=""isbn"" rowspan=""" & numAuthors & """>" & isbn & "</td>")

                End If

                'close table row& " 
                strBuilder.Append("</tr>")

            Next

            'add Table header row

            'strBuilder.Append("<tr class =""isbn"">")


            'close Header row
            'strBuilder.Append("</tr>")

            'add Table data row
            'strBuilder.Append("<tr class=""isbn"">")

            'close Table row& " 
            'strBuilder.Append("</tr>")

            '    close table and add to placeholder
            '    strBuilder.Append("</table>")

            plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

            strBuilder.Clear()

        End If

        If type = "Author" Then

            Dim ids As New ArrayList

            Try
                'stringbuilder to create table

                Dim strBuilder As StringBuilder = New StringBuilder()

                'create table

                strBuilder.Append("<table class =""results"">")

                'add table header row

                strBuilder.Append("<tr class =""results"">")
                strBuilder.Append("<th class=""results""> " & "Books by " & Title & " </th>")

                'close header row
                strBuilder.Append("</tr>")

                'add table data row

                For i As Integer = 0 To names.Count - 1

                    ids.Add(searchforBid(names(i), type))


                    strBuilder.Append("<tr class=""results"">")
                    strBuilder.Append("<td class=""results""><a href='data.aspx?id=" & ids(i) & "&type=Book&title=" & names(i) & "'</a>" & names(i) & "</td>")
            'close table row& " 
            strBuilder.Append("</tr>")

            Next

                'close table and add to placeholder
                strBuilder.Append("</table>")

                plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

                strBuilder.Clear()

            Catch ex As Exception


            End Try


        End If

        If type = "Publisher" Then

            Dim ids As New ArrayList

            Try
                'stringbuilder to create table

                Dim strBuilder As StringBuilder = New StringBuilder()

                'create table

                strBuilder.Append("<table class =""results"">")

                'add table header row

                strBuilder.Append("<tr class =""results"">")
                strBuilder.Append("<th class=""results""> " & "Books by " & Title & " </th>")

                'close header row
                strBuilder.Append("</tr>")

                'add table data row

                For i As Integer = 0 To names.Count - 1

                    ids.Add(searchforBid(names(i), type))

                    For x As Integer = 0 To names.Count - 1
                        'If names(i) = names(x)s Then

                        '    ids.Remove(x)


                        'End If

                    Next



                    strBuilder.Append("<tr class=""results"">")
                    strBuilder.Append("<td class=""results""><a href='data.aspx?id=" & ids(i) & "&type=Book&title=" & names(i) & "'</a>" & names(i) & "</td>")
                    'close table row& " 
                    strBuilder.Append("</tr>")

                Next

                'close table and add to placeholder
                strBuilder.Append("</table>")

                plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

                strBuilder.Clear()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Function searchforAid(firstname As String, lastname As String, type As String)

        Dim strSQL As String = "SELECT Aid FROM Authors WHERE [FirstName] = '" & firstname & "' AND [LastName] = '" & lastname & "'"

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

        End Try

        Return ds.Tables(0).Rows(0).ItemArray(0)

    End Function

    Public Function searchforBid(title, type)

        Dim strSQL As String = "SELECT Bid FROM books WHERE [title] = '" & title & "'"

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

        End Try

        Return ds.Tables(0).Rows(0).ItemArray(0)


    End Function

    Public Function findisbn(id As Integer) As String


        Dim strSQL As String = "SELECT ISBN FROM books WHERE [Bid] = '" & id & "'"

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

        End Try

        Return ds.Tables(0).Rows(0).ItemArray(0)


    End Function

End Class