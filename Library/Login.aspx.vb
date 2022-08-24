Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim message As String = "Enter your Login ID"
        Dim title As String = "Login"
        Dim LoginID As String = InputBox(message, title, "username")

        If String.ReferenceEquals(LoginID, String.Empty) Then
            'User pressed cancel

            Response.Write("<script>window.close();</script>")

            Exit Sub

        ElseIf LoginID = " " Then

            'User pressed ok with an empty string in the box

            Page_Load(sender, e)

        Else

            'User gave an answer

            message = "Enter your Password"
            title = "Password"

            Dim Password As String = InputBox(message, title, "password")

            If String.ReferenceEquals(Password, String.Empty) Then

                'User pressed cancel

                Response.Write("<script>window.close();</script>")

                Exit Sub

            ElseIf Password = " " Then

                'User pressed ok with an empty string in the box

                Page_Load(sender, e)

            Else

                'User gave an answer

                If searchforlogin(LoginID, Password) = True Then

                    Response.Redirect("Index.aspx")

                End If



            End If

        End If

    End Sub

    Public Function searchforlogin(login, password) As Boolean

        Dim strSQL As String = "SELECT [Name], [Password] FROM logins"

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


        For i As Integer = 0 To ds.Tables(0).Rows(0).ItemArray.Length - 1

            If login.Equals(l) Then

                MsgBox("This worked")

                If ds.Tables(0).Rows(0).Item(i + 1).ToString = password Then

                    MsgBox("Successfull Login")

                    Response.Redirect("Index.aspx")

                End If

            End If

        Next


    End Function

End Class