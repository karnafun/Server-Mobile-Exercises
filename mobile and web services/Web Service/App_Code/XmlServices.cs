using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for XmlServices
/// </summary>
public class XmlServices
{
    string xmlPath =  "C:/inetpub/wwwroot/bgroup62/test2/tar5/EsProducts.xml";//"../../test/file.xml"; //
    public XmlServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private void CreateXmlFile()
    {

    }

    internal List<Product> GetAllProducts()
    {
        List<Product> prods = new List<Product>();
       
        XDocument dc;
        try //if xml doesnt exist, build it
        {
            dc = XDocument.Load(xmlPath);
        }
        catch (Exception)
        {
            ProductsXMLCreation();
            dc = XDocument.Load(xmlPath);
        }
        
        XElement root = dc.Root;
        

        foreach (XElement item in root.Elements())
        {
            int categoryId = int.Parse(item.Element("category").Value);
              int id= int.Parse(item.Element("id").Value);
            string title = item.Element("title").Value;
            string imgPath = item.Element("image").Value;
            float price = float.Parse(item.Element("price").Value);
            int inventory = int.Parse(item.Element("inventory").Value);
            bool status= bool.Parse(item.Element("status").Value);
            Product p = new Product(id,categoryId,title,price,inventory,status,imgPath);
            prods.Add(p);

        }
        return prods;
    }

    private void ProductsXMLCreation()
    {
        XDocument doc = new XDocument(new XElement("root"));


        //first product
        XElement category = new XElement("category", 100);
        XElement id = new XElement("id", 200);
        XElement title = new XElement("title", "DMT Changa ES");
        XElement image = new XElement("image", "https://azarius.net/media/images/encyclopedie/8changamixdetail.jpg");
        XElement price = new XElement("price", 500);
        XElement inventory = new XElement("inventory", 800);
        XElement status = new XElement("status", true);

        // add first product
        XElement product = new XElement("product", id, category, title, image, price, inventory, status);
        doc.Root.Add(product);


        //second product
        category = new XElement("category", 100);
        id = new XElement("id", 201);
        title = new XElement("title", "Bong ES");
        image = new XElement("image", "https://stc.grasscity.com/media/catalog/product/cache/4/image/9df78eab33525d08d6e5fb8d27136e95/2/6/261818-35-_black_-_03__2.jpg");
        price = new XElement("price", 400);
        inventory = new XElement("inventory", 800);
        status = new XElement("status", true);

        // add secondproduct
        product = new XElement("product", id, category, title, image, price, inventory, status);
        doc.Root.Add(product);




        //second product
        category = new XElement("category", 100);
        id = new XElement("id", 202);
        title = new XElement("title", "Crack Pipe ES");
        image = new XElement("image", "https://shop.r10s.jp/sodom-gomorrah/cabinet/pipe_photos/nd-161806s-1.jpg");
        price = new XElement("price", 400);
        inventory = new XElement("inventory", 800);
        status = new XElement("status", true);

        // add secondproduct
        product = new XElement("product", id, category, title, image, price, inventory, status);
        doc.Root.Add(product);

        //save all products
        doc.Save(xmlPath);
        // return doc;
    }
}