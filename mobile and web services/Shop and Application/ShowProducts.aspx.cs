using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ShowProducts : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            //TODO: kick user
            Response.Redirect("Login.aspx");
        }
        else
        {
            User user = (User)Session["user"];
            if (user.Type == "admin")
            {
                this.Page.MasterPageFile = "~/Admin.master";

            }
            else if (user.Type == "customer")
            {

                this.Page.MasterPageFile = "~/MasterPage.master";
            }
        }



    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.Cookies["visited"] != null)

        {//Response.Cookies!=null&&
            OfferSale(false);
        }
        else
        {
            HttpCookie visited = new HttpCookie("visited");
            visited.Expires = DateTime.Now.AddDays(500);
            Response.Cookies.Add(visited);

            OfferSale(true);
        }
        if (!IsPostBack)
        {
            Session["cbList"] = new List<CheckBox>();
        }

        CreateProductItem();
    }
    protected void OfferSale(bool newUser)
    {
        float discount;
        string discountStr;
        double originalPrice;
        Product p = new Product().OnSaleProd();
        User user = (User)Session["user"];
        if (newUser)
        {
            discount = 0.5f;
            discountStr = "50% off !";
            
            user.SalePrecentage = 0.5f;
            //p = new Product().OnSale(discount, out originalPrice);

        }
        else
        {
            discount = 0.2f;
            discountStr = "20% off !";
           
            user.SalePrecentage = 0.2f;
        }
      
        Session["user"] = user;
        if (p == null)
        {
            return;
        }
        lbl_discount.Text = "You have " + discountStr + " on " + p.Title;
    }
    protected void CreateProductItem()
    {
        //get products
        Product p = new Product();
        List<Product> list = p.GetAllProducts();
        List<CheckBox> cbList;
        cbList = new List<CheckBox>();
        //if (Session["cbList"] == null)
        //{
        //    cbList = new List<CheckBox>();
        //}
        //else
        //{
        //    cbList = (List<CheckBox>)Session["cbList"];
        //}
        for (int i = 0; i < list.Count; i++)
        {
            Product temp = list[i];
            if (!temp.Status)
            {
                continue;
            }
            string catName = new Category().GetCategoryName(temp.Category);
            //configure current product
            int prodId = list[i].Id;
            int prodInStock = list[i].Inventory;
            string prodName = list[i].Title;
            string imgLocation = list[i].ImagePath;
            string glyphiconShape = "";
            int catID = list[i].Category;

            HtmlGenericControl div = new HtmlGenericControl("DIV");
            div.Attributes.Add("class", "col-lg-3 col-md-6 col-xs-12 botPad");

            HtmlGenericControl div2 = new HtmlGenericControl("DIV");
            div2.Attributes.Add("class", "thumbnail");
            div2.ID = temp.Id.ToString();

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes.Add("src", temp.ImagePath);
            // img.Attributes.Add("onClick", "createModal('" + "ContentPlaceHolder1_" + temp.Id + "')");

            HtmlGenericControl div3 = new HtmlGenericControl("DIV");
            div3.Attributes.Add("class", "caption");

            HtmlGenericControl h = new HtmlGenericControl("h2");
            h.InnerHtml = temp.Title;

            HtmlGenericControl par = new HtmlGenericControl("p");
            par.InnerHtml += " <span class='visible-xs glyphicon glyphicon-" + glyphiconShape + @"' ></span>  <span class='hidden-xs'>Category: " + catName + @"</span>
                           sold for " + temp.Price + "$";

            HtmlGenericControl par2 = new HtmlGenericControl("p");
            par2.InnerHtml += "In Stock: " + prodInStock;

            //HtmlGenericControl par3 = new HtmlGenericControl("p");
            //par3.Attributes.Add("class", "hidden");

            //for (int j = 0; j < temp.Attributes.Count; j++)
            //{
            //    par3.InnerHtml += temp.Attributes.ElementAt(j) + "<br />";
            //}


            div3.Controls.Add(h);
            div3.Controls.Add(par);

            div3.Controls.Add(par2);
            //div3.Controls.Add(par3);
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
            cbList.Add(cb);
            cb.Text = "Order Product";
            div2.Controls.Add(cb);
        



        }//end for i 
        Session["cbList"] = cbList;
    }


    protected void submit_Click(object sender, EventArgs e)
    {


        List<Product> pList = new List<Product>();
        Product tempProducts = new Product();
        if (Session["cbList"] == null)
        {
            var t = "pizda";
        }
        List<CheckBox> cbList = (List<CheckBox>)Session["cbList"];

        for (int i = 0; i < cbList.Count; i++)
        {
            CheckBox temp = cbList[i];
            if (temp.Checked)
            {
                string prodName = temp.ID.Remove(temp.ID.Length - 2, 2);

                pList.Add(tempProducts.GetProduct(int.Parse(prodName)));

            }

        }
        //Printing list content to the lable 
        //orderlable.Text = "Checked products: <br />";

        //foreach (Product p in pList)
        //{
        //    orderlable.Text += p.Title + ", ";
        //}
        Session["prodList"] = pList;
        Response.Redirect("./Cart.aspx");

    }
}