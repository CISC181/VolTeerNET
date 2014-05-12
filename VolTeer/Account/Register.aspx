<%@ Page Title="Register New Account" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VolTeer.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">
            function CalculatingStrength(sender, args) {
                if (args.get_passwordText() == "Enter Password") {
                    //Manually set strength Score depending on the input text.
                    args.set_indicatorText("Custom text");
                    args.set_strengthScore(0);
                }
                else {
                    var calculatedScore = args.get_strengthScore();
                    //Changing the indicator text depending on the calculated score.
                    args.set_indicatorText("Score: (" + calculatedScore + "/100)");
                }
            }
        </script>

    </telerik:RadCodeBlock>

    <hgroup class="title">
        <h2><%: Title %>.</h2>
        <h3>Use the form below to create a new account.</h3>
    </hgroup>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" Width="50%" CreateUserButtonText="Register" 
        Height="75px" ViewStateMode="Disabled" OnCreateUserError="RegisterUser_CreateUserError" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>

            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <asp:Table HorizontalAlign="left" runat="server" ID="tbRegister" Font-Names="Verdana" Font-Size="X-Small">
                        <asp:TableHeaderRow>
                            <asp:TableCell ColumnSpan="2">
                                <asp:Label ID="lblHeader" runat="server" Text="Sign Up for Your New Account"></asp:Label>
                            </asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblName" runat="server" Text="Name">

                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTXTFirstName" runat="server" EmptyMessage="First Name" Width="100px">
                                </telerik:RadTextBox>
                                &nbsp;
                                <telerik:RadTextBox ID="rTXTMiddleName" runat="server" EmptyMessage="Middle Name" Width="75px">
                                </telerik:RadTextBox>
                                &nbsp;
                                <telerik:RadTextBox ID="rTXTLastName" runat="server" EmptyMessage="First Name" Width="100px">
                                </telerik:RadTextBox>
                                &nbsp;
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="User Name:">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="UserName" EmptyMessage="User Name" EnableSingleInputRendering="false" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="Password" runat="server" EnableSingleInputRendering="false" TextMode="Password"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" Text="Confirm Password:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="ConfirmPassword" runat="server" Width="160px"
                                    TextMode="Password" EnableSingleInputRendering="false">
                                    <PasswordStrengthSettings
                                        ShowIndicator="true"
                                        PreferredPasswordLength="8"
                                        MinimumUpperCaseCharacters="1"
                                        MinimumLowerCaseCharacters="1"
                                        MinimumSymbolCharacters="0"
                                        MinimumNumericCharacters="1"
                                        CalculationWeightings="25;25;25;25"
                                        RequiresUpperAndLowerCaseCharacters="true"
                                        TextStrengthDescriptions="1/5 Requirement;2/5 Requirements;3/5 Requirements; 4/5 Requirements; All Requirements"
                                        IndicatorElementBaseStyle="Base"
                                        TextStrengthDescriptionStyles="L0;L1;L2;L3;L4;L5"
                                        IndicatorElementID="CustomIndicator"></PasswordStrengthSettings>
                                </telerik:RadTextBox>
                                <span id="CustomIndicator">&nbsp;</span> <span id="PasswordRepeatedIndicator" class="Base L0">&nbsp;</span>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                    ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ValidationGroup="CreateUserWizard1" ControlToValidate="ConfirmPassword"
                                    CssClass="field-validation-error" Display="Static" ErrorMessage="The password and confirmation password do not match." />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" Text="E-mail:">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="Email" runat="server" EnableSingleInputRendering="false" EmptyMessage="Email"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" Text="Security Question:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="Question" runat="server" EnableSingleInputRendering="false" EmptyMessage="Security Question"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                    ErrorMessage="Security question is required." ToolTip="Security question is required."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="Answer" Text="Security Answer:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="Answer" runat="server" EnableSingleInputRendering="false" EmptyMessage="Security Answer"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                    ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2">
                                <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="CreateUserWizard1" HeaderText="Validation Errors"
                                    DisplayMode="BulletList" ShowSummary="true" EnableClientScript="true" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                <ContentTemplate>
                    <table border="0" style="font-size: 100%; font-family: Verdana" id="TABLE1">
                        <tr>
                            <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d; height: 18px;">Complete</td>
                        </tr>
                        <tr>
                            <td>Your account has been successfully created.<br />
                                <br />
                                <asp:Label ID="SubscribeLabel" runat="server" Text="You have elected to receive our monthly newsletter."></asp:Label><br />
                                <br />
                                <asp:Label ID="ShareInfoLabel" runat="server" Text="You have elected to share your information with partner sites."></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">&nbsp;<asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                Font-Names="Verdana" ForeColor="#284775" Text="Continue" ValidationGroup="CreateUserWizard1" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>

    <asp:Label ID="lblError" runat="server" Visible="false" >

    </asp:Label>
</asp:Content>
