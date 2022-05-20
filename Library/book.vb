Imports System.Data.SqlClient
Public Class Book

    Inherits System.Web.UI.Page
    'Declaration of variables

#Disable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
    Private Title As String
#Enable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
#Disable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
    Private id As Integer
#Enable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
    Private Author As Author
    Private Publisher As String
    Private Isbn As Double
    Private EstValue As Double

    'Constructors

    Public Sub New(Title As String, Author As Author, Publisher As String, ISBN As Double, Value As Double)

        Me.Title = Title
        Me.Author = Author
        Me.Publisher = Publisher
        Me.Isbn = ISBN
        Me.EstValue = Value

    End Sub

    Public Sub New(Title As String, Author As String, Publisher As String, ISBN As Double, Value As Double)

        Me.Title = Title
        Me.Author = New Author(Author)
        Me.Publisher = Publisher
        Me.Isbn = ISBN
        Me.EstValue = Value

    End Sub

    Public Sub New()

    End Sub

    'Methods

    'Getters

    ''' <summary>
    ''' Returns the title of selected book
    ''' </summary>
    ''' <returns> string </returns>
    Public Function GetTitle() As String

        Return Me.Title

    End Function

    ''' <summary>
    ''' Returns the Author of selected book
    ''' </summary>
    ''' <returns> string </returns>

    Public Function GetAuthor() As Author

        Return Me.Author

    End Function

    ''' <summary>
    ''' Returns the Publisher of selected book
    ''' </summary>
    ''' <returns> string </returns>

    Public Function GetPublisher() As String

        Return Me.Publisher

    End Function

    ''' <summary>
    ''' Returns the ISBN of selected book
    ''' </summary>
    ''' <returns> Double </returns>

    Public Function GetIsbn() As Double

        Return Me.Isbn

    End Function

    Public Function GetID() As Integer

        Return Me.id

    End Function

    ''' <summary>
    ''' Returns the Estimated Value of selected book
    ''' </summary>
    ''' <returns> Double </returns>

    Public Function GetValue() As Double

        Return Me.EstValue

    End Function

    'Setters
    ''' <summary>
    ''' Sets the title of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    Public Function SetTitle(x As String)

        Me.Title = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the author of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>

    Public Function SetAuthor(x As Author)

        Me.Author = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the publisher of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    ''' 
    Public Function SetPublisher(x As String)

        Me.Publisher = x

        Return Nothing

    End Function

    Public Sub SetID(id As Integer)

        Me.id = id

    End Sub

    ''' <summary>
    ''' Sets the ISBN of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    Public Function SetIsbn(x As Double)

        Me.Isbn = x

        Return Nothing

    End Function

    ''' <summary>
    ''' Sets the estimated value of selected book using user input
    ''' </summary>
    ''' <returns> Nothing </returns>
    Public Function SetEstValue(x As Double)

        Me.EstValue = x

        Return Nothing

    End Function

    Public Function InsertBook()


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

                .AddWithValue("@title", Me.GetTitle)
                .AddWithValue("@publisher", Me.GetPublisher)
                .AddWithValue("@isbn", Me.GetIsbn)
                .AddWithValue("@value", Me.GetValue)

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

        Return Nothing

    End Function

    Public Function GetBookID()

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        'create new sql statement
        Dim strSQL As String = "SELECT Bid FROM books WHERE [isbn] = " & Me.Isbn

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

        Finally

            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

            'check connection status and close

            If sqlconn.State = ConnectionState.Open Then

                sqlconn.Close()

            End If

        End Try

        Me.id = ds.Tables(0).Rows(0).Item(0)

        Return Me.id

    End Function

    Public Sub InsertBookAuthors(BookID As Integer, AuthorID As Integer)

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



End Class
