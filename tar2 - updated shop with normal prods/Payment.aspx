<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="images_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <script type="text/javascript">

     
        function validateId(src, arg) {
          
            var sum = 0;
            for (var i = 0; i < arg.Value.length; i++) {
                sum +=parseInt( arg.Value[i]);
            }
            sum /= 7;
            if (arg.Value[arg.Value.length-1]!=sum) {

                arg.IsValid = false; 
                
            
                
            } 


        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="container" style="align-content: center" > <label id="totalPriceLBL" runat="server"></label></div>
 



    <div  runat="server" id="maindiv" class="container" style="align-content: center">
        <table style="margin: auto">
            <%-- NAME --%>
            <tr>
                <td>
                    <label>Full Name:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_fullname"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="txt_fullname" runat="server" ErrorMessage="Please Enter a Name"
                        Style="color: #FF0000"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <%-- Address --%>
            <tr>
                <td>
                    <label>Address:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        ControlToValidate="txt_address" runat="server" ErrorMessage="Address Is Required"
                        Style="color: #FF0000" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- Email --%>
            <tr>
                <td>
                    <label>Email:</label>
                </td>
                <td>

                    <input type="email" runat="server" id="txt_email" />

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        ControlToValidate="txt_email" runat="server" ErrorMessage="Email Address Required"
                        Style="color: #FF0000"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <%-- Date  --%>
            <tr>
                <td>
                    <label>Date:</label>
                </td>
                <td>
                    <asp:Calendar runat="server" ID="calendar" OnSelectionChanged="calendar_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="calendarTB" runat="server" class="hidden">randomtext</asp:TextBox>
                    <asp:CustomValidator ID="calendarVLD" runat="server"
                        ControlToValidate="calendarTB" ErrorMessage="Invalid Date !"  Style="color: #FF0000"
                        OnServerValidate="calendarVLD_ServerValidate"></asp:CustomValidator><br />

                </td>
            </tr>
            <%-- checkbox CreditCard --%>
            <tr>
                <td>
                    <asp:CheckBox runat="server" AutoPostBack="true" ID="cb_credit" Text="Credit Card" />
                </td>
            </tr>
            <%-- Checkbox Phone --%>
            <tr>

                <td>
                    <asp:CheckBox runat="server" AutoPostBack="true" ID="cb_phone" Text="Phone Payment" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="PaymentMethodVLD"  Style="color: #FF0000" runat="server" ErrorMessage="CustomValidator" OnServerValidate="PaymentMethodVLD_ServerValidate"></asp:CustomValidator>
                   <%-- <asp:Label runat="server" ID="PaymentMethodVLDLBL"></asp:Label>--%>
                </td>
            </tr>

            <%-- Credit Card Payment Amount --%>
            <tr runat="server" id="tr_credit1">

                <td>
                    <label>Amount of Payments: </label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddl_creditCardPayments">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ControlToValidate="ddl_creditCardPayments"
                        ID="creditCardPaymentsVLD" runat="server"
                        ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <%-- Credit Card Number --%>
            <tr runat="server" id="tr_credit2">

                <td>
                    <label>Credit Card Number:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_creditCardNumber"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="creditCardVLD" runat="server"
                        ErrorMessage="Credit card must be 19 digits"
                        ControlToValidate="txt_creditCardNumber"
                        ValidationExpression="^[0-9]{19}$" />
                    <asp:RequiredFieldValidator ID="creditCardNotEmptyVLD" runat="server"   Style="color: #FF0000"
                        ErrorMessage="Must Enter Credit Card Number " ControlToValidate="txt_creditCardNumber" />

                   
                   
                </td>
            </tr>
            <%-- ID Custom Validator --%>
            <tr runat="server" id="tr_credit3">

                <td>
                    <label>ID:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_id"></asp:TextBox>
                    
                    
                     <asp:CustomValidator ID="idVLD" runat="server" 
          ValidateEmptyText="true"  ControlToValidate="txt_id" ErrorMessage="You must put 10 digits" OnServerValidate="idVLD_ServerValidate"
                         
           ></asp:CustomValidator>
                    



                </td>
            </tr>
            <tr runat="server" id="tr_credit4">

                <td>
                    <label>Credit Card Type:</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddl_creditCardType">
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>MasterCard</asp:ListItem>
                        <asp:ListItem>American Express</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr runat="server" id="tr_phone">

                <td>
                    <label>Phone Number:</label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txt_phoneNumber"></asp:TextBox>
                    

                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="Must be 10 numbers"
                        ControlToValidate="txt_phoneNumber"
                        ValidationExpression="^[0-9]{10,10}$" />

                      <asp:RequiredFieldValidator ID="phoneNumberVLD" runat="server"   Style="color: #FF0000"
                        ErrorMessage="Must Enter Phone Number " ControlToValidate="txt_phoneNumber" /> 
                </td>
            </tr>

            <tr runat="server" id="tr_image">

                <td>
                    <label>Signature Image:</label>
                </td>
                <td>

                    <asp:FileUpload ID="image_upload" runat="server" />
                   

                     
                </td>
            </tr>

            <tr>
                <td>

                    <asp:Button runat="server"   ID="SubmitBTN" Text="Submit" OnClick="SubmitBTN_Click" />
                   
                    <label id="purchaseCompletedLBL" runat="server"></label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerPlayerHolder" runat="Server">
  
</asp:Content>

