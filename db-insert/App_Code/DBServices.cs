using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{
    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Insert(Product product)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = Connect("ProductDBConnectionString");
            

        }
        catch (Exception excep)
        {
            throw(excep);
        }

        cmd = CreateCommand(BuildInsertCommandProduct(product),con);

        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            return 0;
            throw(ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        
    }

    private SqlCommand CreateCommand(string commandStr, SqlConnection con)
    {
        SqlCommand command = new SqlCommand();
        command.Connection = con;
        command.CommandText = commandStr;
        command.CommandTimeout = 15;
        command.CommandType = System.Data.CommandType.Text;
        return command;
    }

    private string BuildInsertCommandProduct(Product product)
    {
        return string.Format(
            "INSERT INTO dbo.Product " + "(categoryId, title ,imagePath ,price ,Inventory)" +
            "  Values('{0}','{1}','{2}','{3}','{4}')"
            , product.CategoryId, product.Title, product.ImagePath, product.Price, product.Inventory);
    }

    private SqlConnection Connect(string v)
    {
       
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[v].ConnectionString);
        con.Open();
        return con;
    }






    /*
     * Category From Another Targil ! 
     * 
     */
    public List<Category> getCategory()
    {
        List<Category> ls1 = new List<Category>();

        ls1.Add(new Category(1, "chair", 6));
        ls1.Add(new Category(2, "table", 4));
        ls1.Add(new Category(3, "armchair", 7));
        ls1.Add(new Category(4, "bed", 9));
        ls1.Add(new Category(5, "carpet", 7));
        ls1.Add(new Category(6, "shelf", 4));
        ls1.Add(new Category(7, "sofa", 5));
        ls1.Add(new Category(8, "stool", 4));
        ls1.Add(new Category(9, "wardrobe", 5));


        return ls1;

    }

   
}