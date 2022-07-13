using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void ChangePass_Click(object sender, ImageClickEventArgs e)
        {
            int C_ID = Convert.ToInt32(Session["CurrentUserId"]);
            string currentPass = TextBoxCurrentPass.Text;
            bool checkPass = Logic.CheckCurrentPassword(C_ID, currentPass);
            if (checkPass)
            {
                if (currentPass == TextBoxNewPassword.Text)
                {
                    lblError.Text = "Your New Password is Already your Current Password";
                }
                else
                {
                    Logic.UpdatedPassword(C_ID, TextBoxNewPassword.Text);
                    Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                lblError.Text = "Sorry your current Password is wrong";
            }
        }
    }
}