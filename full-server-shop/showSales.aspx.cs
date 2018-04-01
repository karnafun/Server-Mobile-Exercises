using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showSales : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null || ((User)Session["user"]).Type != "admin")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            BindDLL();
            ShowAllSales();
        }
        else
        {
           // catDDL = (DropDownList)Session["catDDL"];
            BindGrid();
        }

    }

    protected void BindDLL()
    {
        List<Category> catList = new DBServices().GetAllCategories();
        Dictionary<string, int> categories = new Dictionary<string, int>();
        foreach (Category item in catList)
        {
            categories.Add(item.Name, item.Id);
        }
        catDDL.DataSource = categories.Keys;
        catDDL.DataBind();
        catDDL.SelectedIndex = 0;
        Session["catDDL"] = catDDL;
        Session["categoriesDic"] = categories;
    }

    protected void ShowAllSales()
    {
        salesGrid.DataSource = new Sale().GetSales();
        salesGrid.DataBind();
    }

    protected void BindGrid()
    {
        Dictionary<string, int> categories = (Dictionary<string, int>)Session["categoriesDic"];
        string name = catDDL.SelectedValue;
        int id = categories[name];
        Category c = new Category(id, name);
        DataTable dt = new Sale().GetSaleByCategory(c);
        salesGrid.DataSource = dt;
        salesGrid.DataBind();
        Session["salesDT"] = dt;
    }



    protected void filterBTN_Click(object sender, EventArgs e)
    {
        string name = catDDL.SelectedValue;
        BindGrid();
    }
}