using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class codeBuiltGridView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        #region create table

        DataTable dt = new DataTable("movies");
        dt.Columns.Add("מספר");
        dt.Columns.Add("שם הסרט");
        dt.Columns.Add("שם הבמאי");

        #endregion

        #region add some data to the table
        AddRow(dt,"1", "מציצים" , "אורי זהר");
        AddRow(dt,"2", "גבעת חלפון" , "אסי דיין");
        AddRow(dt,"3", "השוטר אזולאי" , "אפריים קישון");
        #endregion


        #region create gridview and set its datasource and some parameters
        GridView grdv = new GridView(); // create a new datagrid
        grdv.DataSource = dt;           // make a link of to the table

        // the following lines will set some gridview properties, just to show that we can change them programatically
        grdv.ForeColor = Color.Maroon;
        grdv.ControlStyle.BorderStyle = BorderStyle.Double;
        grdv.ControlStyle.BorderWidth = 10;
        #endregion 


        grdv.DataBind();               // bind the control view to the data

        Page.Form.Controls.Add(grdv);  // Add the gridview to the page
    
    }

    //----------------------------------------------------------------------------
    // This method is adding data to a table by passing the parameters
    //----------------------------------------------------------------------------
    private void AddRow(DataTable dt, params String[] par) {

        DataRow dr = dt.NewRow(); // create a new row
        
        for (int i = 0; i < par.Length ; i++) {
             dr[i] = par[i];      //fill the row with the data
        }

        dt.Rows.Add(dr);          // add the row to the table
            
    }
}
