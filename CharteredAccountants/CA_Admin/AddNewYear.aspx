<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AddNewYear.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.AddNewYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    
    <div class="AdminBackAddEvent" style="margin-left: 33%; width: 28%;">
     <table style="width: 101%;">
         <tr>
                <td colspan="2">
             <div class="TextButton" style="width: 22px; font-size: 18px; margin-left: 31px; height: 22px; display: inline; margin-right: 35px;">
                <a style="color: white" href="ViewClient.aspx"><&nbsp;</a>
            </div>
                </td>
            </tr>
            <tr>
                <td style="width: 10%" >
                    <asp:Label ID="Label1" runat="server" ForeColor="#009933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 10%; " >
                    <p style="font-size:17px;">Enter New Year</p>
                </td>
                <td >
                    <asp:TextBox ID="TextBoxYear" MaxLength="4" CssClass="AllTextBox" Width="65%" placeholder="Year" runat="server"></asp:TextBox>
                    
                    <span style="font-size:17px;"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxYear" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator></span> 
                  <br />  <asp:CompareValidator ID="cv" runat="server" ControlToValidate="TextBoxYear" Type="Integer" Display="Dynamic" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Only Numbers Required!, " />
                 <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxYear" ValidationExpression="[2]{1}[0]{1}[0-9]{2}" ErrorMessage="Not a Valid Year! "  ForeColor="Red"/>
                </td>
            </tr>
         <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
         <tr>
                <td colspan="2" style="text-align:center">
                    <asp:ImageButton ID="ImageButton1" CssClass="AllButtons" ImageUrl="../images/Save.png" runat="server" OnClick="ImageButton1_Click" />
                    <br />
                </td>
            </tr> </table>
    </div>

</asp:Content>
