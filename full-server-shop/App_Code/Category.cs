using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    private DBServices db = new DBServices();
    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public List<String> GetCategoriesByName()
    {
        List<String> names = new List<string>();
        List<Category> catList = db.GetAllCategories();
        foreach (Category item in catList)
        {
            names.Add(item.Name);
        }
        return names;
    }
    public List<Category> GetAllCategories()
    {
        return db.GetAllCategories() ;
    }
    public string GetCategoryName(int id)
    {
        List<Category> catList = db.GetAllCategories();
        foreach (Category item in catList)
        {
            if (item.Id==id)
            {
                return item.Name;
            }
        }
        return null;
    }

    public bool IdIsValid(int id)
    {
        List<Category> catList = db.GetAllCategories();
        foreach (Category item in catList)
        {
            if (item.Id==id)
            {
                return false;
            }
        }
        return true;
    }


    public bool NameIsValid(string name)
    {
        List<Category> catList = db.GetAllCategories();
        foreach (Category item in catList)
        {
            if (item.Name.ToLower() == name.ToLower())
            {
                return false;
            }
        }
        return true;
    }
    public void AddCategory(Category c)
    {
        db.AddCategory(c);
    }
}