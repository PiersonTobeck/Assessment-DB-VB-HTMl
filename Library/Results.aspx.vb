Public Class Results
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'check for type of user input
        Dim type As String = Session("Type")

        If type = "" Then

            Response.Redirect("Search.aspx")

        End If

        If type = "Author" Then

            searchallforauthors(type)

        End If

        If type = "Book" Then

            searchallforbooks(type)

        End If

        If type = "Publisher" Then

            searchallforpublisher(type)

        End If


    End Sub

    Private Sub searchallforauthors(type As String)
        Try
            'stringbuilder to create table

            Dim strBuilder As StringBuilder = New StringBuilder()

            'create table

            strBuilder.Append("<table class =""results"">")

            'add table header row

            strBuilder.Append("<tr class =""results"">")
            strBuilder.Append("<th class=""results""> " & type & "s" & " </th>")

            'close header row
            strBuilder.Append("</tr>")

            'add table data row
            Dim ds As DataSet = Session("Search")

            For Each row As DataRow In ds.Tables(0).Rows

                Dim firstname As String = row(1)
                Dim lastname As String = row(2)

                firstname = firstname.Replace(" ", String.Empty)
                lastname = lastname.Replace(" ", String.Empty)

                strBuilder.Append("<tr class=""results"">")
                strBuilder.Append("<td class=""results""><a href='data.aspx?id=" & row(0) & "&type=Author&title=" & firstname & " " & lastname & "'</a>" & firstname & " " & lastname & "</td>")
                'close table row& " 
                strBuilder.Append("</tr>")

            Next

            'close table and add to placeholder
            strBuilder.Append("</table>")

            plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

            strBuilder.Clear()

        Catch ex As Exception

            Response.Redirect("search.aspx")

        End Try

    End Sub

    Private Sub searchallforbooks(type As String)

        Try
            'stringbuilder to create table

            Dim strBuilder As StringBuilder = New StringBuilder()

            'create table

            strBuilder.Append("<table class =""results"">")

            'add table header row

            strBuilder.Append("<tr class =""results"">")
            strBuilder.Append("<th class=""results""> " & type & "s" & " </th>")

            'close header row
            strBuilder.Append("</tr>")

            'add table data row
            Dim ds As DataSet = Session("Search")

            For Each row As DataRow In ds.Tables(0).Rows

                strBuilder.Append("<tr class=""results"">")
                strBuilder.Append("<td class=""results""><a href='data.aspx?id=" & row(0) & "&type=" & type & "&title=" & row(1) & "'</a>" & row(1) & "</td>")
                'close table row
                strBuilder.Append("</tr>")

            Next

            'close table and add to placeholder
            strBuilder.Append("</table>")

            plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

            strBuilder.Clear()

        Catch ex As Exception

            Response.Redirect("search.aspx")

        End Try

    End Sub


    Private Sub searchallforpublisher(type As String)
        Try
            'stringbuilder to create table

            Dim strBuilder As StringBuilder = New StringBuilder()

            'create table

            strBuilder.Append("<table class =""results"">")

            'add table header row

            strBuilder.Append("<tr class =""results"">")
            strBuilder.Append("<th class=""results""> " & type & "s" & " </th>")

            'close header row
            strBuilder.Append("</tr>")

            'add table data row
            Dim ds As DataSet = Session("Search")

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                strBuilder.Append("<tr class=""results"">")
                strBuilder.Append("<td class=""results""><a href='data.aspx?id=null" & "&type=" & type & "&title=" & ds.Tables(0).Rows(i).ItemArray(0) & "'</a>" & ds.Tables(0).Rows(i).ItemArray(0) & "</td>")
                'close table row
                strBuilder.Append("</tr>")

            Next

            'close table and add to placeholder
            strBuilder.Append("</table>")

            plhDataTable.Controls.Add(New LiteralControl(strBuilder.ToString()))

            strBuilder.Clear()

        Catch ex As Exception

            Response.Redirect("search.aspx")

        End Try

    End Sub

End Class