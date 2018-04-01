using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ShowProduct : System.Web.UI.Page
{
  
    static List<CheckBox> cblist = new List<CheckBox>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["visited"]!=null)
            
        {//Response.Cookies!=null&&
            OfferSale(false);
        }
        else
        {
            HttpCookie visited = new HttpCookie("visited");
            visited.Expires = DateTime.Now.AddDays(500);
            Response.Cookies.Add(visited);
            cblist = new List<CheckBox>();
            OfferSale(true);
        }

       
       
        CreateProductItem();
        
    }
    protected void OfferSale(bool newUser)
    {
        float discount;
        string discountStr;
        double originalPrice;
        Product p;
        if (newUser)
        {
            discount = 0.5f;
            discountStr = "50% off !";
            p = new Product().OnSale(discount,out originalPrice);

        }
        else
        {
            discount = 0.2f;
            discountStr = "20% off !";
            p = new Product().OnSale(discount,out originalPrice);
        }


        string str = "<div id='special-offer'> <a href='#' onclick='hideSpecialOffer()'> Close </a>";
            str+="<h4 style='color:red'> Discount Item !"+discountStr+" </h4>";
        str += "<p> "+p.Title+", "+(int)p.Price+"NIS insted of "+originalPrice+"NIS  </p>";
        str += "<img src='"+p.ImagePath+"' /> </div>";

        discountDiv.InnerHtml= str;
    }

    protected void CreateProductItem()
    {
        //get products
        Product p = new Product();
        List<Product> list = p.getProducts();
        for (int i = 0; i < list.Count; i++)
        {
            Product temp = list[i];
            string catName = new Category().getCategoryName(temp.category.Id);
            //configure current product
            int prodId = list[i].Id;
            int prodInStock = list[i].Inventory;
            string prodName = list[i].Title;
            string imgLocation = list[i].ImagePath;
            string glyphiconShape = "";
            int catID = list[i].category.Id;

            HtmlGenericControl div = new HtmlGenericControl("DIV");
            div.Attributes.Add("class", "col-lg-3 col-md-6 col-xs-12 botPad");

            HtmlGenericControl div2 = new HtmlGenericControl("DIV");
            div2.Attributes.Add("class", "thumbnail");
            div2.ID = temp.Id.ToString() ;

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes.Add("src", temp.ImagePath);
            img.Attributes.Add("onClick", "createModal('" + "ContentPlaceHolder1_" + temp.Id + "')");

        HtmlGenericControl div3 = new HtmlGenericControl("DIV");
            div3.Attributes.Add("class", "caption");

            HtmlGenericControl h = new HtmlGenericControl("h2");
            h.InnerHtml = temp.Title;

            HtmlGenericControl par = new HtmlGenericControl("p");
           par.InnerHtml += " <span class='visible-xs glyphicon glyphicon-" + glyphiconShape + @"' ></span>  <span class='hidden-xs'>Category: " + catName + @"</span>
                           sold for " + temp.Price + "$";

            HtmlGenericControl par2 = new HtmlGenericControl("p");
            par2.InnerHtml += "In Stock: " + prodInStock ;

            HtmlGenericControl par3 = new HtmlGenericControl("p");
            par3.Attributes.Add("class", "hidden");
           
            for (int j = 0; j < temp.Attributes.Count; j++)
            {
                par3.InnerHtml += temp.Attributes.ElementAt(j) + "<br />";
            }

           
            div3.Controls.Add(h);
            div3.Controls.Add(par);
          
            div3.Controls.Add(par2);
            div3.Controls.Add(par3);
            div2.Controls.Add(img);
            div2.Controls.Add(div3);
            div.Controls.Add(div2);
            products.Controls.Add(div);

            
            CheckBox cb = new CheckBox();

            if (prodInStock <= 0)
            {
                cb.Enabled = false;
            }
            cb.ID = prodId + "cb";
            cblist.Add(cb);
            cb.Text = "Order Product";
            div2.Controls.Add(cb);

        }//end for i 
    }

   

 



    protected void submit_Click(object sender, EventArgs e)
    {
       //Creating a list for some reason
      
        List<Product> pList = new List<Product>();
        Product tempProducts = new Product();
        for (int i = 0; i < cblist.Count; i++)
        {
            CheckBox temp = cblist[i];
            if (temp.Checked)
            {
                string prodName = temp.ID.Remove(temp.ID.Length - 2, 2);
                
                pList.Add(tempProducts.getProduct(int.Parse(prodName)));
               
            }
          
        }
        //Printing list content to the lable 
        orderlable.Text = "Checked products: <br />";

        foreach (Product p in pList)
        {
            orderlable.Text += p.Title + ", ";
        }
        Session["prodList"] = pList;
        Response.Redirect("./Cart.aspx");

    }
}