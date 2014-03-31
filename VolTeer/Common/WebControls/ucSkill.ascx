<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSkill.ascx.cs" Inherits="VolTeer.Common.WebControls.ucSkill" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadTreeList ID="rTLSkills" runat="server" OnNeedDataSource="rTLSkills_NeedDataSource"
    ParentDataKeyNames="MstrSkillID" DataKeyNames="SkillID" Width="566px" 
    AutoGenerateColumns="False" AllowSorting="True">
    <Columns>

        <telerik:TreeListTemplateColumn HeaderText="Has Skill">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkHasSkill" AutoPostBack="true" Width="200px" />
            </ItemTemplate>
        </telerik:TreeListTemplateColumn>

        <telerik:TreeListBoundColumn DataField="SkillID" UniqueName="SkillID" HeaderText="Skill ID" Visible="false" >
        </telerik:TreeListBoundColumn>

        <telerik:TreeListTemplateColumn DataField="SkillName" UniqueName="SkillName"
            HeaderText="Skill">
            <ItemTemplate>
                <%# Eval("SkillName")%>
            </ItemTemplate>
            <HeaderStyle Width="400px"></HeaderStyle>
        </telerik:TreeListTemplateColumn>


        <telerik:TreeListBoundColumn DataField="MstrSkillID" UniqueName="MstrSkillID" HeaderText="Master Category ID" Visible="false">
        </telerik:TreeListBoundColumn>

    </Columns>
</telerik:RadTreeList>
