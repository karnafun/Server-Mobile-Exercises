<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calculator.aspx.cs" Inherits="calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="firstNumber" runat="server" Text="Label">Num1:</asp:Label>
        <asp:TextBox ID="txt_first" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="secondNumber" runat="server" Text="Label">Num2:</asp:Label>
        <asp:TextBox ID="txt_second" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="multi" runat="server" Text="Multiply" OnClick="multi_Click" />
        <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click" />
    </div>

        <asp:Label ID="lblCalc" runat="server" Text="FullCalc">Enter Calculation:</asp:Label>
        <asp:TextBox ID="txt_calc" runat="server" OnTextChanged="txt_calc_TextChanged" AutoPostBack="true"></asp:TextBox>
        <br />
         <asp:Button ID="btn_calc" runat="server" Text="Post Calculation" OnClick="btn_calc_Click" />
    </form>
</body>
</html>
