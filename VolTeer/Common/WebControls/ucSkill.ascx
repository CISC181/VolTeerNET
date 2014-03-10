<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSkill.ascx.cs" Inherits="VolTeer.Common.WebControls.ucSkill" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadTreeList ID="rTLSkills" runat="server" OnNeedDataSource="rTLSkills_NeedDataSource"
    ParentDataKeyNames="MstrSkillID" DataKeyNames="SkillID" AllowPaging="true" PageSize="5"
    AutoGenerateColumns="false" AllowSorting="true">
    <Columns>

        <telerik:TreeListTemplateColumn>
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkHasSkill" AutoPostBack="true" Width="30px" />
            </ItemTemplate>
        </telerik:TreeListTemplateColumn>

        <telerik:TreeListBoundColumn DataField="SkillID" UniqueName="SkillID" HeaderText="Skill ID">
        </telerik:TreeListBoundColumn>

        <telerik:TreeListTemplateColumn DataField="SkillName" UniqueName="SkillName"
            HeaderText="Skill">
            <ItemTemplate>
                <%# Eval("SkillName")%>
            </ItemTemplate>
            <HeaderStyle Width="300px"></HeaderStyle>
        </telerik:TreeListTemplateColumn>


        <telerik:TreeListBoundColumn DataField="MstrSkillID" UniqueName="MstrSkillID" HeaderText="Master Category ID">
        </telerik:TreeListBoundColumn>

    </Columns>
</telerik:RadTreeList>
