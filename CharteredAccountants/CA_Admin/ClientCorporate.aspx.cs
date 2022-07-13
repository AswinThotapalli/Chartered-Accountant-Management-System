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
    public partial class ClientCorporate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                DropDownListYears();
                Populate();
            }
        }

        protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Populate();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int userId = Convert.ToInt16(Session["CurrentUserId"]);
            int currentClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
            string yearValue = Convert.ToString(DropDownListYear.SelectedValue);

            ClientsModel modelValues = Logic.returnClientCorporateDataByClientIdAndYear(currentClientId, Convert.ToInt32(yearValue));

            ClientsModel model = new ClientsModel();
            model.UpdatedById = userId;
            model.UserId = userId;
            model.LastChanges = textareaLastDiscription.InnerText;
            model.YearId = Convert.ToInt32(yearValue);

            if (textareaLastDiscription.InnerText != "" && FileUpload1.HasFile)
            {
                if (modelValues == null)
                {
                    // NEW
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf" && fileExtension != "" && fileExtension != ".xlsx")
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Only files with .docx, .xlsx and .pdf extension are allowed";
                    }
                    else
                    {

                        int fileSize = FileUpload1.PostedFile.ContentLength;

                        int UniqueId = Logic.ReturnUniqueId();
                        UniqueId++;
                        //New File
                        FileUpload1.SaveAs(Server.MapPath("~/ClientCorporate/" + UniqueId + "-" + FileUpload1.FileName));
                        model.FilePathNew = UniqueId + "-" + FileUpload1.FileName;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        Logic.SaveClientCorporate(model, currentClientId);
                        lblMessage.Text = "Saved successfully!";
                        lblTextareaLastDiscription.Text = "";
                        lblNoFile.Text = "";

                        Populate();
                    }
                }
                else
                {// Update
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf" && fileExtension != "" && fileExtension != ".xlsx")
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Only files with .docx, .xlsx and .pdf extension are allowed";
                    }
                    else
                    {
                        int UniqueId = Logic.ReturnUniqueId();
                        UniqueId++;
                        model.FilePathOld = lblFileNew.Text;
                        FileUpload1.SaveAs(Server.MapPath("~/ClientCorporate/" + UniqueId + "-" + FileUpload1.FileName));
                        model.FilePathNew = UniqueId + "-" + FileUpload1.FileName;

                        string completePath = Server.MapPath("~/ClientCorporate/" + lblFileOld.Text);
                        if (System.IO.File.Exists(completePath))
                        {
                            System.IO.File.Delete(completePath);
                        }
                        Logic.UpdateClientCorporate(model, currentClientId);
                        lblMessage.Text = "Updated successfully!";
                        lblTextareaLastDiscription.Text = "";
                        lblNoFile.Text = "";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        Populate();
                    }
                }
            }
            else
            {
                lblTextareaLastDiscription.Text = "Discription & File both are is required";
                lblNoFile.Text = "";
            }


        }

        protected void LinkButtonFile_Click_New(object sender, EventArgs e)
        {

            if (lblFileNew.Text != string.Empty && lblFileNew.Text != "No File Uploaded")
            {

                if (lblFileNew.Text.EndsWith(".xlsx"))
                {
                    Response.ContentType = "application/xlsx";
                }
                else if (lblFileNew.Text.EndsWith(".pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else
                {
                    Response.ContentType = "application/msworld";
                }

                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + lblFileNew.Text + "\"");
                Response.TransmitFile(Server.MapPath("~/ClientCorporate/" + lblFileNew.Text));
                Response.End();
            }
            else
            {
                lblNoFile.Text = "No file to Download";
                lblNoFile.ForeColor = System.Drawing.Color.Red;
            }
            //Response.ContentType = "Application/pdf";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=Test_PDF.pdf");
            //Response.TransmitFile(Server.MapPath("~/Files/Test_PDF.pdf"));
            //Response.End();
        }

        protected void LinkButtonFile_Click_Old(object sender, EventArgs e)
        {
            if (lblFileOld.Text != string.Empty && lblFileOld.Text != "No File Uploaded")
            {

                if (lblFileNew.Text.EndsWith(".xlsx"))
                {
                    Response.ContentType = "application/xlsx";
                }
                else if (lblFileNew.Text.EndsWith(".pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else
                {
                    Response.ContentType = "application/msworld";
                }
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + lblFileOld.Text + "\"");
                Response.TransmitFile(Server.MapPath("~/ClientCorporate/" + lblFileOld.Text));
                Response.End();
            }
            else
            {
                lblNoFile.Text = "No file to Download";
                lblNoFile.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Populate()
        {
            int currentClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
            string yearValue = Convert.ToString(DropDownListYear.SelectedItem);
            ClientsModel model = Logic.returnClientCorporateDataByClientIdAndYear(currentClientId, Convert.ToInt32(yearValue));
            if (model == null)
            {
                lblLastUpdatedBy.Text = "No User";
                lblFileNew.Text = "No File Uploaded";
                lblFileOld.Text = "No File Uploaded";
                textareaLastDiscription.InnerText = "";
            }
            else
            {

                lblLastUpdatedBy.Text = model.Name;
                lblFileNew.Text = model.FilePathNew;
                textareaLastDiscription.InnerText = model.LastChanges;
                ///////////////////////////
                lblFileOld.Text = model.FilePathOld == null ? "No File Uploaded" : model.FilePathOld;
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
        
        protected void DropDownListYears()
        {
            DataContext db = new DataContext();
            var YearDD = from y in db.TblYears
                              orderby y.Year
                              select new
                              {
                                  y.Year,
                                  y.Id,
                              };
            DropDownListYear.DataSource = YearDD;
            DropDownListYear.DataValueField = "Id";
            DropDownListYear.DataTextField = "Year";
            DropDownListYear.DataBind();
        }
    }

    
}