using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExternalWebServiceReference;
public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Product p = new Product();
        var all = p.GetAllProducts();
        var one = p.GetProduct(200);
        Console.WriteLine("HELLOZSDAS");
    }
}