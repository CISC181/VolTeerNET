<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleSimpleControls.aspx.cs" Inherits="VolTeer.SampleControls.SampleSimpleControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />

            <telerik:RadTextBox ID="RadTextBox1" runat="server"></telerik:RadTextBox>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ControlToValidate="TextBox1"
                ErrorMessage="Name"
                Text="*"
                runat="server" />
            <asp:Panel runat="server">
                <telerik:RadTextBox ID="RadTextBox2" runat="server"></telerik:RadTextBox>
                <br />

            </asp:Panel>

            <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" />

        </div>
        <asp:Button ID="Button1" runat="server"  Text="Button" />
    </form>
</body>
</html>
