Imports System.Data.SqlClient

Public Class Index


    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

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

        'send the data

        'Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\dbLibrary.mdf';Integrated Security=True"
        Dim strconn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"
        Dim strSQL As String = "INSERT INTO books ([Title], [Author], [Publisher], [ISBN], [ESTValue]) VALUES ("
        strSQL &= "@title,@author,@publisher,@isbn,@value)"
        Dim sqlCmd As SqlCommand
        Dim sqlConn As New SqlConnection(strconn)

        Try


            'open connection
            sqlConn.Open()
            sqlCmd = New SqlCommand(strSQL, sqlConn)

            With sqlCmd.Parameters

                .AddWithValue("@title", strTitle)
                .AddWithValue("@author", strAuthor)
                .AddWithValue("@publisher", strPublisher)
                .AddWithValue("@isbn", IntISBN)
                .AddWithValue("@value", intValue)

            End With

            'execute query
            Dim i As Integer = sqlCmd.ExecuteNonQuery()

            'check if it failed
            If i = 0 Then

                Throw New System.Exception("An exception has occurred.")

            End If

            'sqlCmd.ExecuteNonQuery()

            sqlConn.Close()

        Catch ex As Exception

            MsgBox("An Eror has occured")

            Exit Sub

        End Try


        ClearForm()

        Response.Redirect("RawData.aspx")

    End Sub

    Public Sub CheckforDupeISBN()

        Dim ISBNS As Double()

        ISBNS(0) = 5.05



    End Sub

    Public Sub ClearForm()

        txtTitle.Text = String.Empty
        txtAuthor.Text = String.Empty
        txtPublisher.Text = String.Empty
        txtISBN.Text = String.Empty
        txtValue.Text = String.Empty

    End Sub


End Class