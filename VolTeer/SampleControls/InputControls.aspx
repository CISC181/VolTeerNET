<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputControls.aspx.cs" Inherits="VolTeer.SampleControls.InputControls" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="holder" runat="server" />
        <div>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
            <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
            <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <telerik:RadInputManager ID="RadInputManager1" runat="server">
                    <telerik:TextBoxSetting BehaviorID="PassWordValidation"
                        Validation-ValidationGroup="Group2" Validation-IsRequired="true">
                        <TargetControls>
                            <telerik:TargetInput ControlID="PassWordLogin"></telerik:TargetInput>
                        </TargetControls>
                    </telerik:TextBoxSetting>
                    <telerik:RegExpTextBoxSetting BehaviorID="EmailLogin" ErrorMessage="Please, provide a valid e-mail address!"
                        Validation-ValidationGroup="Group2" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$">
                        <TargetControls>
                            <telerik:TargetInput ControlID="EmailLogin"></telerik:TargetInput>
                        </TargetControls>
                    </telerik:RegExpTextBoxSetting>
                </telerik:RadInputManager>
                <table border="0" cellpadding="5">
                    <colgroup>
                        <col width="100" />
                        <col width="200" />
                        <col width="100" />
                        <col width="200" />
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="TitleLabel1" runat="server" AssociatedControlID="RadMaskedTextBox1"
                                    Text="Registration form"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="TitleLabel2" runat="server" AssociatedControlID="RadMaskedTextBox1"
                                    Text="Login form"></asp:Label>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="FormContainer">
                            <td>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="RadTextBox1" Text="Name:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox1" runat="server" ValidationGroup="Group1">
                                </telerik:RadTextBox>
                                <br />
<%--                                <asp:RequiredFieldValidator ID="TextBoxRequiredFieldValidator" runat="server" Display="Dynamic"
                                    ValidationGroup="Group1" ControlToValidate="RadTextBox1" ErrorMessage="Please, supply a name!"
                                    CssClass="Validator"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" AssociatedControlID="EmailLogin" Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EmailLogin" runat="server" ValidationGroup="Group2">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr class="FormContainer">
                            <td>
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="RadNumericTextBox1" Text="Age:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Type="Number" NumberFormat-DecimalDigits="0"
                                    ValidationGroup="Group1">
                                </telerik:RadNumericTextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="NumercTextBoxRequiredFieldValidator" runat="server"
                                    ValidationGroup="Group1" CssClass="Validator" Display="Dynamic" ControlToValidate="RadNumericTextBox1"
                                    ErrorMessage="Please, enter age!"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="NumericTextBoxRangeValidator" runat="server" ControlToValidate="RadNumericTextBox1"
                                    ErrorMessage="Year number should be a non negative less than 50." Display="Dynamic"
                                    ValidationGroup="Group1" MaximumValue="50" MinimumValue="0" Type="Double" CssClass="Validator"></asp:RangeValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" AssociatedControlID="PassWordLogin" Text="Password:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="PassWordLogin" runat="server" TextMode="Password" ValidationGroup="Group2">
                                </asp:TextBox>
                                <br />
                            </td>
                        </tr>
                        <tr class="FormContainer">
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="RadMaskedTextBox1" Text="Phone:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadMaskedTextBox ID="RadMaskedTextBox1" runat="server" Mask="(###)-######"
                                    ValidationGroup="Group1">
                                </telerik:RadMaskedTextBox>
                                <br />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="MaskedTextBoxRequiredFieldValidator"
                                    ValidationGroup="Group1" CssClass="Validator" runat="server" ErrorMessage="Please, enter a phone number."
                                    ControlToValidate="RadMaskedTextBox1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="MaskedTextBoxRegularExpressionValidator"
                                    ValidationGroup="Group1" runat="server" ErrorMessage="Format is (###)-######"
                                    ControlToValidate="RadMaskedTextBox1" CssClass="Validator" ValidationExpression="\(\d{3}\)-\d{6}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr class="FormContainer">
                            <td valign="top">
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="Radtextbox2" Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="Radtextbox2" runat="server" ValidationGroup="Group1">
                                </telerik:RadTextBox>
                                <br />


                                <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
                                    ValidationGroup="Group1" CssClass="Validator" ErrorMessage="Please, enter valid e-mail address."
                                    ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                    ControlToValidate="Radtextbox2">
                                </asp:RegularExpressionValidator>


<%--                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
                                    ValidationGroup="Group1" CssClass="Validator" ControlToValidate="Radtextbox2"
                                    ErrorMessage="Please, enter an e-mail!"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr class="FormContainer">
                            <td>
                                <asp:Label ID="Label5" runat="server" AssociatedControlID="RadDateInput1" Text="Hire&nbsp;Date:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDateInput ID="RadDateInput1" runat="server" DateFormat="d" MinDate="01/01/1990"
                                    ValidationGroup="Group1" MaxDate="01/01/3000">
                                </telerik:RadDateInput>
                                <telerik:RadCalendar ID="RadCalendar1" runat="server"></telerik:RadCalendar>

                                <br />
                                <asp:RangeValidator ID="DateInputRangeValidator" runat="server" ControlToValidate="RadDateInput1"
                                    ValidationGroup="Group1" CssClass="Validator" ErrorMessage="Choose a date between 5th of January 2005 and 1st of September 2012"
                                    Display="Dynamic" MaximumValue="2012-09-01-00-00-00" MinimumValue="2005-01-05-00-00-00"></asp:RangeValidator>
                                <asp:RequiredFieldValidator ID="PickerRequiredFieldValidator" runat="server" Display="Dynamic"
                                    ValidationGroup="Group1" CssClass="Validator" ControlToValidate="RadDateInput1"
                                    ErrorMessage="Please, select a date!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button Text="Postback" ID="SubmitButton" runat="server" ValidationGroup="Group1"></asp:Button>
                            </td>
                            <td>
                                <asp:Button Text="Reset" ID="ResetButton" runat="server" OnClick="ResetButton_Click"></asp:Button>
                            </td>
                            <td colspan="2">
                                <asp:Button Text="Login" ID="LoginButton" runat="server" ValidationGroup="Group2"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <asp:CheckBox ID="CheckBox1" runat="server" CssClass="CheckBox" Text="Client Side Validation"
                    Checked="True" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                <br />
                <br />
            </telerik:RadAjaxPanel>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
        </div>
    </form>
</body>
</html>
