<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Library.Index" %>

<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <meta name="keywords" content="" />	<!-- add keywords -->
    <meta name="description" content="" />	<!-- add description content -->
    <meta name="author" content="" />		<!-- Add your name to 'author' -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>St. Georges Restaurant</title>

    <!-- Links for css, bootstrap -->
    <link href="css/library.css" rel="stylesheet" type="text/css" />	<!-- edit the file name -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />	<!-- edit the file name -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>

<body>
    <!-- Navigation starts below -->
    <div class="navbar navbar-default" role="navigation">
	    <div class="navbar-header">
	
		    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
			    <span class="icon-bar"></span>
			    <span class="icon-bar"></span>
			    <span class="icon-bar"></span>
		    </button>
				
		    <!-- Logo goes here -->
			
		    <h1> Library </h1>
	    </div> <!-- End of navbar-header -->
	
	    <div class="container">  <!-- Top links start here -->
		    <div class="navbar-collapse collapse">
			    <ul class="nav navbar-nav navbar-right">
				    <li class="active"><a href="index.aspx">Bookings</a></li>
				    <li><a href=""></a>Search</li>
				    <li><a href=""></a>Contact</li>	
			    </ul>
		    </div> <!-- End of navbar collapse -->
	    </div> <!-- End of navigation container class -->
    </div>
    <!-- Navigation ends above -->

<!-- Main content div starts below -->
    <div class="container">
	    <div class="main">

	        <h1>Booking Form</h1>

            <form id ="form1" runat="server"

                <asp:Panel ID="pnlLibrary"

             <!-- End booking form -->
	
	    </div> <!-- Main content end  -->
	   
    </div> <!-- container (around main div) end-->

     <!-- Footer starts below -->
	 <footer class="navbar navbar-inverse navbar-fixed-bottom" role="navigation">
        <div class="container">
            <div class="navbar-text pull-right">
                &copy; Pierson  &amp; 2022  
            </div>
        </div>
    </footer>
    <!-- Footer ends above -->
 

<!-- Link to JavaScipt plugins, needed for things like the dropdown menu to work.  BOTH files are required. -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    
    <script src="js/bootstrap.min.js"></script>
   
</body>
</html>
