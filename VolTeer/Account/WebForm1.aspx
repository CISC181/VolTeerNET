
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="XTRAChangePassword.ascx.vb" Inherits="XTRAHome.XTRAChangePassword" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %> <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

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
        function checkPasswordMatch() {
            var text1 = $find("<%=rdPass1.ClientID%>").get_textBoxValue();
            var text2 = $find("<%=rdPass2.ClientID%>").get_textBoxValue();
            if (text2 == "") {
                $get("PasswordRepeatedIndicator").innerHTML = "";
                $get("PasswordRepeatedIndicator").className = "Base L0";
            }
            else if (text1 == text2) {
                $get("PasswordRepeatedIndicator").innerHTML = "Match";

                $get("PasswordRepeatedIndicator").className = "Base L5";
            }
            else {
                $get("PasswordRepeatedIndicator").innerHTML = "No match";
                $get("PasswordRepeatedIndicator").className = "Base L1";
            }
        }
    </script>

</telerik:RadCodeBlock>

<div class="request">
    <asp:Label ID="Label1" CssClass="request" runat="server">Change your password</asp:Label> </div>

<asp:Panel ID="pnlChangePassword" runat="server">

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblOldPW" Text="Old Password" runat="server"></asp:Label>
            </asp:TableCell>

            <asp:TableCell>
                <telerik:RadTextBox ID="rdOldPassword" runat="server" TextMode="Password" Width="160px" EnableSingleInputRendering="false"></telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="vreqCurrentPassword" runat="server" ErrorMessage="Must enter current password." Text="* Required" ForeColor="Red" Display="Dynamic" ControlToValidate="rdOldPassword" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNewPW1" Text="New Password" runat="server"></asp:Label>

            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadTextBox ID="rdPass1" runat="server" Width="160px"
                    TextMode="Password" onkeyup="checkPasswordMatch()" EnableSingleInputRendering="false">
                    <PasswordStrengthSettings
                        ShowIndicator="true"
                        PreferredPasswordLength="8"
                        MinimumUpperCaseCharacters="2"
                        MinimumLowerCaseCharacters="2"
                        MinimumSymbolCharacters="2"
                        MinimumNumericCharacters="2" 
                        CalculationWeightings="25;25;25;25"
                        RequiresUpperAndLowerCaseCharacters="true"
                        TextStrengthDescriptions="1/5 Requirement;2/5 Requirements;3/5 Requirements; 4/5 Requirements; All Requirements"
                        IndicatorElementBaseStyle="Base"
                        TextStrengthDescriptionStyles="L0;L1;L2;L3;L4;L5"
                        IndicatorElementID="CustomIndicator"></PasswordStrengthSettings>
                </telerik:RadTextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNewPW2" Text="Check Password" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadTextBox ID="rdPass2" runat="server" Width="160px"
                    TextMode="Password" onkeyup="checkPasswordMatch()" EnableSingleInputRendering="false">
                    <ClientEvents></ClientEvents>
                </telerik:RadTextBox>
                <br />
                <asp:RegularExpressionValidator ID="revPassword1" runat="server" ErrorMessage="Password does not meet complexity requirement." Text="Password does not meet complexity requirement." Display="Dynamic" ControlToValidate="rdPass2" />

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>
                <span id="CustomIndicator">&nbsp;</span> <span id="PasswordRepeatedIndicator" class="Base L0">&nbsp;</span>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnChangePW" runat="server" Text="OK" Width="62px"></asp:Button>&nbsp;&nbsp;&nbsp;
	<asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"></asp:Button>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <table>
                <tr>
                <td>
                    <div style="FONT-WEIGHT: bold">
                        A password must have the following:<br>
                        <br>
                        -&nbsp;At least 8 characters<br>
                        -&nbsp;2 uppercase characters<br>
                        -&nbsp;2 lowercase characters<br>
                        -&nbsp;2 digit<br>
                        -&nbsp;2 special character (!@$%^&amp;+=)<br>
                    </div>
                </td>
            </tr>
    </table>
    <p>
        <asp:textbox ID="lblMessage"  ForeColor="Red" Width="100%" BorderWidth="0" BorderStyle="NotSet" runat="server"></asp:textbox>
    </p>

    </asp:Panel>