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
        if (Session["user"] == null || ((User)Session["user"]).Type != "admin")
        {
            Response.Redirect("Login.aspx");
        }
        labelError.ForeColor = System.Drawing.Color.Red;
      
        
        if (!IsPostBack)
        {
            FillCategories();
        }
    }

    protected void FillCategories()
    {
        Category c = new Category();
        List<Category> catList = c.GetAllCategories();
        foreach (Category item in catList)
        {
            ListItem listItem = new ListItem(item.Name, item.Id.ToString());
            ddl_category.Items.Add(listItem);
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        int id = int.Parse(idTB.Text);
        string name = txt_name.Text;
        float price = float.Parse(txt_price.Text);
        Category category = new Category(int.Parse(ddl_category.SelectedValue), ddl_category.SelectedItem.Text);
        int inventory = int.Parse(txt_inventory.Text);
        bool active = false;
        if (activeCB.Checked)
        {
            active = true;
        }


        //IGNORING IMAGE FOR THE MEANWHILE
        //string str = FileUpload1.FileName;
        //FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//images//" + str);
        //string path = "~//images//" + str;

        string fname = FileUpload1.FileName;
        string path = Server.MapPath("."); // gets the path to the current directory
        string fullPath = path + "/images/" + fname;
        FileUpload1.SaveAs(fullPath); // save under full path


        // to show the image: DIV.ImageUrl = "images/" + fname;
       

        //Make sure that Product id is fine !!!!
        Product p = new Product(id,category.Id,name,price,inventory,active, "images/" + fname);
        if (p.IdIsValid(p.Id))
        {
            p.AddProduct(p);
            lbl_res.Text = "Product Added Successfully";
        }
        else
        {
           // Session["fileUpload"] = FileUpload1;
            //Tell the user he cant use this id !!!!!
            lbl_res.Text = "This product id is already taken, please choose another one";
            
        }
       
        // lbl_res.Text += " <br /> Product added: " + p.GetInfo();
        labelError.Text = "";
    }

}