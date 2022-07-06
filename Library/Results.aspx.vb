Public Class Results
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim type As String = Session("Type")

        If type = "Author" Then

            searchallforauthors(type)

        Else

            searchallfornotauthors(type)

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
            strBuilder.Append("<th class=""results""> " & type & " </th>")

            'close header row
            strBuilder.Append("</tr>")

            'add table data row
            Dim ds As DataSet = Session("Search")

            For Each row As DataRow In ds.Tables(0).Rows

                strBuilder.Append("<tr class=""results"">")
                strBuilder.Append("<td class=""results""><a href='data.aspx?id=" & row(0) & "&type=author&title=" & row(1) & " " & row(2) & "'</a>" & row(1) & row(2) & "</td>")
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

    Private Sub searchallfornotauthors(type As String)

        Try
            'stringbuilder to create table

            Dim strBuilder As StringBuilder = New StringBuilder()

            'create table

            strBuilder.Append("<table class =""results"">")

            'add table header row

            strBuilder.Append("<tr class =""results"">")
            strBuilder.Append("<th class=""results""> " & type & " </th>")

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

End Class