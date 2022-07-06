<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Data.aspx.vb" Inherits="Library.Data" %>

<%  Response.WriteFile("Header_Nav.html") %>

<div class="container">

    <div class ="main">


        <asp:placeholder ID="plhDataTable" runat="server">


        </asp:placeholder>

            </div>

    </div>


<%  Response.WriteFile("footer.html") %>