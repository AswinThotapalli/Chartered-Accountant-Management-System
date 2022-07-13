using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP
{
    public partial class MasterAdmin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        { 
            string email = Convert.ToString(Session["CurrentUserEmail"]);
            //lblloginName.Text = email;
            string url = Logic.ReturnImageURLByEmail(email);
            string UserName = Logic.ReturnName_ByEmail(email);
            lblname.Text = UserName;
            ImageLogin.ImageUrl = "~/Uploads/UserImages/UserDDLImages/" + url;
        }

    }
}