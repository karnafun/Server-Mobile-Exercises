using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class Cart : System.Web.UI.Page
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


        if (!IsPostBack)
        {
            //RenderCart();
            //checkboxList = new List<CheckBox>();
            Render2();


            welcomeLBL.InnerText = "You've reached the cart page for the first time ! ";
        }
        else
        {
            Render2();
            welcomeLBL.InnerText = "Changes Saved ";
        }
       
        
    }
    public void Render2()
    {
        List<Product>  cartList = (List<Product>)Session["prodList"];
        
        double totalPrice = 0;
        cartDiv.InnerHtml = "";
        for (int i = 0; i < cartList.Count; i++)
        {
            Product p = cartList[i];
            totalPrice += p.Price;

            HtmlGenericControl div = new HtmlGenericControl("div");
           // div.ID = i.ToString();
            HtmlGenericControl title = new HtmlGenericControl("h2");
            title.InnerText = "Name: "+p.Title;
            div.Controls.Add(title);
            HtmlGenericControl price = new HtmlGenericControl("p");
            price.InnerText ="Price: "+ p.Price.ToString();
            div.Controls.Add(price);
            HtmlGenericControl inventory = new HtmlGenericControl("p");
            inventory.InnerText ="Left in Inventory: "+ p.Inventory.ToString();
            div.Controls.Add(inventory);
            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes.Add("src", p.ImagePath);
            img.Attributes.Add("style", "width:250px; height:250px;");
            div.Controls.Add(img);
            
            CheckBox cb = new CheckBox();
            cb.Checked = true;
            cb.Text = "included in Order";
            cb.ID = (i).ToString();
           cb.CheckedChanged += Cb_CheckedChanged;
            cb.AutoPostBack = true;
            div.Controls.Add(cb);


            HtmlGenericControl ddlDiv = new HtmlGenericControl("div");
            HtmlGenericControl lbl = new HtmlGenericControl("lable");
            lbl.InnerText = "Amount:";
            ddlDiv.Controls.Add(lbl);
            DropDownList ddl = new DropDownList();

            for (int j = 0; j < p.Inventory; j++)
            {
                ddl.Items.Add((j + 1).ToString());
            }
            ddl.TextChanged += Ddl_TextChanged;
            ddl.AutoPostBack = true;
            ddl.ID = (p.Id).ToString() + "ddl";
            ddlDiv.Controls.Add(ddl);
            div.Controls.Add(ddlDiv);





            //div.Attributes.Add("style", "background-color:grey;");
            div.Attributes.Add("class", "col-lg-3 col-md-6 col-xs-12");

            cartDiv.Controls.Add(div);
        }

        //HtmlGenericControl totalPriceLabel = new HtmlGenericControl("label");
        //totalPriceLabel.InnerText = "Total Price: " + totalPrice;

        //Label total = new Label();
        //total.Text = "Total Price: " + totalPrice;
        //cartDiv.Controls.Add(total);
        lbl_res.Text = "Total Price: " + totalPrice;
        Session["total price"] = totalPrice;
    }

    private void Ddl_TextChanged(object sender, EventArgs e)
    {
        //get the product of that ddl ! 
        DropDownList ddl = (sender as DropDownList);
        int id = int.Parse(ddl.ID.Substring(0, ddl.ID.Length - 3));
        Product p = new Product().GetProuct(id);

        //check if we have that amount
        int leftInInventory = p.GetCurrentInventory(p);
        if (int.Parse(ddl.SelectedValue) >leftInInventory)
        {
            lbl_res.Text += p.Title + " only has " + leftInInventory + " left in inventory!";
        }
        else
        {
            //add the amount to the product in Session["prodList"]
            foreach (Product item in (List<Product>)Session["prodList"])
            {
                if (item.Id==p.Id)
                {
                    item.OrderAmount = int.Parse(ddl.SelectedValue);
                    if (item.OrderAmount>=5)
                    {
                        lbl_discount.Text = "You get 10% off " + item.Title +" cost: "+item.Price*0.9+" instead of "+item.Price;
                        
                    }
                }
            }
            lbl_res.Text = "total price: " + CalculatePrice();
            Session["total price"] = CalculatePrice();
        }
        
        
       

    }

    //delete item from list and save it 
    private void Cb_CheckedChanged(object sender, EventArgs e)
    {
        List<Product> cartList = (List<Product>)Session["prodList"]; ;
       

        string id = (sender as CheckBox).ID;
        cartList.RemoveAt(int.Parse(id));

        Session["prodList"] = cartList;
        Render2();


    }

    //redirect to Payment
    protected void Submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("./Payment.aspx");
    }

    public float CalculatePrice()
    {
        float price = 0;
        foreach (Product item in (List<Product>)Session["prodList"])
        {

            if (item.OrderAmount>=5)
            {
                price += item.Price * item.OrderAmount*0.9f;
            }
            else
            {
                price += item.Price * item.OrderAmount;
            }
                
            
        }

        return price;
    }
}