using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{
    DataSet ds;
    SqlDataAdapter da;
    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
        ds = new DataSet();
    }

    public List<Category> GetAllCategories()
    {
        SqlConnection con = new SqlConnection();
        try
        {
            con = Connect("test2DBConnectionString");
            List<Category> catList = new List<Category>();
            SqlCommand cmd = new SqlCommand("select * from category", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                catList.Add(new Category((int)reader[0], reader[1].ToString()));
            }
            return catList;
        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            return null;

        }
        finally
        {
            con.Close();
        }

    }

    public List<Product> GetAllProducts()
    {
        SqlConnection con = new SqlConnection();
        try
        {
            List<Product> prodList = new List<Product>();
            con = Connect("test2DBConnectionString");
            string cmdSTR = "select * from productN";
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                //Product : id, category, title, price, inventory status 
                int id = int.Parse(reader[0].ToString());
                int categoryId = int.Parse(reader[1].ToString());
                string title = reader[2].ToString();
                string imagePath = reader[3].ToString();
                float price = float.Parse(reader[4].ToString());
                int inventory = int.Parse(reader[5].ToString());
                bool active = bool.Parse(reader[6].ToString());

                Product temp = new Product(id, categoryId, title, price, inventory, active, imagePath);
                prodList.Add(temp);
            }
            return prodList;
        }
        catch (Exception ex)
        {
            string str = ex.ToString();
            //TODO:Add Exeption
            return null;
        }
        finally
        {
            con.Close();
        }

    }

    public void AddCategory(Category c)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            con = Connect("test2DBConnectionString");
            string cmdSTR = "insert into category values('" + c.Id + "','" + c.Name + "' )";
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            var t = ex.ToString();

        }
        finally
        {
            con.Close();
        }
    }

    private SqlConnection Connect(string v)
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings[v].ConnectionString);
        con.Open();
        return con;
    }

    public void AddProduct(Product p)
    {
        SqlConnection con = new SqlConnection();
        try
        {

            con = Connect("test2DBConnectionString");
            string commandSTR = string.Format("insert into productN values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                p.Id, p.Category, p.Title, p.ImagePath, p.Price, p.Inventory, p.Status);
            SqlCommand cmd = new SqlCommand(commandSTR, con);
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {

            con.Close();
        }

    }

    public string Login(string _username, string _password)
    {
        SqlConnection con = new SqlConnection();
        try
        {

            con = Connect("test2DBConnectionString");
            string cmdSTR = "select * from [user]";
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string username = reader[0].ToString();
                string password = reader[1].ToString();
                string type = reader[2].ToString();
                if (username == _username && password == _password)
                {
                    return type;
                }
            }
            return "invalid";
        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            return null;
        }
        finally
        {

            con.Close();
        }
    }

    public int GetInventory(Product p)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            con = Connect("test2DBConnectionString");
            string cmdSTR = "select inventory from productN where productId = " + p.Id;
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return int.Parse(reader[0].ToString());
            }
            return -1;
        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            return -1;
        }
        finally
        {
            con.Close();
        }
    }

    public void RegisterSale(Product p, int amount, float price, User user, int paymentMethod)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            //Register the sale:
            con = Connect("test2DBConnectionString");

            string cmdSTR = string.Format("Insert into Sale (productId,price,quantity,customer,[date],paymentMethod)" +
                "values({0}, {1}, {2}, '{3}', '{4}', {5} )",
                p.Id, price, p.OrderAmount, user.Name, DateTime.Now.ToString(new CultureInfo("en-GB")), paymentMethod);
            string test = DateTime.Now.ToShortTimeString();
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            cmd.ExecuteNonQuery();

            //Update the inventory for that item:
            con.Close();
            UpdateInventory(p.Id, p.Inventory - p.OrderAmount); //Already verified that we have that amount in inventory (cart.aspx.cs)
        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            Alert.Show(t);

        }
        finally
        {
            con.Close();
        }
    }

    public void UpdateInventory(int prodID, int newAmount)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            con = Connect("test2DBConnectionString");
            string cmdSTR = "update ProductN set inventory = " + newAmount + " where productId = " + prodID;
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            var t = ex.ToString();

        }
        finally
        {
            con.Close();
        }
    }


    //Dataset shit
    public DataTable GetProductsTable()
    {
        SqlConnection con = new SqlConnection();
        try
        {
            con = Connect("test2DBConnectionString");
            string cmdSTR = "select * from productn";
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {

            var t = ex.ToString();
            return null;
        } finally { con.Close(); } //connect opens a connection even when i use data adapter 
    }

    public DataTable GetSaleTable()
    {
        SqlConnection con = new SqlConnection();
        try
        {
            DataTable dt = new DataTable();
            con = Connect("test2DBConnectionString");
            string cmdSTR = "select * from sale ";
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            return null;
        }
        finally { con.Close(); }
    }


    public DataTable GetSalesByCategory(Category c)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            DataTable dt = new DataTable();
            con = Connect("test2DBConnectionString");
            string cmdSTR = "select * from  SalesWithCategories where categoryId =" + c.Id;
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            return null;
        }
        finally { con.Close(); }
    }


    public DataTable GetSalesView()
    {
        SqlConnection con = new SqlConnection();
        try
        {
            DataTable dt = new DataTable();
            con = Connect("test2DBConnectionString");
            string cmdSTR = "select * from  SalesWithCategories";
            SqlCommand cmd = new SqlCommand(cmdSTR, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        catch (Exception ex)
        {
            var t = ex.ToString();
            return null;
        }
        finally { con.Close(); }
    }
}