<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ClientCorporate.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ClientCorporate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="AdminBackAddEvent">
        <h2 style="text-align:center">Corporate Module</h2>
      
        <div style=" margin-bottom: 11px;display:flex">

        <div style="text-align: left; width: 130px; margin-top: 7px">
            <asp:LinkButton ID="HyperLinkClientHome" OnClick="HyperLinkClientHome_Click" style="font-size: 17px;" runat="server"><span class="TextButton">Home</span></asp:LinkButton>
        </div>

        <div class="TextButton" style="text-align: center; width: 223px;margin-left: 0%;">
            <asp:LinkButton ID="HyperLinkAudit" OnClick="HyperLinkAudit_Click" style="font-size: 17px; color:white" runat="server">Audit</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="HyperLinkTax" OnClick="HyperLinkTax_Click" style="font-size: 17px;color:white;" runat="server">Tax</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="HyperLinkCorporate" OnClick="HyperLinkCorporate_Click" style="font-size: 17px;color:white" runat="server">Corporate</asp:LinkButton>
        </div>

    </div>

        <table style="width: 101%">
            <tr>
                <td style="width: 10%" >
                    <p>Select Year</p>
                </td>

                <td >
                   <asp:DropDownList ID="DropDownListYear" class="AllTextBox" style="font-size:16px; width:78px;"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListYear_SelectedIndexChanged"></asp:DropDownList> <a href="AddNewYear.aspx" ><span class="TextButton" style="">Add new Year</span></a>
                </td>

            </tr>

            <tr>
                <td style="width: 10%">
                    <p>Last Updated By</p>
                </td>

                <td>
                    <asp:Label ID="lblLastUpdatedBy" CssClass="FontSize" runat="server"></asp:Label> 
                </td>
            </tr>

            <tr>
                <td style="width: 10%">
                    <p>Last Updated File</p>
                </td>

                <td>
                    <asp:LinkButton ID="LinkButtonFileOld" OnClick="LinkButtonFile_Click_Old" ForeColor="Green" runat="server"><asp:Label ID="lblFileOld" CssClass="FontSize" runat="server"></asp:Label></asp:LinkButton>
                    <span style="color:green; font-size:11px">&nbsp; &nbsp; (For Backup)</span>
                </td>
            </tr>

            <tr>
                <td style="width: 10%">
                    <p>New Updated File</p>
                </td>

                <td>
                    <asp:LinkButton ID="LinkButtonFile" OnClick="LinkButtonFile_Click_New" ForeColor="Green" runat="server"><asp:Label ID="lblFileNew" CssClass="FontSize" runat="server"></asp:Label></asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:FileUpload  ID="FileUpload1" CssClass="AllTextBox" runat="server" Width="30%" />
                    <br />
                    
                 </td>
            </tr>

            <tr>
                <td style="width: 10%">
                    <p>Last Changes</p>
                </td>

                <td>
                    
                    <textarea id="textareaLastDiscription" rows="4" runat="server" class="AllTextBox" cols="50" placeholder="Changes Discription Here" maxlength="500" style="width: 65%"></textarea>
                    <br />
                    <asp:Label ForeColor="Red" ID="lblTextareaLastDiscription" runat="server"></asp:Label>
                </td>
            </tr>


            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:Label ID="lblNoFile" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:ImageButton ID="ImageButton1" CssClass="AllButtons" ImageUrl="../images/Save.png" runat="server" OnClick="ImageButton1_Click" />
                    <br />
                </td>
            </tr>
            

        </table>


        </div>

</asp:Content>
