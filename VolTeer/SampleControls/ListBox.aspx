<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBox.aspx.cs" Inherits="VolTeer.SampleControls.ListBox" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
            <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
            <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1">



                <telerik:RadListBox runat="server"  SelectionMode="Multiple" AllowReorder="true" ID="RadListBoxSource" Height="200px" Width="200px"
                    AllowTransfer="true" TransferToID="RadListBoxDestination">
                    <Items>
                        <telerik:RadListBoxItem Text="Argentina"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Australia"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Brazil"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Canada"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Chile"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="China"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Egypt"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="England"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="France"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Germany"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="India"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Indonesia"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Kenya"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Mexico"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="New Zealand"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="South Africa"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="USA"></telerik:RadListBoxItem>
                    </Items>
                </telerik:RadListBox>
                <telerik:RadListBox runat="server" AllowDelete="true" AllowReorder="true" ID="RadListBoxDestination" Height="200px" Width="200px">
                </telerik:RadListBox>
            </telerik:RadAjaxPanel>
        </div>
    </form>
</body>
</html>
