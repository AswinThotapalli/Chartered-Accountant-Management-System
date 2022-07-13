<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div style="width: 487px; margin-top:13px; margin-left: 2%;">
        
        
        <div class="TextBoxSearch" style="">
                <asp:TextBox ID="TextBoxQuickSearch" ForeColor="#1488e0" BorderWidth="2px"  Font-Italic="true" placeholder="Search Client" ToolTip="Search Client By Name, Email, CNIC, Incorporation No., RegistrationNo" CssClass="quickSearchTexBox AllTextBox" Height="14px" runat="server"></asp:TextBox>
             <asp:ImageButton ID="ImageButton2" style="width: 13%;height:13%; margin-top: -4px;" OnClick="ImageButton1_Click" ImageUrl="~/images/searchIcon.png" runat="server" />
        </div>

    </div>
     

    <div class="AdminBackAddEvent" style="margin-top: 0.5%;">
        <h2 style="text-align:center">Client Home</h2>
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

    <table style="margin-left: 20%;">

        <tr>
            <td>
                <p>Client Name</p>
            </td>

            <td>
                <asp:Label ID="lblClientName" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>Business Type</p>
            </td>

            <td>
                    <asp:DropDownList ID="DropDownListBusinessType" Enabled="false" class="AllTextBox" style="font-size:16px; width:156px;"  runat="server" AutoPostBack="true">
                        <asp:ListItem Text="Select" Value="0" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Company" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Individuals" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="Sole Properietor" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="Associates" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="Trust" Value="5" ></asp:ListItem>
                    </asp:DropDownList>
           </td>
        </tr>


        <tr>
            <td>
                <p>Type of Company</p>
            </td>

            <td>
                    <asp:DropDownList ID="DropDownListTypeOfCompany" Enabled="false" class="AllTextBox" style="font-size:16px; width:156px;"  runat="server">
                        <asp:ListItem Text="Null" Value="0" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Public" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Private" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="SMC" Value="3" ></asp:ListItem>
                    </asp:DropDownList>

                </td>
        </tr>

        <tr>
            <td>
                <p>CNIC</p>
            </td>

            <td>
                <asp:Label ID="lblCNIC" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>Incorporation No.</p>
            </td>

            <td>
                <asp:Label ID="lblIncorporation" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>Registration No.</p>
            </td>

            <td>
                <asp:Label ID="lblRegistration" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>NTN</p>
            </td>

            <td>
                <asp:Label ID="lblNTN" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>PIN Code</p>
            </td>

            <td>
                <asp:Label ID="lblPIN" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>FBR Login</p>
            </td>

            <td>
                <asp:Label ID="lblFBRLogin" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p>FBR Password</p>
            </td>

            <td>
                <asp:Label ID="lblFBRPassword" CssClass="FontSize" runat="server"></asp:Label>
            </td>
        </tr>

    </table>
            </div>
</asp:Content>
