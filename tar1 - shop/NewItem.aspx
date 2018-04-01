<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewItem.aspx.cs" Inherits="NewItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />  
    <link href="Content/newItem.css" rel="stylesheet" />  
    <title></title>
</head>
<body>
      
     <!-- NavBar -->
    <div class="container pad">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                     <img style="width:50px; height:50px;" src="Content/Images/logo.png"/>
                    <a class="navbar-brand" href="#">GanjaShop</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav">
                        <li ><a href="Index.html"><span class="glyphicon glyphicon-shopping-cart"></span> Shop</a></li>
                        <li class="active"><a href="NewItem.aspx"><span class="glyphicon glyphicon-plus"></span> New Item</a></li>
                        <li><a href="ContactPage.html"><span class="glyphicon glyphicon-envelope"></span> Contact Us</a></li>
                    </ul>
                    <!--<ul class="nav navbar-nav navbar-right">
                        <li><a href="#"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>
                        <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
                    </ul>-->
                </div>
            </div>
        </nav>
   </div>

  <div class="container col-xs-12 col-sm-12 col-md-6 col-lg-4 col-centered new-item ">
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                         <asp:Label ID="lbl_name" runat="server" Text="Label">Name:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                        
                    </asp:TableCell>
                </asp:TableRow>               
                <asp:TableRow> 
                    <asp:TableCell> 
                         <asp:Label ID="Label1" runat="server" Text="Label">Price:</asp:Label>
                </asp:TableCell>
                    <asp:TableCell> 
                        <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
                       
                </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow> 
                    <asp:TableCell> 
                         <asp:Label ID="Label2" runat="server" Text="Label">Category:</asp:Label>
                </asp:TableCell>
                    <asp:TableCell> 
                         <asp:DropDownList ID="ddl_category" runat="server">
                <asp:ListItem>Indica</asp:ListItem>
                <asp:ListItem>Sativa</asp:ListItem>
                <asp:ListItem>Hybrid</asp:ListItem>
            </asp:DropDownList>
                </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow> 
                    <asp:TableCell> 
                          <asp:Label ID="Label3" runat="server" Text="Label">Description:</asp:Label>
                </asp:TableCell>
                    <asp:TableCell> 
                         <textarea id="txtarea_description" runat="server" cols="20" rows="2"></textarea>
                </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
             <asp:Button ID="btn_submit" runat="server" Text="Add Item" OnClick="btn_submit_Click" />
             <asp:Label ID="labelError" runat="server" Text="&nbsp"></asp:Label>

        </div>
        <asp:Label ID="lbl_res" runat="server" Text=""></asp:Label>
    </form>
      </div>
</body>
</html>
