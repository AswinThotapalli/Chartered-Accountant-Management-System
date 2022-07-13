using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class AddNewYear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            Session["ClientIdFromNewYear"] = "yes";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string year = TextBoxYear.Text;
            if (Logic.ValidateYear(Convert.ToInt16(year)))
            {
                Logic.AddNewYear(Convert.ToInt16(year));
                lblMsg.Text = "Successfully Added! ";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                
            }
            else
            {
                lblMsg.Text = "Year Already Exists! ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        //{
        //    string ClientId = Convert.ToString(Session["ClientId"]);
        //    Response.Redirect("ViewClient.aspx?ClientId=" + ClientId);
        //}

    }
}