<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewAttendance.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="AdminBackAddEvent" style="padding-top:13px ; width: 52%; margin-left: 22%;">


        <h2 style="text-align:center">Users Status</h2>
        
        <div style=" display:flex">

        <div style="text-align: left; width: 130px;margin-top: 8px;">
            <asp:LinkButton ID="HyperLinkClientHome" PostBackUrl="~/CA_Admin/ViewUsers.aspx" style="font-size: 17px;" runat="server"><span class="TextButton">Home</span></asp:LinkButton>
        </div>

        <div class="TextButton" style="text-align: center; width: 300px;margin-left: 22%;margin-bottom: 11px;">
            <asp:LinkButton ID="HyperLinkCurrentOnline" PostBackUrl="~/CA_Admin/OnlineUsers.aspx" style="font-size: 17px; color:white" runat="server">Online Users</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="HyperLinkViewAttendance" PostBackUrl="~/CA_Admin/ViewAttendance.aspx" style="font-size: 17px;color:white;" runat="server">View Attendance</asp:LinkButton>
        </div>
            
        </div>

          <asp:Label ID="lblNoData" runat="server"></asp:Label>
                <asp:GridView ID="GridViewAttendance" DataSourceID="ObjectDataSource1" AllowPaging="True" AutoGenerateColumns="False" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">
                    <Columns>

                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="EnteranceTime" HeaderText="Enterance Time" SortExpression="EnteranceTime" />
                        <asp:BoundField DataField="ExitTime" HeaderText="Exit Time" SortExpression="ExitTime" />
                        <asp:BoundField DataField="IsPresent" HeaderText="Present" SortExpression="Present" />
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
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <asp:ObjectDataSource ID="ObjectDataSource1"  SelectMethod="ViewAttendance"
                 runat="server" TypeName="CharteredAccountantsFYP.Helpers.Logic">
                </asp:ObjectDataSource>
        <%--<div style="background-color: #1488E0; color: #FFFFFF; font-size: 15px; margin-top: 6px; padding: 3px;">
                    <asp:Literal ID="Literal" runat="server"></asp:Literal>
                </div>--%>
                <br />

            </div>
</asp:Content>
