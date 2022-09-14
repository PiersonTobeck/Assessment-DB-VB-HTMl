<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Results.aspx.vb" Inherits="Library.Results" %>

<%  Response.WriteFile("Header_Nav.html") %>

<link rel="stylesheet" href="css/data.css">

<div class="container">

    <div class ="main">
           
              <asp:placeholder ID="plhDataTable" runat="server">     

        </asp:placeholder>

    </div>
    <br /><br />
</div>

<%  Response.WriteFile("footer.html") %>