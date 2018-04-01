<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="NewItem.aspx.cs" Inherits="NewItem" %>






   <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--   <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.js"></script>
    <link href="css/bootstrap.css" rel="stylesheet" />  --%>
    <link href="css/newItem.css" rel="stylesheet" />  
    <title></title>

</asp:Content>
   

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <div class="container col-xs-12 col-sm-12 col-md-6 col-lg-4 col-centered new-item ">

        <div>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                         <asp:Label ID="lbl_name" runat="server" Text="Label">Name:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txt_name" ID="txt_nameVLD" runat="server" ErrorMessage="Must Enter a Name"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>               
                <asp:TableRow> 
                    <asp:TableCell> 
                         <asp:Label ID="lbl_price" runat="server" Text="Label">Price:</asp:Label>
                </asp:TableCell>
                    <asp:TableCell> 
                        <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="txt_priceVLD" runat="server" 
                        ErrorMessage="Number Values only"
                        ControlToValidate="txt_price"
                        ValidationExpression="^[0-9]+$" />
                        <asp:RequiredFieldValidator ControlToValidate="txt_price" ID="txt_priceVLDReq" runat="server" ErrorMessage="Must Enter a Price"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ControlToValidate="ddl_category" ID="ddl_categoryVLD" runat="server" ErrorMessage="Must Choose Category"></asp:RequiredFieldValidator>
                </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow> 
                    <asp:TableCell> 
                          <asp:Label ID="Label3" runat="server" Text="Label">Amount in Inventory:</asp:Label>
                </asp:TableCell>
                    <asp:TableCell> 
                         <asp:TextBox ID="txt_inventory" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txt_inventory" ID="txt_inventoryVLD" runat="server" ErrorMessage="Must Enter a Price"></asp:RequiredFieldValidator>
                </asp:TableCell>
                </asp:TableRow>


            </asp:Table>
             <asp:Button ID="btn_submit" runat="server" Text="Add Item" OnClick="btn_submit_Click" />
             <asp:Label ID="labelError" runat="server" Text="&nbsp"></asp:Label>

        </div>
        <asp:Label ID="lbl_res" runat="server" Text=""></asp:Label>

      </div>

</asp:Content>

