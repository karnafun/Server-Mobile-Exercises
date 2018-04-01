<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        #cartDiv img{
            height:250px;
            width:250px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" data-role="container" style="color:red">  <label id="welcomeLBL" runat="server"> </label></div>
   
    <div runat="server" id='cartDiv' class="container"></div>
    <div id="confirm" runat="server" class="container">

        <asp:Button runat="server" Text="Order Products" OnClick="Submit_Click" ID="submitBTN" />
        <br />
       <asp:Label runat="server" ID="lbl_res"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lbl_discount"></asp:Label>
    </div>
    
</asp:Content>

