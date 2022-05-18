Imports System.Data.SqlClient

Public Class Index

    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim Duplicatebook As Integer = CheckDuplicateBook(txtISBN.Text)
        Dim duplicateauthor As Integer = CheckDuplicateAuthor(txtISBN.Text)
        Dim currentBook As New Book(txtTitle.Text, txtAuthor.Text, txtPublisher.Text, txtISBN.Text, txtValue.Text)
        Dim CurrentAuthor As New Author(txtAuthor.Text)
        Dim bookID As Integer = 0
        Dim AuthorID As Integer = 0

        If Duplicatebook = 0 Then

            currentBook.InsertBook()

            If duplicateauthor = 0 Then

                CurrentAuthor.InsertAuthor()

            End If

        End If

        ClearForm()
        'currentBook.insertbookauthors
    End Sub

    Public Function CheckDuplicateBook(isbn As Integer) As Integer


        Return Nothing
    End Function

    Public Function CheckDuplicateAuthor(aid As Integer) As Integer


        Return Nothing
    End Function

    Private Function setSessionID(strTitle As String, strAuthor As String, strPublisher As String, intISBN As Double, intValue As Double) As Integer

        'create new sql statement
        Dim strSQL As String = "SELECT Bid FROM books where [Title] = @title AND [Publisher] = @publisher AND [ISBN] = @isbn AND [EstValue] = @value"



        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        Dim returnvariable As Integer = -1

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'complete query
            With sqlcmd.Parameters

                .AddWithValue("@title", strTitle)
                .AddWithValue("@publisher", strPublisher)
                .AddWithValue("@isbn", intISBN)
                .AddWithValue("@value", intValue)

            End With

            'run query and fill ds

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            'check a row has been returned

            If ds.Tables(0).Rows.Count > 0 Then

                Dim ISBNID As Integer = ds.Tables(0).Rows(0).Item(3)

                'set session object

                Session("Bid") = ISBNID

                'set return variable
                returnvariable = ISBNID

            End If

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

        Return returnvariable

    End Function

    Private Function getAuthorID(firstname, lastname)

        Dim strSQL As String = "SELECT Aid from authors where [FirstName] = @fname AND [LastName] = @lname"

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        Dim returnvariable

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'complete query
            With sqlcmd.Parameters

                .AddWithValue("@fname", firstname)
                .AddWithValue("@lname", lastname)

            End With

            'run query and fill ds

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            'check a row has been returned

            If ds.Tables(0).Rows.Count > 0 Then

                Dim intID As Integer = ds.Tables(0).Rows(0).Item(0)

                'set session object

                Session("Aid") = intID

                'set return variable
                returnvariable = intID

            End If

        Catch ex As Exception

            MsgBox("An Eror has occured (04)")

        Finally

            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

            'check connection status and close

            If sqlconn.State = ConnectionState.Open Then

                sqlconn.Close()

            End If

        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return returnvariable
#Enable Warning BC42104 ' Variable is used before it has been assigned a value

    End Function

    Private Function getAuthorBooks()

        Dim strSQL As String = "SELECT * from authorbooks where [FirstName] = @fname AND [LastName] = @lname"

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"


        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet
        Dim intID As Integer()

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill ds

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            'check a row has been returned

            If ds.Tables(0).Rows.Count > 0 Then

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                intID(0) = ds.Tables(0).Rows(0).Item(0)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                intID(1) = ds.Tables(0).Rows(1).Item(0)

                'set session object

                Session("ABid") = intID


            End If

        Catch ex As Exception

            MsgBox("An Eror has occured (07)")

        Finally

            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

            'check connection status and close

            If sqlconn.State = ConnectionState.Open Then

                sqlconn.Close()

            End If

        End Try

#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
    Private Sub InsertBookAuthors(BookID As Integer, AuthorID As Integer)

        'send the data 

        Dim strconn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"
        Dim strSQL As String = "INSERT INTO bookauthors ([AID], [BID]) VALUES ("
        strSQL &= "@aid,@bid)"
        Dim sqlCmd As SqlCommand
        Dim sqlConn As New SqlConnection(strconn)

        Try


            'open connection
            sqlConn.Open()
            sqlCmd = New SqlCommand(strSQL, sqlConn)

            With sqlCmd.Parameters

                .AddWithValue("@aid", AuthorID)
                .AddWithValue("@bid", BookID)


            End With

            'execute query
            Dim i As Integer = sqlCmd.ExecuteNonQuery()

            'check if it failed
            If i = 0 Then

                Throw New System.Exception("An exception has occurred.")

            End If

            sqlConn.Close()



        Catch ex As Exception

            MsgBox("An Eror has occured (05)")

        End Try

    End Sub

    Public Sub ClearForm()

        txtTitle.Text = String.Empty
        txtAuthor.Text = String.Empty
        txtPublisher.Text = String.Empty
        txtISBN.Text = String.Empty
        txtValue.Text = String.Empty

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'submitdata()


    End Sub

    Public Sub submitdata()

        txtTitle.Text = "Some Title"
        txtAuthor.Text = "Some Author"
        txtPublisher.Text = "Some pb"
        txtISBN.Text = "1234567876"
        txtValue.Text = "1234"
    End Sub

End Class