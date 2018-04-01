<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterDetails.aspx.cs" Inherits="MasterDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-weight: bold;
            font-size: x-large;
        }
        .style2
        {
            width: 341px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        In this page we demo how to connect a GridView (Master) to a detailed form View</div>
    <p>
        <asp:SqlDataSource ID="moviesDS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:moviesDBconnectionString %>" 
            SelectCommand="SELECT * FROM [movies]" 
            ConflictDetection="CompareAllValues" 
            DeleteCommand="DELETE FROM [movies] WHERE [id] = @original_id AND [name] = @original_name AND (([year] = @original_year) OR ([year] IS NULL AND @original_year IS NULL)) AND (([Director] = @original_Director) OR ([Director] IS NULL AND @original_Director IS NULL)) AND (([imageURL] = @original_imageURL) OR ([imageURL] IS NULL AND @original_imageURL IS NULL)) AND (([youTubeURL] = @original_youTubeURL) OR ([youTubeURL] IS NULL AND @original_youTubeURL IS NULL))" 
            InsertCommand="INSERT INTO [movies] ([name], [year], [Director], [imageURL], [youTubeURL]) VALUES (@name, @year, @Director, @imageURL, @youTubeURL)" 
            OldValuesParameterFormatString="original_{0}" 
            UpdateCommand="UPDATE [movies] SET [name] = @name, [year] = @year, [Director] = @Director, [imageURL] = @imageURL, [youTubeURL] = @youTubeURL WHERE [id] = @original_id AND [name] = @original_name AND (([year] = @original_year) OR ([year] IS NULL AND @original_year IS NULL)) AND (([Director] = @original_Director) OR ([Director] IS NULL AND @original_Director IS NULL)) AND (([imageURL] = @original_imageURL) OR ([imageURL] IS NULL AND @original_imageURL IS NULL)) AND (([youTubeURL] = @original_youTubeURL) OR ([youTubeURL] IS NULL AND @original_youTubeURL IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_name" Type="String" />
                <asp:Parameter Name="original_year" Type="Int32" />
                <asp:Parameter Name="original_Director" Type="String" />
                <asp:Parameter Name="original_imageURL" Type="String" />
                <asp:Parameter Name="original_youTubeURL" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="year" Type="Int32" />
                <asp:Parameter Name="Director" Type="String" />
                <asp:Parameter Name="imageURL" Type="String" />
                <asp:Parameter Name="youTubeURL" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_name" Type="String" />
                <asp:Parameter Name="original_year" Type="Int32" />
                <asp:Parameter Name="original_Director" Type="String" />
                <asp:Parameter Name="original_imageURL" Type="String" />
                <asp:Parameter Name="original_youTubeURL" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="year" Type="Int32" />
                <asp:Parameter Name="Director" Type="String" />
                <asp:Parameter Name="imageURL" Type="String" />
                <asp:Parameter Name="youTubeURL" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </p>
    <table><tr><td class="style2">
    
    <asp:GridView ID="moviesGRDVW" runat="server" AutoGenerateColumns="False" 
        DataSourceID="moviesDS" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:ImageField DataImageUrlField="imageURL" HeaderText="Poster">
                <ControlStyle Width="60px" />
            </asp:ImageField>
        </Columns>
    </asp:GridView>
    
        </td>
    <td style="width:50px"></td>
    <td>
    
        <asp:FormView ID="movieForm" runat="server" 
            DataKeyNames="id" DataSourceID="moviesDS">
            <EditItemTemplate>
                id:
                <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                <br />
                <b>name:&nbsp; </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                <br />
                year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="yearTextBox" runat="server" Text='<%# Bind("year") %>' />
                <br />
                Director:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="DirectorTextBox" runat="server" 
                    Text='<%# Bind("Director") %>' />
                <br />
                imageURL:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="imageURLTextBox" runat="server" 
                    Text='<%# Bind("imageURL") %>' />
                <br />
                youTubeURL:&nbsp;
                <asp:TextBox ID="youTubeURLTextBox" runat="server" 
                    Text='<%# Bind("youTubeURL") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                name:
                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                <br />
                year:
                <asp:TextBox ID="yearTextBox" runat="server" Text='<%# Bind("year") %>' />
                <br />
                Director:
                <asp:TextBox ID="DirectorTextBox" runat="server" 
                    Text='<%# Bind("Director") %>' />
                <br />
                imageURL:
                <asp:TextBox ID="imageURLTextBox" runat="server" 
                    Text='<%# Bind("imageURL") %>' />
                <br />
                youTubeURL:
                <asp:TextBox ID="youTubeURLTextBox" runat="server" 
                    Text='<%# Bind("youTubeURL") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />
                name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("name") %>' />
                <br />
                year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="yearLabel" runat="server" Text='<%# Bind("year") %>' />
                <br />
                Director:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="DirectorLabel" runat="server" Text='<%# Bind("Director") %>' />
                <br />
                imageURL:&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="imageURLLabel" runat="server" Text='<%# Bind("imageURL") %>' />
                <br />
                youTubeURL:
                <asp:Label ID="youTubeURLLabel" runat="server" 
                    Text='<%# Bind("youTubeURL") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
    
    </td>
    </tr></table>
    <br />
&nbsp;&nbsp;
    </form>
</body>
</html>
