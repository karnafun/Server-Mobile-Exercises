using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class classEx_part_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DBservices dbs = new DBservices();
        try
        {
            dbs = dbs.ReadFromDataBase("moviesDBconnectionString", "movies", "name");
        }
        catch (Exception ex) {
            Response.Write("Unable to read from the database " + ex.Message);
            return;
        }

        // copy the names from the table into a list
        List<string> names = new List<string>();
        foreach (DataRow dr in dbs.dt.Rows)
        {
            names.Add((string)dr["name"]);
        }

        // dynamically create a dropdown list (aka DDL)
        DropDownList ddl = new DropDownList();
        ddl.DataSource = names; // set the data source
        ddl.DataBind(); // bind the data to the DDL control
        form1.Controls.Add(ddl); // add the DDL control to the page
    }
}