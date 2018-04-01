<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        #special-offer{
            position:fixed;
            top:30%;
            left:0px;
            background-color:black;
            color:red;
            text-decoration:none;
            padding-bottom:20px;
            z-index:3;
        }
          #special-offer img{
              margin:auto;
              position:relative;
              left:10px;

          }
    </style>
    <script>
        function hideSpecialOffer() {
            $('#special-offer').hide();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div id="center" class="container">

        <asp:Label id="orderlable" runat="server" Text=""></asp:Label>
        <div class="jumbotron">
             <asp:Label ID="lbl_discount" runat="server"></asp:Label>
            <div class="row display-flex">
                <asp:PlaceHolder runat="server" ID="products">
                    
                </asp:PlaceHolder>

                <%-- I left an example product from the old store to remember the classes i used --%>

               <%-- <div class="col-lg-3 col-md-6 col-xs-12 botPad" id="exampleCol" runat="server">
                    <div id="prod01" class="thumbnail">
                        <img onclick="createModal('prod01')" src="images/carpet1.jpg" />
                       
                        <div class="caption">
                            <h2>Blue Dream </h2>
                            
                            <p> <span class="visible-xs glyphicon glyphicon-asterisk" ></span>  <span class="hidden-xs"> Hybrid</span>
                            Sold for 96 shekels per gram. hybrid</p>
                            <p class="hidden"> Blue Dream, a sativa-dominant hybrid originating in California, has achieved legendary status among West Coast strains. Crossing a Blueberry indica with the sativa Haze, Blue Dream balances full-body relaxation with gentle cerebral invigoration. Novice and veteran consumers alike enjoy the level effects of Blue Dream, which ease you gently into a calm euphoria. Some Blue Dream phenotypes express a more indica-like look and feel, but the sativa-leaning variety remains most prevalent. </p>
                        </div>
                    </div>
                </div>--%>

               
               
            </div>
            
        <%-- <div id="orderlable"  runat="server"></div>--%>
   <asp:Button runat="server" ID="submit" OnClick="submit_Click" Text="submit order"/>
           
        </div>
    </div>
   
</asp:Content>

