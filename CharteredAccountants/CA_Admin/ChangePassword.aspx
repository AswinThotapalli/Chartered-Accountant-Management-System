<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">



    <div class="changePassBack" style="">

        <div class="changePassImage" style="">
            <div class="TextButton" style="width: 22px; font-size: 18px; margin-left: 31px; height: 22px; display: inline; margin-right: 35px;">
                <a style="color: white" href="ViewUserProfile.aspx"><&nbsp;</a>
            </div>
            <asp:Image ID="Image1" CssClass="changePassInnerImage" Style="" ImageUrl="~/images/changePass.jpg" runat="server" />
        </div>
        <table class="changepassTbl" style="">

            <tr>

                <td colspan="2" style="font-size: 19px; font-weight: bold; color: #1488e0; text-align: center;">Change Password</td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:TextBox CssClass="AllTextBox" Style="height: 28px; padding: 4px; width: 88%;" MaxLength="15" ID="TextBoxCurrentPass" placeholder="Current Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxCurrentPass" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>

                <td colspan="2">
                    <asp:TextBox CssClass="AllTextBox" Style="height: 28px; padding: 4px; width: 88%;" MaxLength="15" ID="TextBoxNewPassword" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNewPassword" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>

                <td colspan="2">
                    <asp:TextBox CssClass="AllTextBox" Style="height: 28px; padding: 4px; width: 88%;" MaxLength="15" ID="TextBoxReTypePassword" placeholder="ReType Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxReTypePassword" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>


                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator1" ControlToCompare="TextBoxNewPassword" Type="String" Operator="Equal" ControlToValidate="TextBoxReTypePassword" runat="server" ForeColor="Red" ErrorMessage="Passwords Must Match"></asp:CompareValidator>
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <asp:ImageButton ID="ChangePass" CssClass="ChangePassButton" ImageUrl="~/images/SignInSave.png" runat="server" OnClick="ChangePass_Click" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
