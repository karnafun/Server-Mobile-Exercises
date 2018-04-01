using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sale
/// </summary>
public class Sale
{
    DBServices db;
    public Sale()
    {
        db = new DBServices();
        //
        // TODO: Add constructor logic here
        //
    }

    public void RegisterSale(List<Product> products,User customer,int paymentMethod)
    {
       // string res = "";
        foreach (Product item in products)
        {
            int amount = item.OrderAmount;
            float price = 0;
            if (amount>=5)
            {
                price = item.Price * 0.9f * amount;
            }
            else
            {
                price = item.Price * amount;
            }
           // DateTime date = DateTime.Now;

           db.RegisterSale(item, amount, price, customer, paymentMethod);
           // res += string.Format("sale details: {0}, {1} ,{2}, {3}, {4}, {5}", item, item.OrderAmount, price, customer.Name, date, paymentMethod);
        }
       // return res;
    }


    public DataTable GetSaleByCategory(Category c)
    {
        return db.GetSalesByCategory(c);
    }

    public DataTable GetSales()
    {
        return db.GetSalesView();
    }
}