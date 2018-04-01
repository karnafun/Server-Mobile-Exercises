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
        try
        {
            price = float.Parse(txt_price.Text);
        }
        catch (Exception)
        {
            labelError.ForeColor = System.Drawing.Color.Red;
            labelError.Text = "Enter a numeric value in price";
            return;
            
        }
        labelError.Text = "";
        string descrption = txtarea_description.Value;
        string category = ddl_category.SelectedValue;

        Product p = new Product(name, descrption, price, category);
        lbl_res.Text += " <br /> Product added: " + p.GetInfo();

    }
    
}