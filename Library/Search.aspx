<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Search.aspx.vb" Inherits="Library.Search" %>

<%  Response.WriteFile("Header_Nav.html") %>

<div class="container">

    <div class ="main">

        <h1>Search</h1>

        <p>
           please choose an option below... 
        </p>

        <form id="frmMain" runat="server">

        <asp:Panel ID="pnlSearch" runat="server" BackColor="#E0E8F9">
            
            <div class="one">

              <P> &nbsp; Title<sup>*</sup>: &emsp;&emsp;
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Title Required">A Title Is Required</asp:RequiredFieldValidator
                  </P>  

                </div>

        </asp:Panel>

              </form> 

    </div>

</div>

<%  Response.WriteFile("footer.html") %>