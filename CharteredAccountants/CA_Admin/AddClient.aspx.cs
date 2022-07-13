using CharteredAccountantsFYP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CharteredAccountantsFYP.Helpers;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class AddClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            string currentIdString = Request.QueryString["ClientId"];
            //int currentId = Convert.ToInt16(currentIdString);
            if (!IsPostBack)
            {
                if (currentIdString != "" && currentIdString != null)
                {
                    ClientsModel list = Logic.ReturnEditedClientValues(Convert.ToInt16(currentIdString));
                    TextBoxName.Text = list.Name;
                    DropDownListBusinessType.SelectedIndex = list.BusinessType == null ? 0 : list.BusinessType;
                    DropDownListTypeOfCompany.SelectedIndex = list.TypeOfCompany == null ? 0 : list.TypeOfCompany.Value;
                    DropDownListLimitedby.SelectedIndex = list.LimitedBy;
                    TextBoxShareValue1.Text = Convert.ToString(list.ShareValue1);
                    TextBoxShareValue2.Text = Convert.ToString(list.ShareValue2);
                    TextBoxProductOfShareValues.Text = Convert.ToString(list.ProductOfShareValues);
                    foreach (ListItem li in CheckBoxListServices.Items)
                    {
                        if (li.Value == "1" && list.ServiceAudit == true)
                        {
                            li.Selected = list.ServiceAudit == null ? false : true; 
                        }

                        if (li.Value == "2" && list.ServiceCorporate == true)
                        {
                            li.Selected = list.ServiceCorporate == null ? false : true;
                        }

                        if (li.Value == "3" && list.ServiceAccounting == true)
                        {
                            li.Selected = list.ServiceAccounting == null ? false : true;
                        }

                        if (li.Value == "4" && list.ServiceLegal == true)
                        {
                            li.Selected = list.ServiceLegal == null ? false : true;
                        }

                        if (li.Value == "5" && list.ServiceTaxation == true)
                        {
                            li.Selected = list.ServiceTaxation == null ? false : true;
                        }
                    }

                    TextBoxNTN.Text = list.NTN;
                    TextBoxPINCode.Text = Convert.ToString(list.PINCode);
                    TextBoxFBRLogin.Text = Convert.ToString(list.FBRLogin);
                    TextBoxFBRPassword.Text = list.FBRPassword;
                    TextBoxBusinessObjectives.Text = list.BusinessObjectives;
                    TextBoxCNIC.Text = list.CNIC;
                    TextBoxIncorporationNo.Text = list.IncorporationNo;
                    TextBoxRegistration.Text = list.BusinessObjectives;
                    TextBoxRegisteredWith.Text = list.RegisteredWith;
                    TextBoxAddress.Text = list.Address;
                    TextBoxCNIC.Text = list.CNIC;
                    TextBoxEmail.Text = list.Email;
                    TextBoxPhoneNo.Text = list.PhoneNo;
                    TextBoxMobile.Text = list.MobileNo;
                    TextBoxFax.Text = list.FaxNo;

                    DropDownListBusinessType_SelectedIndexChanged(sender, e);
                    DropDownListLimitedby_SelectedIndexChanged(sender, e);
                }
            }
            if (DropDownListBusinessType.SelectedValue == "0")
            {
                TextBoxCNIC.Enabled = false;
                TextBoxIncorporationNo.Enabled = false;
                TextBoxRegistration.Enabled = false;
                DropDownListTypeOfCompany.Enabled = false;
                TextBoxFBRLogin.Enabled = false;
                
            }
            if (DropDownListLimitedby.SelectedValue == "0" || DropDownListLimitedby.SelectedValue == "2")
            {
                TextBoxShareValue1.Enabled = false;
                TextBoxShareValue2.Enabled = false;
                TextBoxProductOfShareValues.Enabled = false;
            }
                
            //if (TextBoxNoOfShares.Text != "")
            //{
            //    Int32 NoOfShares = Convert.ToInt32(TextBoxNoOfShares.Text);
            //    Int32 ShareValue = Convert.ToInt32(TextBoxShareValue.Text);
            //    Int32 Product = (NoOfShares * ShareValue);
            //    TextBoxProductOfShareValues.Text = Convert.ToString(Product);
            //}
        }


        protected void TextBoxShareValue_TextChanged(object sender, EventArgs e)
        {
            lblOnlyNumbers.Text = "";
                TextBoxProductOfShareValues.Text = "0";
                if (TextBoxShareValue1.Text != "" && TextBoxShareValue2.Text != "")//&& TextBoxShareValue.Text != 
                {
                    try
                    {

                        double NoOfShares = Convert.ToDouble(TextBoxShareValue1.Text);
                        double ShareValue = Convert.ToDouble(TextBoxShareValue2.Text);
                        double Product = (NoOfShares * ShareValue);
                        TextBoxProductOfShareValues.Text = Convert.ToString(Product);
                    }
                    catch (Exception)
                    {
                        lblOnlyNumbers.Text = "Numbers Only";
                    }
                }
        }

        protected void DropDownListBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListBusinessType.SelectedValue == "2" || DropDownListBusinessType.SelectedValue == "3")
            {
                TextBoxCNIC.Enabled = true;
                TextBoxFBRLogin.Enabled = false;
                TextBoxFBRLogin.Text = "";
                TextBoxIncorporationNo.Enabled = false;
                TextBoxIncorporationNo.Text = "";
                TextBoxRegistration.Enabled = true;
                DropDownListTypeOfCompany.Enabled = false;
                DropDownListTypeOfCompany.SelectedValue = "0";
            }
            if (DropDownListBusinessType.SelectedValue == "1")
            {
                TextBoxCNIC.Enabled = false;
                TextBoxFBRLogin.Enabled = true;
                TextBoxCNIC.Text = "";
                TextBoxIncorporationNo.Enabled = true;
                TextBoxRegistration.Enabled = false;
                TextBoxRegistration.Text = "";
                DropDownListTypeOfCompany.Enabled = true;
            }
        }

        protected void DropDownListLimitedby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListLimitedby.SelectedValue == "1")
            {
                TextBoxShareValue1.Enabled = true;
                TextBoxShareValue2.Enabled = true;
                TextBoxProductOfShareValues.Enabled = true;
            }
            if (DropDownListLimitedby.SelectedValue != "1")
            {
                TextBoxShareValue1.Text = "";
                TextBoxShareValue2.Text = "";
                TextBoxProductOfShareValues.Text = "";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            bool check = true;
            if (DropDownListBusinessType.SelectedIndex == 1 && DropDownListTypeOfCompany.SelectedIndex == 0)
            {
                check = false;
            }

            if (check)
            {
                ClientsModel Model = new ClientsModel();
                ServicesModel ModelServices = new ServicesModel();
                int postedbyId = Convert.ToInt16(Session["CurrentUserId"]);
                Model.Name = TextBoxName.Text;
                Model.BusinessType = DropDownListBusinessType.SelectedIndex;
                Model.TypeOfCompany = DropDownListTypeOfCompany.SelectedIndex;
                Model.LimitedBy = DropDownListLimitedby.SelectedIndex;
                if (TextBoxProductOfShareValues.Text != "" && TextBoxProductOfShareValues.Text != "0")
                {
                    Model.ShareValue1 = Convert.ToSingle(TextBoxShareValue1.Text);
                    Model.ShareValue2 = Convert.ToSingle(TextBoxShareValue2.Text);
                    Model.ProductOfShareValues = Convert.ToSingle(TextBoxProductOfShareValues.Text);
                }
                else
                {
                    Model.ProductOfShareValues = 0;
                    Model.ShareValue1 = 0;
                    Model.ShareValue2 = 0;
                }
                Model.BusinessObjectives = TextBoxBusinessObjectives.Text;
                //List<string> list = new List<string>();
                foreach (ListItem li in CheckBoxListServices.Items)
                {
                    if (li.Selected)
                    {
                        if (li.Value == "1")
                        {
                            ModelServices.Audit = li.Text;
                        }

                        if (li.Value == "2")
                        {
                            ModelServices.Corporate = li.Text;
                        }

                        if (li.Value == "3")
                        {
                            ModelServices.Accounting = li.Text;
                        }

                        if (li.Value == "4")
                        {
                            ModelServices.Legal = li.Text;
                        }

                        if (li.Value == "5")
                        {
                            ModelServices.Taxation = li.Text;
                        }
                    }
                    else
                    {

                    }
                }


                Model.NTN = TextBoxNTN.Text;
                Model.PINCode = Convert.ToInt32(TextBoxPINCode.Text);
                Model.FBRLogin = Convert.ToInt32(TextBoxFBRLogin.Text);
                Model.FBRPassword = TextBoxFBRPassword.Text;

                Model.CNIC = TextBoxCNIC.Text;
                Model.IncorporationNo = TextBoxIncorporationNo.Text;
                Model.RegistrationNo = TextBoxRegistration.Text;
                Model.RegisteredWith = TextBoxRegisteredWith.Text;
                Model.Address = TextBoxAddress.Text;
                Model.Email = TextBoxEmail.Text;
                Model.PhoneNo = TextBoxPhoneNo.Text;
                Model.MobileNo = TextBoxMobile.Text;
                Model.FaxNo = TextBoxFax.Text;
                string currentClientId = Request.QueryString["ClientId"];
                if (currentClientId != "" && currentClientId != null)
                {
                    int ClientId = Convert.ToInt32(currentClientId);
                    Logic.UpdatedClient(Model, ModelServices, postedbyId, ClientId);
                    lblMsg.Text = Model.Name + " Successfully Updated!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Logic.AddClient(Model, ModelServices, postedbyId);
                    lblMsg.Text = "Successfully Added!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                lblMsg.Text = "Please Select a Type of Company";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}