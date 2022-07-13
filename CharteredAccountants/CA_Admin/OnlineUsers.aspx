<%@ Page Title="Online Users" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="OnlineUsers.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.OnlineUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="AdminBackAddEvent" style="">


        <h2 style="text-align:center">Currently online Users</h2>
        
       <div style=" display:flex">

        <div style="text-align: left; width: 130px; margin-top: 7px;">
            <asp:LinkButton ID="HyperLinkClientHome" PostBackUrl="Reports.aspx" style="font-size: 17px; " runat="server"><span style="" class="TextButton">Home</span></asp:LinkButton>
        </div>

        <div class="TextButton" style="text-align: center; width: 600px;margin-left: 8%;">
            <asp:LinkButton ID="LinkButton2" PostBackUrl="DisableUsers.aspx" style="font-size: 17px;color:white;" runat="server">Disable<span style="color:#1488e0">-</span>Users</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="HyperLinkAudit" PostBackUrl="OnlineUsers.aspx" style="font-size: 17px; color:white" runat="server">Online<span style="color:#1488e0">-</span>Users</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="HyperLinkTax" PostBackUrl="ExpiredEvents.aspx" style="font-size: 17px;color:white;" runat="server">Expired<span style="color:#1488e0">-</span>Events</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="HyperLinkCorporate" PostBackUrl="ViewAdmins.aspx" style="font-size: 17px;color:white" runat="server">View<span style="color:#1488e0">-</span>Admins</asp:LinkButton>
        </div>

    </div>
        <br />
          <asp:Label ID="lblNoData" runat="server"></asp:Label>
                <asp:GridView ID="GridViewOnlineUsers" AutoGenerateColumns="False" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">
                    <Columns>

                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Profile Image"></asp:ImageField>
                        
                    </Columns>

                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#1488E0" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />

                </asp:GridView>

                <br />

            </div>

</asp:Content>
