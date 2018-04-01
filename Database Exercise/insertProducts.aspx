<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insertProducts.aspx.cs" Inherits="insertProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
            font-family: sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" dir="rtl">
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <h1>הכנסת מוצר חדש למערכת</h1>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <a>שם מוצר:</a>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox_Name" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="nameVLD" runat="server" ControlToValidate="TextBox_Name"
                        ForeColor="Red" Text="אנא הזן שם מוצר"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <a>מחיר:</a>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox_Price" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="priceVLD" runat="server" ControlToValidate="TextBox_Price"
                        ForeColor="Red" Text="אנא הזן מחיר מוצר."></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox_Price"
                       MinimumValue="0" MaximumValue="999999999"  ForeColor="Red" ErrorMessage=" ערך מספרי בלבד"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <a>תמונה:</a>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="FileUpload_ImagePath" runat="server" accept=".png,.jpg,.jpeg,.gif" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="fileUploadVLD" runat="server" ControlToValidate="FileUpload_ImagePath"
                        ForeColor="Red" Text="אנא העלה את תמונת המוצר."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                        ControlToValidate="FileUpload_ImagePath"
                        ForeColor="Red" Text="  קבצי תמונה בלבד!"
                        ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
                    </asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <a>בחר קטגוריה:</a>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownList_CategoryId" runat="server">
                        <asp:ListItem>בחר קטגוריית מוצר</asp:ListItem>
                       
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList_CategoryId"
                    InitialValue="בחר קטגוריית מוצר"    ForeColor="Red" Text="אנא בחר את שם הקטגוריה"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <a>בחר מלאי:</a>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownList_Inventory" runat="server">
                        <asp:ListItem>בחר כמות במלאי</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList_Inventory"
                       InitialValue="בחר כמות במלאי" ForeColor="Red" Text="אנא בחר כמות למלאי"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonInsert" runat="server" Text="הוסף לרשימת המוצרים" OnClick="ButtonInsert_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
