﻿Imports System.Data.SqlClient

Public Class Index

    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        InsertRecord()

    End Sub

    Public Sub InsertRecord()

        'grab the data
        Dim strTitle As String = txtTitle.Text
        Dim strAuthor As String = txtAuthor.Text
        Dim strPublisher As String = txtPublisher.Text
        Dim Intisbn As Double = Convert.ToDouble(txtISBN.Text)
        Dim intValue As Double = Convert.ToDouble(txtValue.Text)

        Dim AuthorID As String = String.Empty
        Dim BookID As String = String.Empty

        'grab data for the Authors table

        Dim AuthorArray As String() = Split(strAuthor)

        Call InsertAuthor(AuthorArray(0), AuthorArray(1))

        'send the data 

        Dim strconn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"
        Dim strSQL As String = "INSERT INTO books ([Title], [Publisher], [ISBN], [ESTValue]) VALUES ("
        strSQL &= "@title,@publisher,@isbn,@value)"
        Dim sqlCmd As SqlCommand
        Dim sqlConn As New SqlConnection(strconn)

        Try


            'open connection
            sqlConn.Open()
            sqlCmd = New SqlCommand(strSQL, sqlConn)

            With sqlCmd.Parameters

                .AddWithValue("@title", strTitle)
                .AddWithValue("@publisher", strPublisher)
                .AddWithValue("@isbn", Intisbn)
                .AddWithValue("@value", intValue)

            End With

            'execute query
            Dim i As Integer = sqlCmd.ExecuteNonQuery()

            'check if it failed
            If i = 0 Then

                Throw New System.Exception("An exception has occurred.")

            End If

            sqlConn.Close()


        Catch ex As Exception

            MsgBox("An Eror has occured (01)")

        End Try

        ClearForm()


        'set BookID                                
        BookID = setSessionID(strTitle, strAuthor, strPublisher, Intisbn, intValue)

        'set AuthorID

        AuthorID = getAuthorID(AuthorArray(0), AuthorArray(1))

        InsertBookAuthors(BookID, AuthorID)

        Response.Redirect("success.aspx")

    End Sub

    Public Sub InsertAuthor(Firstname As String, lastname As String)
        'send the data 

        Dim strconn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"
        Dim strSQL As String = "INSERT INTO authors ([FirstName], [LastName]) VALUES ("
        strSQL &= "@fname,@lname)"
        Dim sqlCmd As SqlCommand
        Dim sqlConn As New SqlConnection(strconn)

        Try


            'open connection
            sqlConn.Open()
            sqlCmd = New SqlCommand(strSQL, sqlConn)

            With sqlCmd.Parameters

                .AddWithValue("@fname", Firstname)
                .AddWithValue("@lname", lastname)
            End With

            'execute query
            Dim i As Integer = sqlCmd.ExecuteNonQuery()

            'check if it failed
            If i = 0 Then

                Throw New System.Exception("An exception has occurred.")

            End If

            sqlConn.Close()



        Catch ex As Exception

            MsgBox("An Eror has occured (03)")

        End Try


    End Sub


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

                Dim intID As Integer = ds.Tables(0).Rows(0).Item(0)

                'set session object

                Session("Bid") = intID

                'set return variable
                returnvariable = intID

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

        Return returnvariable

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

                intID(0) = ds.Tables(0).Rows(0).Item(0)
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

    End Function
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

        txtTitle.Text = "Some Title"
        txtAuthor.Text = "Some Author"
        txtPublisher.Text = "Some pb"
        txtISBN.Text = "1234567876"
        txtValue.Text = "1234"

    End Sub
End Class