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

    //----------------------------------------------------------------------------------
    // This method is called every time there is a change in the selection
    // in the radio button list
    //----------------------------------------------------------------------------------
    protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rbl = (RadioButtonList)sender;
        GridViewRow grdvw_rw = (GridViewRow)rbl.Parent.Parent; // get the row in the grid
        int index = GetColumnIndexByName(moviesGRDVW, "name");
        if (index != -1)
        {
            string name = grdvw_rw.Cells[index].Text;
            Response.Write("The name of the selected movie is " + name);
        }
        else {
            Response.Write("name is not one of the fields in the grid");
        }
    }

    //----------------------------------------------------------------------------------
    // This returns the index of the column given its name
    //----------------------------------------------------------------------------------
    public static int GetColumnIndexByName(GridView grid, string name)
    {
        foreach (DataControlField col in grid.Columns)
        {
            if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
            {
                return grid.Columns.IndexOf(col);
            }
        }

        return -1; // in case there in no such field
    }


    //----------------------------------------------------------------------------------
    // This method is activated every time a row is bounded to the data
    //----------------------------------------------------------------------------------
    public void moviesGRDVW_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text == "1971")
                e.Row.BackColor = System.Drawing.Color.Yellow;
        }

    }


}
