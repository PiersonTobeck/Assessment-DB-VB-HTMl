<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Library.Index" %>

<%  Response.WriteFile("Header_Nav.html") %>

<!-- Main content div starts below -->
<!-- Links for css, bootstrap -->
    <link href="css/library.css" rel="stylesheet" type="text/css" />	<!-- edit the file name -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />	<!-- edit the file name -->
    <div class="container">
	    <div class="main">

	        <h1>&nbsp;&nbsp;&nbsp; Create book</h1>

            <form id="form1" runat="server">

                <div style="margin-left: 40px">
                    <asp:Panel ID="pnlBookForm" runat="server" Height="400px" BackColor="#FF6666">
                    Title<sup>*</sup>:<br />
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Title Required">A Title Is Required</asp:RequiredFieldValidator>
                        <br />
                    Author<sup>*</sup>:<br />
                        <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revAuthor" runat="server" ControlToValidate="txtAuthor" ErrorMessage="A Valid Author Is Required" ValidationExpression="^[a-zA-Z]{2,40}(?: +[a-zA-Z]{2,40})+$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="txtAuthor" Display="Dynamic" ErrorMessage="Author Required">An Author Is Required</asp:RequiredFieldValidator>
                        <br />
                    Publisher<sup>*</sup>:<br />
                        <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPublisher" runat="server" ControlToValidate="txtPublisher" Display="Dynamic" ErrorMessage="Publisher Required">A Publisher Is Required</asp:RequiredFieldValidator>
                        <br />
                    ISBN<sup>*</sup>:<br />
                        <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revISBN" runat="server" ControlToValidate="txtISBN" ErrorMessage="A Valid ISBN Is Required" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvISBN" runat="server" ControlToValidate="txtISBN" Display="Dynamic" ErrorMessage="ISBN Required">An ISBN Is Required</asp:RequiredFieldValidator>
                        <br />
                    Value<sup>*</sup>:<br />
                        <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revValue" runat="server" ControlToValidate="txtValue" ErrorMessage="A Valid Value Is Required" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue" Display="Dynamic" ErrorMessage="Value Required">A Value Is Required</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                    </asp:Panel>
                </div>

                </form>

             <!-- End booking form -->
	
	    </div> <!-- Main content end  -->
	   
    </div> <!-- container (around main div) end-->

<%  Response.WriteFile("footer.html") %>
    
 

<!-- Link to JavaScipt plugins, needed for things like the dropdown menu to work.  BOTH files are required. -->
   
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    
    <script src="js/bootstrap.min.js"></script>
