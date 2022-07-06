Imports System.Data.SqlClient
Public Class Data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Id = Request.QueryString("id")

        Dim Type = Request.QueryString("type")

        Dim title = Request.QueryString("title")

#Disable Warning BC42024 ' Unused local variable
        Dim bookinfo As (firstnames As String(), lastnames As String())
#Enable Warning BC42024 ' Unused local variable


        If Type = "Book" Then

            bookinfo = displaybookinfo(Type, Id)

            Dim firstnames As String() = bookinfo.firstnames

            MsgBox(firstnames(1))

        ElseIf Type = "Publisher" Then


        ElseIf Type = "Author" Then

        End If

    End Sub

    Public Function displaybookinfo(type, id) As (firstnames As String(), lastnames As String())

        Dim strSQL As String = "SELECT AID FROM bookauthors WHERE [BID] = " & id

        'create new sql statement
        'objects for communication with db
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\books.mdf';Integrated Security=True"

        Dim sqlcmd As SqlCommand
        Dim sqlconn As New SqlConnection(strConn)
        Dim sqlDA As New SqlDataAdapter

        Dim ds As New DataSet

        Dim firstnames As String()
        Dim lastnames As String()
        Dim AIDs As Object()

        Try
            'open connection
            sqlconn.Open()
            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)
            AIDs = ds.Tables(0).Rows(0).ItemArray
        Catch ex As Exception

            MsgBox("An Eror has occured (02)")
        Finally
            'tidy up resources

            sqlDA.Dispose()
            ds.Dispose()

        End Try

        For i As Integer = 0 To AIDs.Count - 1

            strSQL = "SELECT FirstName, Lastname FROM authors WHERE [Aid] = " & AIDs(i)

            sqlcmd = New SqlCommand(strSQL, sqlconn)

            'run query and fill datasets

            sqlDA.SelectCommand = sqlcmd
            sqlDA.Fill(ds)

            For x As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 2

#Disable Warning BC42104 ' Variable is used before it has been assigned a value

                firstnames(i) = ds.Tables(0).Rows(0).ItemArray(0)  '.ItemArray(1).ToString

                lastnames(i) = ds.Tables(0).Rows(0).ItemArray(1) '.ItemArray(2).ToString

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


            Return (firstnames, lastnames)

    End Function

    Public Function something2(type, id)

    End Function


    Public Function something3(type, id)



    End Function

End Class