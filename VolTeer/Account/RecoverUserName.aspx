<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="RecoverUserName.aspx.cs" Inherits="VolTeer.Account.RecoverUserName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlRecover" runat="server" Visible="true">
        <asp:Table runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeading" runat="server" Text="Recover User Name">
                    </asp:Label>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmailLit" runat="server" Text="Please enter your email address:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="rTXTEmailAddress" runat="server" EmptyMessage="Email Address">
                    </telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>               
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadButton ID="rBTNSubmit" Skin="Web20" Text="Submit" runat="server" OnClick="rBTNSubmit_Click"></telerik:RadButton>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>               
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CustomValidator ID="valEmail" OnServerValidate="valEmail_ServerValidate" runat="server" ErrorMessage="Can't Find Email Address"></asp:CustomValidator>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="pnlContinue" runat="server" Visible="false">
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label1" runat="server" Text="Username sent to registered Email address">
                    </asp:Label>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadButton ID="rBTNLogin" runat="server" Text="Login" PostBackUrl="Login.aspx"  Skin="Web20" >

                    </telerik:RadButton>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

</asp:Content>
