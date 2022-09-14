<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Search.aspx.vb" Inherits="Library.Search" %>

<%  Response.WriteFile("Header_Nav.html") %>

<div class="container">

    <div class ="main">

        <h1>Search</h1>

        <form id="frmMain" runat="server">

        <p>
           please choose an option below... 
        </p>

        <asp:Panel ID="pnlSearch" runat="server" BackColor="#E0E8F9">
            
            <div class="one">

              <P> &nbsp; Select Type<sup>*</sup>:   
                  <asp:DropDownList ID="DdlSearchAll" runat="server">
                    <asp:ListItem>--Choose--</asp:ListItem>
                    <asp:ListItem>Book</asp:ListItem>
                    <asp:ListItem>Author</asp:ListItem>
                    <asp:ListItem>Publisher</asp:ListItem>

                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RfvSearchAll" runat="server" ControlToValidate="DdlSearchAll" Display="Dynamic" ErrorMessage="Choose a type" ></asp:RequiredFieldValidator>
       
                  <asp:Button ID="BtnSearchAll" runat="server" Text="Search all" ValidationGroup="All"  />


                  </P>  

                </div>

        </asp:Panel>

              </form> 

    </div>

</div>


<p>
&nbsp;&nbsp;&nbsp;
</p>


<%  Response.WriteFile("footer.html") %>