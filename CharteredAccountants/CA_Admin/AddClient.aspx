<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="AdminBackAddEvent">

        <table style="width: 96%; margin-left: 5%;">

            <tr>
                <td colspan="2">
                    <h2 style="color:#1488e0; ">Create a Task</h2>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>Name <span style="color:red">*</span></p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxName" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Client Name" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Name is Required"></asp:RequiredFieldValidator>
                </td>

            </tr>

             <tr>
                <td style="width: 10%">
                    <p>Business Type <span style="color:red">*</span></p>
                </td>

                <td>
                    <asp:DropDownList ID="DropDownListBusinessType" class="AllTextBox" style="font-size:16px; width:156px;"  runat="server" OnSelectedIndexChanged="DropDownListBusinessType_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Select" Value="0" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Company" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Individuals" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="Sole Properietor" Value="3" ></asp:ListItem>
                        <asp:ListItem Text="Associates" Value="4" ></asp:ListItem>
                        <asp:ListItem Text="Trust" Value="5" ></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBusinessType" runat="server" ForeColor="Red" ControlToValidate="DropDownListBusinessType"
                    ErrorMessage="Select Business Type" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>

            
            <tr>
                <td style="width: 10%">
                    <p>Type of Company </p>
                </td>

                <td>
                    <asp:DropDownList ID="DropDownListTypeOfCompany" class="AllTextBox" style="font-size:16px; width:156px;"  runat="server">
                        <asp:ListItem Text="Select" Value="0" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Public" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Private" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="SMC" Value="3" ></asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>

            <tr>
                <td style="width: 10%">
                    <p>Limited by <span style="color:red">*</span></p>
                </td>

                <td>
                    <asp:DropDownList ID="DropDownListLimitedby" class="AllTextBox" style="font-size:16px; width:156px;"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListLimitedby_SelectedIndexChanged">
                        <asp:ListItem Text="Select" Value="0" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Share" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Guarantee" Value="2" ></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLimitedby" runat="server" ForeColor="Red" ControlToValidate="DropDownListLimitedby"
                    ErrorMessage="Select Limited by" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
            <tr>

                <td style="width: 10%" >
                    <p>Share Capital</p>
                    
                </td>

                
                <td >
                    <asp:TextBox ID="TextBoxShareValue1" OnTextChanged="TextBoxShareValue_TextChanged" MaxLength="15" CssClass="AllTextBox" Width="15%" placeholder="Number Of Shares" runat="server" AutoPostBack="true"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBoxNoOfShares" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                
                    
                    <span style="color:black; font-weight:bold">&#9747</span>
                    <asp:TextBox ID="TextBoxShareValue2" OnTextChanged="TextBoxShareValue_TextChanged" MaxLength="15" CssClass="AllTextBox" Width="15%" placeholder="Share Value" runat="server" AutoPostBack="true"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TextBoxNoOfShares" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    

                    <span style="color:black; font-weight:bold">=</span>
                    <asp:TextBox ID="TextBoxProductOfShareValues" Enabled="true"  MaxLength="30" CssClass="AllTextBox" Width="27.1%" placeholder="Product Of Share Capital" runat="server" ></asp:TextBox>
                <br /><asp:Label ID="lblOnlyNumbers" runat="server" ForeColor="Red"></asp:Label>
                </td>

            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>Business Objectives</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxBusinessObjectives" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Business Objectives" runat="server"></asp:TextBox>
                </td>

            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>Services</p>
                </td>

                <td >
                    <asp:CheckBoxList CssClass="AllTextBox Radio" ID="CheckBoxListServices" RepeatColumns="2" runat="server">
                        <asp:ListItem Text="Audit" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Corporate" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Accounting" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Legal" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Taxation" Value="5"></asp:ListItem>
                    </asp:CheckBoxList>
                   
                </td>

            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>PAN</p>
                </td>

                <td>
                    <asp:TextBox ID="TextBoxNTN" MaxLength="10" CssClass="AllTextBox" Width="65%" placeholder="PAN" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>PIN Code</p>
                </td>

                <td>
                    <asp:TextBox ID="TextBoxPINCode" MaxLength="6" CssClass="AllTextBox" Width="65%" placeholder="PIN Code" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>DoR Login</p>
                </td>

                <td>
                    <asp:TextBox ID="TextBoxFBRLogin" MaxLength="8" CssClass="AllTextBox" Width="65%" placeholder="DoR Login" runat="server"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>AADHAAR <span style="color:red">*</span></p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxCNIC" MaxLength="12" CssClass="AllTextBox" Width="65%" placeholder="AADHAAR Number" runat="server"></asp:TextBox>
                </td>
                <asp:RegularExpressionValidator id="RegularExpressionValidatorCNIC" 
                         ControlToValidate="TextBoxCNIC"
                         ValidationExpression="^\d+"
                         Display="Dynamic"
                         ErrorMessage="Only Numbers"
                         runat="server"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>DoR Password</p>
                </td>

                <td>
                    <asp:TextBox ID="TextBoxFBRPassword" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="DoR Password" runat="server"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Incorporation No. <span style="color:red">*</span></p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxIncorporationNo" MaxLength="21" CssClass="AllTextBox" Width="65%" placeholder="Incorporation Number" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator id="RegularExpressionValidatorIncorporationNo" 
                         ControlToValidate="TextBoxIncorporationNo"
                         ValidationExpression="^\w+"
                         Display="Dynamic"
                         ErrorMessage="Only Numbers"
                         runat="server"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
                
            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Registration No. <span style="color:red">*</span></p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxRegistration" MaxLength="7" CssClass="AllTextBox" Width="65%" placeholder="Registration Number" runat="server"></asp:TextBox>
                </td>
                <asp:RegularExpressionValidator id="RegularExpressionValidatorRegistration" 
                         ControlToValidate="TextBoxRegistration"
                         ValidationExpression="^\w+"
                         Display="Dynamic"
                         ErrorMessage="Only Numbers"
                         runat="server"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
            </tr>

            


            <tr>

                <td style="width: 10%" >
                    <p>Registered With</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxRegisteredWith" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Registered With" runat="server"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Address</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxAddress" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Full Address" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Email</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxEmail" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Valid Email" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Phone No.</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxPhoneNo" MaxLength="20" CssClass="AllTextBox" Width="65%" placeholder="Phone Number" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Mobile No.</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxMobile" MaxLength="10" CssClass="AllTextBox" Width="65%" placeholder="Mobile Number" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 10%" >
                    <p>Fax No.</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxFax" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Fax Number" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:ImageButton ID="ImageButton1" CssClass="AllButtons" ImageUrl="../images/Save.png" runat="server" OnClick="ImageButton1_Click" />
                    <br />
                </td>
            </tr>

        </table>

    </div>

</asp:Content>
