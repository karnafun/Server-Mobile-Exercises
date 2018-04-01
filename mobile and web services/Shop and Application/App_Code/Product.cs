using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ExternalWebServiceReference;
/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{

    //Props - fuck fields.
    public int Id { get; set; }
    public int Category { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public float Price { get; set; }
    public int Inventory { get; set; }
    public bool Status { get; set; }
    public int OrderAmount { get; set; }

    private DBServices db = new DBServices();
    private ExternalSupplierWebService eWS = new ExternalSupplierWebService();

    //Constructors, one empty one with ALL of the info
    public Product()
    {
        OrderAmount = 1;
        //Empty Ctor to get info out of a new prod
    }
    public Product(int id, int category, string title, float price, int inventory, bool status, string imagePath)
    {


        Id = id;
        Category = category;
        Title = title;
        Price = price;
        Inventory = inventory;
        Status = status;
        ImagePath = imagePath;
        OrderAmount = 1;
    }

    public List<Product> GetAllProducts()
    {
        List<Product> allProducts = db.GetAllProducts();
        foreach (var p in eWS.GetProducts())
        {
            allProducts.Add(new Product(p.Id, p.Category, p.Title, p.Price, p.Inventory, p.Status, p.ImagePath));
        }
        return allProducts;
    }

    public void AddProduct(Product p)
    {
        db.AddProduct(p);
    }
    public bool IdIsValid(int id)
    {
        List<Product> pList = db.GetAllProducts();
        foreach (Product p in pList)
        {
            if (p.Id==id)
            {
                return false;
            }
        }
        return true;
    }

    public Product GetProduct(int id)
    {
        List<Product> pList = GetAllProducts();
        foreach (Product item in pList)
        {
            if (item.Id==id)
            {
                return item;
            }
        }
        return null;
    }

    public int GetCurrentInventory(Product p)
    {
        return db.GetInventory(p);
    }

    public DataTable GetProductsTable()
    {
        return db.GetProductsTable();
    }

    public Product OnSaleProd()
    {
        try
        {
        return db.GetAllProducts()[0];

        }
        catch (Exception)
        {
            return null;
        }
    }
}