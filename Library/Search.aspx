<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Search.aspx.vb" Inherits="Library.Search" %>

<%  Response.WriteFile("Header_Nav.html") %>

<div class="container">

    <div class ="main">

        <h1>Search</h1>

        <form id="frmMain" runat="server">

        <p>
           please choose an option below... 
        </p>
            <p>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem>--Choose--</asp:ListItem>
                    <asp:ListItem>Title</asp:ListItem>
                    <asp:ListItem>Author</asp:ListItem>
                    <asp:ListItem>Publisher</asp:ListItem>
                    <asp:ListItem>ISBN</asp:ListItem>
                    <asp:ListItem>Value</asp:ListItem>
                    <asp:ListItem>Book</asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="rfvList" runat="server" ControlToValidate="ddlCategory" Display="Dynamic" ErrorMessage="A type Is Required " ></asp:RequiredFieldValidator>
        </p>

        <asp:Panel ID="pnlSearch" runat="server" BackColor="#E0E8F9">
            
            <div class="one">

              <P> &nbsp; Enter Value<sup>*</sup>: &emsp;&emsp;
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="A Value Is Required " ></asp:RequiredFieldValidator>

                  
                        <asp:Button ID="BtnSearch" runat="server" Text="Search" />

                  <br />

                   &nbsp; Select Type<sup>*</sup>:   
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