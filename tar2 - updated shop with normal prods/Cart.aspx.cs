using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class Cart : System.Web.UI.Page
{

    
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
            title.InnerText = p.Title;
            div.Controls.Add(title);
            HtmlGenericControl price = new HtmlGenericControl("p");
            price.InnerText ="Price: "+ p.Price.ToString();
            div.Controls.Add(price);
            HtmlGenericControl inventory = new HtmlGenericControl("p");
            inventory.InnerText ="Left in Inventory: "+ p.Inventory.ToString();
            div.Controls.Add(inventory);
            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes.Add("src", p.ImagePath);
            div.Controls.Add(img);
            
            CheckBox cb = new CheckBox();
            cb.Checked = true;
            cb.Text = "included in Order";
            cb.ID = (i).ToString();
           cb.CheckedChanged += Cb_CheckedChanged;
            cb.AutoPostBack = true;
            div.Controls.Add(cb);



            cartDiv.Controls.Add(div);
        }

        //HtmlGenericControl totalPriceLabel = new HtmlGenericControl("label");
        //totalPriceLabel.InnerText = "Total Price: " + totalPrice;

        Label total = new Label();
        total.Text = "Total Price: " + totalPrice;
        cartDiv.Controls.Add(total);

        Session["total price"] = totalPrice;
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
}