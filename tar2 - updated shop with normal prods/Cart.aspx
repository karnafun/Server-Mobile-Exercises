<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" data-role="container" style="color:red">  <label id="welcomeLBL" runat="server"> </label></div>
   
    <div runat="server" id='cartDiv' class="container"></div>
    <div id="confirm" runat="server" class="container">

        <asp:Button runat="server" Text="Order Products" OnClick="Submit_Click" ID="submitBTN" />
       
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerPlayerHolder" Runat="Server" >
</asp:Content>

