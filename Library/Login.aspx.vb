Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'prompt user with boxes to input login information 

        Dim message As String = "Enter your Login ID"
        Dim title As String = "Login"
        'Dim LoginID As String = InputBox(message, title, "username")

        Dim LoginID As String = InputBox(message, title, "Pie")

        If String.ReferenceEquals(LoginID, String.Empty) Then
            'User pressed cancel

            Response.Write("<script>window.close();</script>")

            Exit Sub

        ElseIf LoginID = "username" Then

            'User pressed ok with an empty string in the box

            Page_Load(sender, e)

        Else

            'User gave an answer    

            message = "Enter Password for " & LoginID

            title = "Password"

            Dim Password As String = GetPassword(message, title)

            If Password = Nothing Or Password = "password" Then

                Response.Write("<script>window.close();</script>")

                Exit Sub

            End If

            If Password <> "" Or Password <> "password" Then

                    'User gave an answer

                    If searchforlogin(LoginID, Password, sender, e) = True Then

                        Response.Redirect("Index.aspx")

                    End If

                    Page_Load(sender, e)

                End If

            End If

    End Sub

    Public Function searchforlogin(login As String, password As String, ByVal sender As Object, ByVal e As System.EventArgs) As Boolean

        Dim strSQL As String = "SELECT * FROM logins"

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

        End Try

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

            Dim p As String = CType(ds.Tables(0).Rows(i).Item(1), String)

            'username is correct

            If login = p.ToString() Then

                'password is correct

                If ds.Tables(0).Rows(i).Item(2) = password Then


                    'Response.Redirect("Index.aspx")

                    Return True

                End If

                MsgBox("Incorrect Password")

                Page_Load(sender, e)

            End If

        Next

        MsgBox("Incorrect Login or Password")

        Return False

    End Function

    Public Function GetPassword(message, Title) As String

        'ask user for a password

        'Dim password As String = InputBox(message, Title, "password")

        Dim password As String = InputBox(message, Title, "Tob")

        If String.ReferenceEquals(password, String.Empty) Then

            'User pressed cancel

            Return Nothing

        ElseIf password = "password" Then

            'User pressed ok with an empty string in the box

            GetPassword(message, Title)

        End If

        Return password

    End Function

End Class