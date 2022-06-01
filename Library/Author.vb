Imports System.Data.SqlClient
Public Class Author

    Inherits System.Web.UI.Page

#Disable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
    Private id As Integer
#Enable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'

    Private FName, Lname As String

    Public Sub New(AuthorName As String)


        'grab the data
        Dim AuthorArray As String() = Split(AuthorName)

        Me.FName = AuthorArray(0)

        Me.Lname = AuthorArray(1)

    End Sub

    Public Sub New()

    End Sub

    Public Function setID(ID As Integer)

        Me.id = ID

        Return Nothing

    End Function

    Public Function setName(FName As String, LName As String)

        Me.FName = FName

        Me.Lname = LName

        Return Nothing

    End Function

    Public Function getID()

        Return Me.id

    End Function

    Public Function getFName()

        Return Me.FName

    End Function
    Public Function getLName()

        Return Me.Lname

    End Function
    Public Function getAuthor()

        Return Me

    End Function

    Public Function InsertAuthor()

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

                .AddWithValue("@fname", Me.getFName)
                .AddWithValue("@lname", Me.getLName)
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

        Return Nothing

    End Function

    Public Function GetAuthorID() As Integer

        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter
        Dim ds As New DataSet

        'create new sql statement
        Dim strSQL As String = "SELECT Aid FROM authors WHERE [FirstName] = '" & Me.FName & "' AND [LastName] = '" & Me.Lname & "'"

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

        Return ds.Tables(0).Rows(0).Item(0)

    End Function

End Class
