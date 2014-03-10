<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm1.aspx.cs" Inherits="VolTeer.SampleControls.TestForm1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="Radscriptmanager1" runat="server"></telerik:RadScriptManager>


            <telerik:RadDropDownList ID="rDDRoles2" OnSelectedIndexChanged="rDDRoles2_SelectedIndexChanged" AutoPostBack="true" runat="server" Skin="Web20"></telerik:RadDropDownList>

            <telerik:RadGrid ID="rdUserGrid" runat="server" CellSpacing="0" GridLines="None" AutoGenerateColumns="False">
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter column column" UniqueName="column">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UserID" FilterControlAltText="Filter column1 column" UniqueName="column1">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridDateTimeColumn DataField="LastLoginDate" FilterControlAltText="Filter column2 column" UniqueName="column2">
                            <ColumnValidationSettings>
                                <ModelErrorMessage Text="" />
                            </ColumnValidationSettings>
                        </telerik:GridDateTimeColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>
