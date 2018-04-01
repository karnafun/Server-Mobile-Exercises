<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        img {
            height:175px;
            width:175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="container">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="productId" DataSourceID="SqlDataSource1" OnRowUpdating="GridView1_RowUpdating">
        <Columns>

            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="productId" HeaderText="productId" ReadOnly="True" SortExpression="productId" />
            
            <asp:BoundField DataField="categoryId" HeaderText="categoryId" SortExpression="categoryId" ReadOnly="True" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" ReadOnly="True" />
            <asp:ImageField DataImageUrlField="imagePath" HeaderText="Image" ReadOnly="True">
                <ItemStyle Height="250px" Width="250px" />
            </asp:ImageField>
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" ReadOnly="True" />
            <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
            <asp:CheckBoxField DataField="status" HeaderText="status" SortExpression="status" />
        </Columns>
              <RowStyle HorizontalAlign="Center"></RowStyle>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:test2DBConnectionString %>" DeleteCommand="DELETE FROM [ProductN] WHERE [productId] = @original_productId AND [categoryId] = @original_categoryId AND [title] = @original_title AND [imagePath] = @original_imagePath AND [price] = @original_price AND [inventory] = @original_inventory AND [status] = @original_status" InsertCommand="INSERT INTO [ProductN] ([productId], [categoryId], [title], [imagePath], [price], [inventory], [status]) VALUES (@productId, @categoryId, @title, @imagePath, @price, @inventory, @status)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [ProductN]" 
        UpdateCommand="UPDATE [ProductN] SET   [inventory] = @inventory, [status] = @status WHERE [productId] = @original_productId ">
      
       <%-- <DeleteParameters>
            <asp:Parameter Name="original_productId" Type="Int16" />
            <asp:Parameter Name="original_categoryId" Type="Int32" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_imagePath" Type="String" />
            <asp:Parameter Name="original_price" Type="Double" />
            <asp:Parameter Name="original_inventory" Type="Int32" />
            <asp:Parameter Name="original_status" Type="Boolean" />
        </DeleteParameters>--%>
    <%--    <InsertParameters>
            <asp:Parameter Name="productId" Type="Int16" />
            <asp:Parameter Name="categoryId" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="imagePath" Type="String" />
            <asp:Parameter Name="price" Type="Double" />
            <asp:Parameter Name="inventory" Type="Int32" />
            <asp:Parameter Name="status" Type="Boolean" />
        </InsertParameters>--%>
        <UpdateParameters>
         <%--   <asp:Parameter Name="categoryId" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="imagePath" Type="String" />
            <asp:Parameter Name="price" Type="Double" />
            <asp:Parameter Name="inventory" Type="Int32" />
            <asp:Parameter Name="status" Type="Boolean" />
            <asp:Parameter Name="original_productId" Type="Int16" />
            <asp:Parameter Name="original_categoryId" Type="Int32" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_imagePath" Type="String" />
            <asp:Parameter Name="original_price" Type="Double" />--%>
            <asp:Parameter Name="original_inventory" Type="Int32" />
            <asp:Parameter Name="original_status" Type="Boolean" />
        </UpdateParameters>
    </asp:SqlDataSource>

    </div>
     
  
</asp:Content>

