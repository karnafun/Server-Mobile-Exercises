using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class insertProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            CreateDropDownListItems();
        }

    }

    protected void ButtonInsert_Click(object sender, EventArgs e)
    {

        //WHAT THE FUCK - DROP DOWN LISTS!
        int Inventory = DropDownList_Inventory.SelectedIndex + 1;
        string categoryID = DropDownList_CategoryId.SelectedValue;
        int CategoryID = int.Parse(DropDownList_CategoryId.SelectedItem.Value);
       
        string FilePath = Server.MapPath(FileUpload_ImagePath.FileName);
        double price = double.Parse(TextBox_Price.Text);
        string Name = TextBox_Name.Text;

        
        Product prod = new Product(CategoryID, Name, FilePath, price, Inventory);


        Label1.Text = (" הוספת בהצלחה " + prod.Insert().ToString() + " מוצר חדש ");



        //Or's shit:
        //Product product = new Product(
        //   int.Parse(DropDownList_CategoryId.SelectedValue)
        //   , TextBox_Name.Text
        //   , FileUpload_ImagePath.FileName //!!להחליף לנתיב מלא
        //   , double.Parse(TextBox_Price.Text)
        //   , DropDownList_Inventory.SelectedIndex + 1);

        CreateDropDownListItems();
    }


    public void CreateDropDownListItems()
    {
        List<Category> cList = (new Product().GetCategoryList());
        ListItem defaultCategory = DropDownList_CategoryId.Items[0];
        DropDownList_CategoryId.Items.Clear();
        DropDownList_CategoryId.Items.Add(defaultCategory);
        for (int i = 0; i < cList.Count; i++)
        {
            ListItem listItem = new ListItem();
            listItem.Text = cList[i].Name;
            listItem.Value = cList[i].Id.ToString();
            DropDownList_CategoryId.Items.Add(listItem);

        }



        ListItem defaultInventory = DropDownList_Inventory.Items[0];
        DropDownList_Inventory.Items.Clear();
        DropDownList_Inventory.Items.Add(defaultInventory);
        for (int i = 1; i <= 10; i++)
        {
            ListItem listItem = new ListItem();
            listItem.Text = i.ToString();

            DropDownList_Inventory.Items.Add(listItem);
        }
    }

}