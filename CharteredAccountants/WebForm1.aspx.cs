using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListImageAndName();
            }
        }

        protected void DropDownListImageAndName()
        {
            DataContext db = new DataContext();
            var UserNamesDD = from u in db.TblUsers
                              //where u.IsAdmin == false
                              //orderby u.Name
                              select new
                              {
                                  u.Name,
                                  u.imageURL
                              };
            DropDownListAssignee.DataSource = UserNamesDD;
            DropDownListAssignee.DataValueField = "imageURL";
            DropDownListAssignee.DataTextField = "Name";
            DropDownListAssignee.DataBind();

            foreach (ListItem ListItem in DropDownListAssignee.Items)
            {
                ListItem.Attributes["title"] = ListItem.Value;
            }
            DropDownListAssignee.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
}