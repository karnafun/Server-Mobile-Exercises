<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="moviesGrid.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: left;
            font-size: xx-large;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        My Movie List&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="" src="Images/ist2_4180039-push-the-button.jpg" 
            style="width: 305px; height: 265px" /><br />
    
    </div>
    <asp:SqlDataSource ID="moviesDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:moviesDBconnectionString %>" 
        SelectCommand="SELECT * FROM [movies]"></asp:SqlDataSource>
    <asp:GridView ID="moviesGRDVW" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        DataSourceID="moviesDS">
        <RowStyle BackColor="White" ForeColor="#330099" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" />
            <asp:BoundField DataField="Director" HeaderText="Director" 
                SortExpression="Director" />
            <asp:BoundField DataField="imageURL" HeaderText="imageURL" 
                SortExpression="imageURL" />
            <asp:BoundField DataField="youTubeURL" HeaderText="youTubeURL" 
                SortExpression="youTubeURL" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
    </asp:GridView>
    </form>
</body>
</html>
