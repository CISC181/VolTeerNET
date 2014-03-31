<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEditSkill.ascx.cs" Inherits="VolTeer.Common.WebControls.ucEditSkill" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

    <telerik:RadTreeList ID="rTLSkills"
        runat="server"
        OnItemCommand="rTLSkills_ItemCommand" OnUpdateCommand="rTLSkills_UpdateCommand"
        OnNeedDataSource="rTLSkills_NeedDataSource"
        ParentDataKeyNames="MstrSkillID"
        DataKeyNames="SkillID"
        Width="566px"
        AutoGenerateColumns="False" EditMode="InPlace"
        AllowSorting="True">
        <EditFormSettings>
        </EditFormSettings>
        <Columns>

            <telerik:TreeListEditCommandColumn UniqueName="InsertCommandColumn" ButtonType="ImageButton" ShowEditButton="false" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center"></telerik:TreeListEditCommandColumn>
            <telerik:TreeListButtonColumn CommandName="Edit" Text="Edit" UniqueName="EditCommandColumn" ButtonType="ImageButton" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center"></telerik:TreeListButtonColumn>
            <telerik:TreeListButtonColumn UniqueName="DeleteCommandColumn" Text="Delete" CommandName="Delete" ButtonType="ImageButton" HeaderStyle-Width="30px"></telerik:TreeListButtonColumn>


            <telerik:TreeListDragDropColumn Visible="true" HeaderStyle-Width="20px" UniqueName="TreeListDragDropColumn"></telerik:TreeListDragDropColumn>
            <telerik:TreeListBoundColumn DataField="SkillID" UniqueName="SkillID" HeaderText="Skill ID" ReadOnly="true" Visible="false">
            </telerik:TreeListBoundColumn>
            <telerik:TreeListBoundColumn DataField="MstrSkillID" UniqueName="MstrSkillID" ReadOnly="true" HeaderText="Master Category ID" Visible="false">
            </telerik:TreeListBoundColumn>

            <telerik:TreeListBoundColumn DataField="SkillName" UniqueName="SkillName" ReadOnly="false" HeaderText="Skill Name" Visible="true">
            </telerik:TreeListBoundColumn>


            <%--            <telerik:TreeListTemplateColumn UniqueName="SkillNamex" HeaderText="Skill Name">
                <ItemTemplate>
                    <%# Eval("SkillName")%>
                </ItemTemplate>
                <HeaderStyle Width="400px"></HeaderStyle>


                <EditItemTemplate>
                    <telerik:RadTextBox ID="rTBSkillName" Text='<%# Eval("SkillName")%>' runat="server"></telerik:RadTextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <telerik:RadTextBox ID="rTBSkillNameIns"  runat="server"></telerik:RadTextBox>
                </InsertItemTemplate>
            </telerik:TreeListTemplateColumn>--%>
        </Columns>
        <ClientSettings AllowItemsDragDrop="true">
            <Selecting AllowItemSelection="true" />
            <ClientEvents OnItemDropping="itemDropping" OnItemDragging="itemDragging" OnTreeListCreated="function(sender) { rTLSkills = sender; }" />
        </ClientSettings>
    </telerik:RadTreeList>
</telerik:RadAjaxPanel>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
