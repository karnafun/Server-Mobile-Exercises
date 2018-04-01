<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BindingToADropDownList.aspx.cs" Inherits="BindingToADropDownList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Binding a list</title>
    <style type = "text/css"> 
    
    .heb
    { direction : rtl;
    	}
    
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        In this Example we&nbsp; bind a list createad in the code behind to an ASP 
        DropDownList control<br />
        <br />
    
    </div>
    <asp:DropDownList ID="moviesDDL" runat="server" CssClass = "heb">
    </asp:DropDownList>
    <br />
    <br />
    <asp:RadioButtonList ID="moviesRBL" runat="server">
    </asp:RadioButtonList>
    <br />
    </form>
</body>
</html>
