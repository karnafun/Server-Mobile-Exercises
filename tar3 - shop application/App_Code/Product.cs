﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    string addProductCategory;
    DBServices db = new DBServices();
	public Product()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Product(string name, int price, string category)
    {
        Title = name;
        Price = price*1.4;
        addProductCategory = category;
    }


    private int id;

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }


    private string imagePath;

    public string ImagePath
    {
        get { return imagePath; }
        set { imagePath = value; }
    }


    private double price;

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    private int inventory;

    public int Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    public Category category = new Category();

    private Dictionary<string, string> attributes;

    public Dictionary<string, string> Attributes
    {
        get { return attributes; }
        set { attributes = value; }
    }

     public Product (int _categoryId, int _id, string _title, string _imagePath,  double _price, int _inventory, Dictionary<string,string> _attr)
    {
        category.Id = _categoryId;
        Id = _id;
        Title = _title;
        ImagePath = _imagePath;
        Price = _price;
        Inventory = _inventory;
        Attributes = _attr;

    }

     public Product getProduct(int productId)
     {
        return db.getProduct(productId);
     }

    public List<Product> getProducts()
    {
        return db.getList();
    }

    public string GetInfo()
    {
        return title + ", " + Price + "NIS, " + category;
    }
}