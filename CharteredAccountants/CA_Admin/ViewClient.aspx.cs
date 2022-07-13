using CharteredAccountantsFYP.Helpers;
using CharteredAccountantsFYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class ViewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            string ClientIdCheck = Convert.ToString(Session["ClientIdFromNewYear"]);
            if (ClientIdCheck == "yes")
            {
                Session["ClientIdFromNewYear"] = "no";
                Response.Redirect("ViewClient.aspx?ClientId=" + Convert.ToString(Session["ClientIdSession"]));
                
            }



            string currentIdString = Request.QueryString["ClientId"];

            

            Session["ClientIdSession"] = currentIdString;

            if (!IsPostBack)
            {
                if (currentIdString != "" && currentIdString != null)
                {
                    ClientsModel list = Logic.ReturnEditedClientValues(Convert.ToInt16(currentIdString));
                    lblClientName.Text = list.Name;
                    DropDownListBusinessType.SelectedValue = (Convert.ToString(list.BusinessType));
                    DropDownListTypeOfCompany.SelectedValue = (Convert.ToString(list.TypeOfCompany));
                    lblCNIC.Text = list.CNIC;
                    lblIncorporation.Text = list.IncorporationNo;
                    lblRegistration.Text = list.RegistrationNo;
                    lblNTN.Text = list.NTN;
                    //if (list.FBRLogin = )
                    lblFBRLogin.Text = Convert.ToString(list.FBRLogin);
                    lblFBRPassword.Text = list.FBRPassword;
                    lblPIN.Text = Convert.ToString(list.PINCode);

                }
            }
        }

        protected void HyperLinkAudit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CA_Admin/ClientAudit.aspx?ClientId=" + Request.QueryString["ClientId"]);
        }

        protected void HyperLinkTax_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CA_Admin/ClientTax.aspx?ClientId=" + Request.QueryString["ClientId"]);
        }

        protected void HyperLinkCorporate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CA_Admin/ClientCorporate.aspx?ClientId=" + Request.QueryString["ClientId"]);
        }

        protected void HyperLinkClientHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CA_Admin/ViewClient.aspx?ClientId=" + Request.QueryString["ClientId"]);
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string quickSearch = TextBoxQuickSearch.Text;
            Response.Redirect("~/CA_Admin/SearchGrids.aspx?search=" + quickSearch);
        }
    } 
}