using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            //TODO: kick user
            Response.Redirect("Login.aspx");
        }
        else
        {
            User user = (User)Session["user"];
            if (user.Type == "admin")
            {
                this.Page.MasterPageFile = "~/Admin.master";

            }
            else if (user.Type == "customer")
            {

                this.Page.MasterPageFile = "~/MasterPage.master";
            }
        }



    }
    protected void Page_Load(object sender, EventArgs e)
    {

      

        if (Session["total price"] == null) //make sure you got a cart ;)
        {
            Response.Write("Error, you reached a payment page without selecting items.");
            maindiv.InnerHtml = "";
            return;
        }
        else
        {
            var t = Session["total price"];
            float price = float.Parse(Session["total price"].ToString());
            totalPriceLBL.InnerText = "Total Price to pay: " + price.ToString();

            PaymentTypeManager();
        }
        if (IsPostBack)
        {
            //Page.Validate();
            //idVLD.Validate();

        }



    }

    protected void PaymentTypeManager()
    {

        List<HtmlTableRow> credit = new List<HtmlTableRow>();
        HtmlTableRow phone = tr_phone;
        credit.Add(tr_credit1);
        credit.Add(tr_credit2);
        credit.Add(tr_credit3);
        credit.Add(tr_credit4);

        if (cb_credit.Checked)
        {
            foreach (HtmlTableRow row in credit)
            {
                row.Visible = true;
            }
        }
        else
        {
            foreach (HtmlTableRow row in credit)
            {
                row.Visible = false;
            }
        }

        if (cb_phone.Checked)
        {
            phone.Visible = true;
        }
        else
        {
            phone.Visible = false;
        }
    }


    protected void calendarVLD_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime input;
        try
        {
            input = DateTime.Parse(calendarTB.Text);
        }
        catch (Exception)
        {

            args.IsValid = false;
            return;
        }
        DateTime maxDate;
        if (DateTime.Now.Month == 12)
        {
            maxDate = new DateTime(DateTime.Now.Year + 1, 1, DateTime.Now.Day);
        }
        else
        {
            maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
        }

        if (input <= DateTime.Now)
        {
            args.IsValid = false;

        }
        else if (input > maxDate)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }


    }

    protected void calendar_SelectionChanged(object sender, EventArgs e)
    {
        calendarTB.Text = calendar.SelectedDate.ToString();
    }

    protected void SubmitBTN_Click(object sender, EventArgs e)
    {

        // Page.Validate();
        if (Page.IsValid)
        {
            MakePurchase();
            purchaseCompletedLBL.InnerText = "Purchase Completed Successfully ! ";
        }
        else
        {
            purchaseCompletedLBL.InnerHtml = "";
        }



    }

    protected void PaymentMethodVLD_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!cb_credit.Checked && !cb_phone.Checked)
        {
            args.IsValid = false;
            PaymentMethodVLD.ErrorMessage = "Must choose paymet method";

        }
        else if (cb_credit.Checked && cb_phone.Checked)
        {
            args.IsValid = false;
            PaymentMethodVLD.ErrorMessage = "Choose only ONE payment method";
        }
        else
        {
            args.IsValid = true;
        }

    }

    protected void idVLD_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value == "")
        {
            idVLD.ErrorMessage = "Must Enter ID";
            args.IsValid = false;
            return;

        }
        if (args.Value.Length != 10)
        {
            idVLD.ErrorMessage = "Must be 10 digits";
            args.IsValid = false;
            return;
        }

        try
        {
            int x = int.Parse(args.Value);
        }
        catch (Exception)
        {
            idVLD.ErrorMessage = "Id must contain digits only";
            args.IsValid = false;
            return;
        }


        int sum = 0;
        for (var i = 0; i < args.Value.Length; i++)
        {
            sum += int.Parse(args.Value[i].ToString());
        }
        sum /= 7;
        int bikoret = Convert.ToInt32(args.Value[args.Value.Length - 1].ToString());

        if (bikoret != sum)
        {


            idVLD.ErrorMessage = "Must be 10 digits and meet the divider requirements," + sum + "is not equal to " + args.Value[args.Value.Length - 1];


        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void MakePurchase()
    {
        List<Product> pList = (List<Product>)Session["prodList"];
        User user;
        if (Session["user"]==null)
        {
             user = new User();
            user.Name = "customer1";

        }
        else
        {
             user = (User)Session["user"];
        }
       
        int paymentMethod = 0;
        if (cb_credit.Checked)
        {
            paymentMethod = 2;
        }
        else
        {
            paymentMethod = 1;
        }
     new Sale().RegisterSale(pList, user, paymentMethod); 
    }
}