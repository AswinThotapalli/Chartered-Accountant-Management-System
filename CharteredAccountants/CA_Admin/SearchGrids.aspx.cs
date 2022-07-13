using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class SearchGrids : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            string strValue;
           strValue = Request.QueryString["search"];
           
            
            List<ClientsModel> list = Logic.ReturnSearchValues(strValue);
            GridViewSearch.DataSource = list;
            GridViewSearch.DataBind();

            if (list.Count == 0)
            {
                lblNoData.Text = "No Data Found for " + "\"" + strValue + "\"";
            }
            else
            {
                lblNoData.Text = ""; 
            }


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string quickSearch = TextBoxQuickSearch.Text;
            Response.Redirect("~/CA_Admin/SearchGrids.aspx?search=" + quickSearch);
        }
    }
}