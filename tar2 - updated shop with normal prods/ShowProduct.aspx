<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowProduct.aspx.cs" Inherits="ShowProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="js/ModalScript.js"></script>
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
    
    <div runat="server" id="discountDiv"> </div>
    <div id="center" class="container">
        <asp:Label id="orderlable" runat="server" Text=""></asp:Label>
        <div class="jumbotron">
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
<%-- Footer is here just to store the modal, i'm showing the footer from the master page --%>
<asp:Content ID="footer" ContentPlaceHolderID="footerPlayerHolder" runat="server">
    <%-- Modal --%>
     <div class="modal fade img-modal" id="img-modal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content" id="img-modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div id="img-modal-body" class="modal-body">

                </div>
                <div id="img-modal-footer" class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
    
</asp:Content>