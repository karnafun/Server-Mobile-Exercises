<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            choose the file : <asp:FileUpload ID="imageFU" runat="server" />
            <br />
            <asp:Button ID="submitBTN" runat="server" Text="Upload the file" OnClick="submitBTN_Click" />
            <br />
            <asp:Image runat="server" ID="stamImage" />
        </div>
    </form>
</body>
</html>
