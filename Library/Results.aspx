<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Results.aspx.vb" Inherits="Library.Results" %>

<%  Response.WriteFile("Header_Nav.html") %>

<div class="container">

    <div class ="main">

        <p>
           
              <asp:placeholder ID="plhDataTable" runat="server">     

        </asp:placeholder>

        </p>

    </div>

</div>

<%  Response.WriteFile("footer.html") %>