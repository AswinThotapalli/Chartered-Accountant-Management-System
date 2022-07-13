<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ExpiredEvents.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ExpiredEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="AdminBackAddEvent Scroller" >

        <h2 style="text-align:center">Expired Events</h2>

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

        <div style="width:186px; margin-top:9px; margin-left: 12px;">
        <div style="float:left">
            <span style="font-size:15px; line-height: 27px;">Number Of Posts</span>
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
                        <%--<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>--%>
                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <a style="color: black" href="ViewEvent.aspx?EventId=<%#Eval("Id")%>"><%#Eval("Title")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- <asp:BoundField DataField="Discription" HeaderText="Discription" SortExpression="Discription"/>--%>
                        <asp:BoundField DataField="ShortEventDate" HeaderText="Event Date" SortExpression="ShortEventDate" />
                        <asp:BoundField DataField="PosterName" HeaderText="Posted by" SortExpression="PosterName" />
                        <asp:ImageField DataImageUrlField="ImageLink" HeaderText="Image">
                            <%-- <ControlStyle Width="200px"></ControlStyle>--%>
                        </asp:ImageField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <a style="color: blue" href="AddEvent.aspx?ID=<%#Eval("Id")%>">Renew</a> | 
                                <asp:LinkButton ForeColor="Blue" ID="LinkButton1" OnClientClick="return confirm('Are you sure you want to DELETE this Event?')" CommandName="deleteEvent" CommandArgument='<%#Eval("Id")%>' runat="server"> Delete</asp:LinkButton>
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
