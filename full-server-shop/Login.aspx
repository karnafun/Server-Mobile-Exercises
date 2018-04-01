<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> Sign in </h1>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>Username:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="usernameTB" ></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="usernameTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Username">
                    </asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Password:</asp:TableCell>
                <asp:TableCell>
                   <input type="password" name="psw" runat="server" id="passwordTB"/>
                    <asp:RequiredFieldValidator ControlToValidate="passwordTB" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Password">
                    </asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="submitBTN" runat="server" OnClick="submitBTN_Click" Text="Log In" />
        <asp:Label runat="server" ID="lbl_res"></asp:Label>
    </div>
    </form>
</body>
</html>
