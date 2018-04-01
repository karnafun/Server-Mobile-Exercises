using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"]==null || ((User)Session["user"]).Type!= "admin")
        {
            Response.Redirect("Login.aspx");
        }

        FillCategoryList();
    }
    protected void FillCategoryList()
    {
        Category c = new Category();
        List<Category> catList = c.GetAllCategories();
        string categories = "<h3> Existing Categories </h3>";
        categories += "<table> <th>ID</th><th>Name</th>";

        foreach (Category item in catList)
        {
            categories += "<tr>";
            categories += "<td>" + item.Id + "</td>";
            categories += "<td>" + item.Name + "</td>";
            categories += "</tr>";
        }
        categories += "</table>";
        listDiv.InnerHtml = categories;
    }



    protected void submitBTN_Click(object sender, EventArgs e)
    {
        Category c = new Category();
        int id = int.Parse(idTB.Text);
        string name = nameTB.Text;
        if (c.IdIsValid(id))
        {
            if (c.NameIsValid(name))
            {
                //Add Category ! 
                c.AddCategory(new Category(id, name));
                lbl_res.Text = "Category added successfully";
                FillCategoryList();
            }
            else
            {
                lbl_res.Text = "This Name is already taken. Please choose a valid name";
            }

        }
        else
        {
            lbl_res.Text = "This ID is already taken. Please choose a valid id";
        }
    }
}