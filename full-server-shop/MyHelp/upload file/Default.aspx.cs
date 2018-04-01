using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        string fname = imageFU.FileName;
        string path = Server.MapPath("."); // gets the path to the current directory
        imageFU.SaveAs(path + "/images/" + fname); // save under full path
        stamImage.ImageUrl = "images/" + fname;



    }
}