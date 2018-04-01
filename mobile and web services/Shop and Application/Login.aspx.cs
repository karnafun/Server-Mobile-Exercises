using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        User user = new User();
        string username = usernameTB.Text;
        string password = passwordTB.Value;
        if (user.Login(username,password))
        {
            //Login successfull ! 
            string type = user.Type;
            Session["user"] = user;
            Response.Redirect("ShowProducts.aspx");
        }
        else
        {
            lbl_res.Text = "Incorrect Username or password";
        }


        Response.Write(user.Type);
    }
}