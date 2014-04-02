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
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <asp:Panel runat="server">
                <telerik:RadTextBox ID="RadTextBox2" runat="server"></telerik:RadTextBox>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>

                <br />

            </asp:Panel>

            <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" />

        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
