using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CharteredAccountantsFYP.Helpers;

namespace CharteredAccountantsFYP
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Convert.ToString(Session["CurrentUserId"]);

            if (userId != "")
            {
                Logic.LogOut_IsOnline(Convert.ToInt32(userId));
                Session["CurrentUserId"] = "";
            }

            Session["loginAdmin"] = -1;
            Session["loginUser"] = -1;
        }
        protected void LoginButton_Click(object sender, ImageClickEventArgs e)
        {
                if (Logic.IsAuthenticatAdmin(TextBoxUserEmail.Text, TextBoxPassword.Text))
                {
                    int CurrentUserId = Logic.ReturnID_ByEmail(TextBoxUserEmail.Text);
                    Logic.Login_IsOnline(CurrentUserId);

                    Session["CurrentUserId"] = CurrentUserId;
                    Session["CurrentUserEmail"] = TextBoxUserEmail.Text;
                    Session["loginAdmin"] = "admin";
                    Response.Redirect(@"CA_Admin\AdminHome.aspx");
                }
                else if (Logic.IsAuthenticatUser(TextBoxUserEmail.Text, TextBoxPassword.Text))
                {
                        int CurrentUserId = Logic.ReturnID_ByEmail(TextBoxUserEmail.Text);
                        Logic.Login_IsOnline(CurrentUserId);
                        Session["loginUser"] = "user";
                        Session["CurrentUserEmail"] = TextBoxUserEmail.Text;
                        Session["CurrentUserId"] = CurrentUserId;// Send it to user "WebFormUserHome.aspx"
                        Response.Redirect(@"CA_User\UserHome.aspx");
                }
                else
                {
                    LblMsg.Text = "Wrong Credentials";
                }
        }

    }
}



//if (CheckBoxIsAdmin.Checked)
//            {

//                if (Logic.IsAuthenticatAdmin(TextBoxUserEmail.Text, TextBoxPassword.Text, CheckBoxIsAdmin.Checked))
//                {
//                    int CurrentUserId = Logic.ReturnID_ByEmail(TextBoxUserEmail.Text);
//                    Session["CurrentUserId"] = CurrentUserId;
//                    Session["loginAdmin"] = 1;
//                    Response.Redirect(@"CA_Admin\AdminHome.aspx");
//                }
//                else
//                {
//                    LblMsg.Text = "Wrong Credentials";
//                }

//            }
//            else
//            {
//                if (Logic.IsAuthenticatUser(TextBoxUserEmail.Text, TextBoxPassword.Text))
//                {
                    
//                    if (Logic.IsAuthenticatUserCheck(TextBoxUserEmail.Text, CheckBoxIsAdmin.Checked))
//                    {
//                        int CurrentUserId = Logic.ReturnID_ByEmail(TextBoxUserEmail.Text);
//                        Session["loginUser"] = 2;
//                        Session["CurrentUserId"] = CurrentUserId;// Send it to user "WebFormUserHome.aspx"
//                        //Session["EditID"] = EmailID;// Send it to user "WebFormUserHome.aspx"
//                        //Session["CurrentEmail"] = TextBoxUserEmail.Text;
//                        //String NameOfPostingAdd = Logic.ReturnNameByEmail(TextBoxUserEmail.Text);
//                        //Session["NameOfPostingAdd"] = NameOfPostingAdd;
//                        Response.Redirect(@"CA_User\UserHome.aspx");
//                    }
//                    else
//                    {
//                        LblMsg.Text = "Wrong Credentials";
//                    }
//                }
//                else
//                {
//                    LblMsg.Text = "Wrong Credentials";
//                }