using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{

    DBServices db = new DBServices();
    private int categoryId;//    -	categoryId המכיל את מספר הקטגוריה(int)
    private string title;//-	title המכיל את שם המוצר(string)
    private string imagePath;//-	imagePath לינק לתמונה(string)
    private double price;//-	Price מחיר המוצר(double)
    private int inventory;//-	Inventory כמות במלאי(int)







    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Product(int categoryId, string title, string imagePath, double price, int inventory)
    {
        CategoryId = categoryId;
        Title = title;
        ImagePath = imagePath;
        Price = price;
        Inventory = inventory;
    }
    public int Insert()
    {
        DBServices dBservices = new DBServices();
        return dBservices.Insert(this);
    }

    public int CategoryId
    {
        get
        {
            return categoryId;
        }

        set
        {
            categoryId = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public string ImagePath
    {
        get
        {
            return imagePath;
        }

        set
        {
            imagePath = value;
        }
    }

    public double Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public int Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }


    public List<Category> GetCategoryList()
    {
        return db.getCategory();
    }
}