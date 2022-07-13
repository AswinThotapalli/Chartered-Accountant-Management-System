<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="SearchGrids.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.SearchGrids" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <div style="width: 496px; margin-top:9px; margin-left: 12px;">
                <div style="display: flex;
    float: left;
    margin-left: 22px;">
                <asp:TextBox ID="TextBoxQuickSearch" ForeColor="#1488e0" BorderWidth="2px" Width="76%" Font-Italic="true" placeholder="Search Client" ToolTip="Search Client By Name, Email, CNIC, Incorporation No., RegistrationNo" CssClass="quickSearchTexBox AllTextBox" Height="14px" runat="server"></asp:TextBox> <asp:ImageButton ID="ImageButton2" style="width: 13%;height:13%;margin-top: -4px;" OnClick="ImageButton1_Click" ImageUrl="~/images/searchIcon.png" runat="server" />
        </div>
        </div>

    <div class="AdminBackAddEvent Scroller" style="padding:0px;padding-top:20px ;width: 98%; margin-top:4px; margin-left:1%">
    
        
        
                    <asp:GridView ID="GridViewSearch" AutoGenerateColumns="False" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False">

            <Columns>
                <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:TemplateField HeaderText="Name" ItemStyle-BorderWidth="1px">
                    <ItemTemplate>

                        <a style="color: black" href="ViewClient.aspx?ClientId=<%#Eval("Id")%>"><%#Eval("Name")%></a>

                    </ItemTemplate>

                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="BusinessTypeInline" ItemStyle-BorderWidth="1px" HeaderText="Business_Type" SortExpression="BusinessType">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TypeOfCompanyInline" ItemStyle-BorderWidth="1px" HeaderText="Company_Type" SortExpression="TypeOfCompanyInline">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="LimitedByInline" ItemStyle-BorderWidth="1px" HeaderText="Limited_By" SortExpression="LimitedByInline">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center" DataField="ProductOfShareValues" HeaderText="Share_Captial" SortExpression="ProductOfShareValues">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center" BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="BusinessObjectives" ItemStyle-BorderWidth="1px" HeaderText="Business_Objectives" SortExpression="BusinessObjectives">

                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Services_This_Client_Provides" ItemStyle-BorderWidth="1px">
                    <ItemTemplate>
                        Audit: <%#Convert.ToBoolean(Eval("ServiceAudit").ToString()) ?  "<span style='color:green'>" + "Yes" + "</span>" : "<span style='color:red'>" + "No" + "</span>"%> |
                       Corporate: <%#Convert.ToBoolean(Eval("ServiceCorporate").ToString()) ? "<span style='color:green'>" + "Yes" + "</span>" : "<span style='color:red'>" + "No" + "</span>"%> |
                       Accounting: <%#Convert.ToBoolean(Eval("ServiceAccounting").ToString()) ? "<span style='color:green'>" + "Yes" + "</span>" : "<span style='color:red'>" + "No" + "</span>"%> |
                       Legal: <%#Convert.ToBoolean(Eval("ServiceLegal").ToString()) ? "<span style='color:green'>" + "Yes" + "</span>" : "<span style='color:red'>" + "No" + "</span>"%> |
                       Taxation: <%#Convert.ToBoolean(Eval("ServiceTaxation").ToString()) ? "<span style='color:green'>" + "Yes" + "</span>" : "<span style='color:red'>" + "No" + "</span>"%>
                    </ItemTemplate>

                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="CNIC" HeaderText="CNIC" ItemStyle-BorderWidth="1px" SortExpression="CNIC">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="IncorporationNo" ItemStyle-BorderWidth="1px" HeaderText="Incorporation_No" SortExpression="IncorporationNo">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="RegistrationNo" ItemStyle-BorderWidth="1px" HeaderText="Registration_No" SortExpression="RegistrationNo">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="RegisteredWith" ItemStyle-BorderWidth="1px" HeaderText="Registered_With" SortExpression="RegisteredWith">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Address" ItemStyle-BorderWidth="1px" HeaderText="Address" SortExpression="Address">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Email" ItemStyle-BorderWidth="1px" HeaderText="Email" SortExpression="Email">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="PhoneNo" ItemStyle-BorderWidth="1px" HeaderText="Phone No" SortExpression="PhoneNo">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="MobileNo" ItemStyle-BorderWidth="1px" HeaderText="Mobile No" SortExpression="MobileNo">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="FaxNo" ItemStyle-BorderWidth="1px" HeaderText="Fax No" SortExpression="FaxNo">
                    <ItemStyle BorderWidth="1px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ItemStyle-BorderWidth="1px" HeaderStyle-Width="20%" HeaderText="____________" >
                    <ItemTemplate >
                        <a style="color: blue" href="AddClient.aspx?ClientId=<%#Eval("Id")%>">Edit</a> | 
                                <asp:LinkButton ForeColor="Blue" ID="LinkButton1"
                                    OnClientClick="confirm('Are you sure you want to DELETE this Task?')"
                                    CommandName="deleteTask"
                                    CommandArgument='<%#Eval("Id")%>' runat="server"> Delete</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="200px" Height="" ForeColor="#1488E0"></HeaderStyle>
                    <ItemStyle Width="200px" BorderWidth="1px"></ItemStyle>

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
        <div style="text-align:center; margin-bottom:10px">
        <asp:Label ID="lblNoData" runat="server"></asp:Label>
            </div>
    </div>
</asp:Content>
