<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Success.aspx.vb" Inherits="Library.Success" %>

<%  Response.WriteFile("Header_Nav.html") %>

<div class="container">

    <div class ="main">

        <h1>Success</h1>

        <p>

            Book has been logged

            </p>

        <asp:placeholder ID="plhDataTable" runat="server">


        </asp:placeholder>

            </div>

    </div>


<%  Response.WriteFile("footer.html") %>