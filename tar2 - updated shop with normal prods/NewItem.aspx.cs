using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        labelError.ForeColor = System.Drawing.Color.Red;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {

        string name = txt_name.Text;
        float price = 0;
       
            price = float.Parse(txt_price.Text);
       
       
        labelError.Text = "";
        string inventory = txt_inventory.Text;
        string category = ddl_category.SelectedValue;


        Product p = new Product(name,  (int)price, category);
        lbl_res.Text += " <br /> Product added: " + p.GetInfo();

    }
    
}