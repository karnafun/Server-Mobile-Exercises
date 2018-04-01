using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inventoryManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || ((User)Session["user"]).Type != "admin")
        {
            Response.Redirect("Login.aspx");
        }
    }
    
    //Gridview Select btn
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Write(((GridView)sender).SelectedRow.ID);
        //DropDownList ddl = new DropDownList();
        //gridviewDiv.Controls.Add(ddl);
    }

    //Before executing the update command
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       //IDK how to pop a confirm message.
       //Didnt find the "update" button in the aspx file.
       //crap...
    }
}