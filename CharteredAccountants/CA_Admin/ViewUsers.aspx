<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="AdminBackAddEvent" style="padding-top:13px ">


        <h2 style="text-align:center">Users Status</h2>
        
        <%--<div style=" display:flex">

        <div style="text-align: left; width: 130px;margin-top: 8px;">
            <asp:LinkButton ID="HyperLinkClientHome" PostBackUrl="~/CA_Admin/ViewUsers.aspx" style="font-size: 17px;" runat="server"><span class="TextButton">Home</span></asp:LinkButton>
        </div>

       <div class="TextButton" style="margin-bottom: 10px;
    margin-left: -4%;
    text-align: center;
    width: 137px;">
            <asp:LinkButton ID="HyperLinkCurrentOnline" PostBackUrl="~/CA_Admin/OnlineUsers.aspx" style="font-size: 17px; color:white" runat="server">Online Users</asp:LinkButton>
          
        </div>
            
        </div>--%>

   <asp:Label ID="lblNoData" runat="server"></asp:Label>
                <asp:GridView ID="GridViewUser" AutoGenerateColumns="False" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5" OnRowCommand="GridViewUser_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
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
                    <asp:Literal ID="Literal" runat="server"></asp:Literal>
                </div>
                <br />
            </div>

</asp:Content>
