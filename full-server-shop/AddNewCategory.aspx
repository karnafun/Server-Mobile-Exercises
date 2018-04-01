<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddNewCategory.aspx.cs" Inherits="AddNewCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container ">
        <div style="float: left">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                Category id:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="idTB"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Number Values only"
                            ControlToValidate="idTB"
                            ValidationExpression="^[0-9]+$" />
                        <asp:RequiredFieldValidator ControlToValidate="idTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must Enter ID">
                        </asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                Category name:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="nameTB"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="nameTB" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Must Enter Name">
                        </asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button runat="server" ID="submitBTN" Text="Add Category" OnClick="submitBTN_Click" />

        </div>
        <div id="listDiv" runat="server"></div>

        <asp:Label runat="server" ID="lbl_res"  Text=""></asp:Label>
    </div>

</asp:Content>

