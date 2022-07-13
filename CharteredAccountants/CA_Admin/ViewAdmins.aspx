<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewAdmins.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewAdmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    
    <div class="AdminBackAddEvent Scroller" >

        <h2 style="text-align:center">Admins</h2>

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


        <div style="width:194px; margin-top:9px; margin-left: 12px;">
        <div style="float:left">
            <span style="font-size:15px; line-height: 27px;">Number Of Admins</span>
        </div>
        <div style="float:right">
            <asp:DropDownList ID="DropDownListPageSize" AutoPostBack="true" class=""  style="padding:2px; font-size:15px; width:65px; border: 2px solid #e5e5e5; box-shadow: rgba(0,0,0,0.2) 0px 0px 9px; -moz-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px; -webkit-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px;" runat="server">
                <asp:ListItem Selected="True" Text="15" Value="15"></asp:ListItem>
                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                <asp:ListItem Text="50" Value="50"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
        <br />
        <br />
        <div class="Scroller" style="width:100%">
                <asp:Label ID="lblNoEvents" runat="server"></asp:Label>
                <asp:GridView ID="GridViewEvent" AutoGenerateColumns="False" runat="server" OnRowCommand="GridView1_RowCommand" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">

                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />
                        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Profile Image"></asp:ImageField>
                        
                        <asp:TemplateField HeaderText="Admin">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonYesAdmin" runat="server" CommandName="yes_Admin" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Are you sure you want to make this User Admin?')" Enabled='<%#Convert.ToBoolean(Eval("IsAdmin")) == false%>' >YES </asp:LinkButton>|
                                <asp:LinkButton ID="LinkButtonNoAdmin" runat="server" CommandName="no_Admin" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Are you sure you want to remove this User from Admin?')" Enabled='<%#Convert.ToBoolean(Eval("IsAdmin")) == true%>' > NO</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="enableUser" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Are you sure you want to Enable this User?')" Enabled='<%#Convert.ToBoolean(Eval("IsActive")) == false%>' >Enable </asp:LinkButton>|
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="disableUser" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Are you sure you want to Disable this User?')" Enabled='<%#Convert.ToBoolean(Eval("IsActive")) == true%>' > Disable </asp:LinkButton>|
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="deleteUser" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Are you sure you want to DELETE this User PERMANENTLY?')" > Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <div style="background-color: #1488E0; color: #FFFFFF; font-size: 15px; margin-top: 6px; padding: 3px;">
                    <asp:Literal ID="LiteralEvent" runat="server"></asp:Literal>
                </div>
                <br />
            </div>
        </div>


</asp:Content>
