using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BindingToADropDownList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        List<String> list = new List<string>();
        list.Add("מציצים");
        list.Add("העולם על פי אגפא");
        list.Add("גבעת חלפון");
        list.Add("הלהקה");

        // connect the controls to the data source
        moviesDDL.DataSource = list;
        moviesRBL.DataSource = list;
        DataBind(); //must call this method in order to bind the  
                    //data to the control and render the HTML

    }
}
