<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="showSales.aspx.cs" Inherits="showSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
       
        <div id="gridviewDiv" runat="server">
            <asp:GridView runat="server" ID="salesGrid">
                <RowStyle HorizontalAlign="Center"></RowStyle>
            </asp:GridView>
        </div>
         <div>
            <asp:DropDownList runat="server" ID="catDDL"  >

            </asp:DropDownList>
             <asp:Button  runat="server" ID="filterBTN" Text="Filter" OnClick="filterBTN_Click"/>
        </div>
    </div>
</asp:Content>

