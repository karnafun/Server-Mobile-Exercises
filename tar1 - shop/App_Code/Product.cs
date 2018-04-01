using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
   
    private string name;
    private string description;
    private float price;
    private string category;

   

    public float Price
    {
        get { return price; }
        set
        {
            price = value * 1.4f;
        }
    }

    public Product(string name, string description, float price, string category)
    {
        this.name = name;
        this.description = description;
        Price = price;
        this.category = category;
    }
    
    public string GetInfo()
    {
        return $"{name}, at the price of {Price} in category {category}";
    }
}
