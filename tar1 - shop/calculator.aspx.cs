using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class calculator : System.Web.UI.Page
{
    public float calculation = float.NaN;
    public char sign;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void multi_Click(object sender, EventArgs e)
    {
        float res = float.Parse(txt_first.Text) * float.Parse(txt_second.Text);
        Response.Write(res);
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        float res = float.Parse(txt_first.Text) + float.Parse(txt_second.Text);
        Response.Write(res);
    }

    protected void btn_calc_Click(object sender, EventArgs e)
    {

    }

    protected void txt_calc_TextChanged(object sender, EventArgs e)
    {
        Response.Write("test");
        char c = txt_calc.Text[txt_calc.Text.Length - 1];
        if ( c== '+' || c == '-'|| c == '*'|| c == '/')
        {
            string str = txt_calc.Text;
            char sign = str[str.Length - 1];
            float num = float.Parse(str.Split(sign)[0]);
            Think(num);
            txt_calc.Text = "";
            
        }
        Response.Write(calculation);
        
    }

    private void Think(float num)
    {
        if (calculation ==float.NaN)
        {
            calculation = num;
            return;
        }
        if (sign=='-')
        {
            calculation -= num;
        }
        else if (sign == '+')
        {
            calculation += num;
        }
        else if (sign == '*')
        {
            calculation *= num;
        }
        else if (sign == '/')
        {
            calculation /= num;
        }
        else
        {
            Response.Write("invalid sign");
        }
        Response.Write(calculation);
    }

   
}