<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classEx part 2.aspx.cs" Inherits="classEx_part_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:SqlDataSource ID="moviesDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:moviesDBconnectionString %>" 
        SelectCommand="SELECT [name] FROM [movies]"></asp:SqlDataSource>
    <div>
    
    </div>
    </form>
</body>
</html>
