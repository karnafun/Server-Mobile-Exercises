using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private DBServices db;
    public string Name { get; set; }
    public string Type { get; set; }
    public float SalePrecentage { get; set; }
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
        db = new DBServices();
    }

    public bool Login(string username, string password)
    {
        string type = db.Login(username, password);
        switch (type)
        {
            case "admin":
                Name = username;
                Type = "admin";
                return true;
                
            case "customer":
                Name = username;
                Type = "customer";
                return true;
            default:
                return false;
                
        }
    }


    
}