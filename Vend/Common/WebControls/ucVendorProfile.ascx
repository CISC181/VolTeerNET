<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVendorProfile.ascx.cs" Inherits="Vend.Common.WebControls.ucVendorProfile" %>

        <telerik:RadEditor Height="300px" ID="RadEditor1" EnableResize="false"
            Style="margin-top: 10px" ToolbarMode="Default" EnableViewState="false" Width="900px" runat="server">
            <Modules>
                <telerik:EditorModule Visible="false" />
            </Modules>
            <Tools>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="AjaxSpellCheck" />
                    <telerik:EditorTool Name="FindAndReplace" ShortCut="CTRL+F" />
                    <telerik:EditorTool Name="Cut" />
                    <telerik:EditorTool Name="Copy" ShortCut="CTRL+C" />
                    <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                    <telerik:EditorTool Name="PasteStrip" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="Undo" ShortCut="CTRL+Z" />
                    <telerik:EditorTool Name="Redo" ShortCut="CTRL+Y" />
                </telerik:EditorToolGroup>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="ImageManager" ShortCut="CTRL+G" />
                    <telerik:EditorTool Name="AbsolutePosition" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="FlashManager" />
                    <telerik:EditorTool Name="MediaManager" />
                    <telerik:EditorTool Name="DocumentManager" />
                    <telerik:EditorTool Name="TemplateManager" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="LinkManager" ShortCut="CTRL+K" />
                    <telerik:EditorTool Name="Unlink" ShortCut="CTRL+SHIFT+K" />
                </telerik:EditorToolGroup>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="Superscript" />
                    <telerik:EditorTool Name="Subscript" />
                    <telerik:EditorTool Name="InsertParagraph" />
                    <telerik:EditorTool Name="InsertGroupbox" />
                    <telerik:EditorTool Name="InsertHorizontalRule" />
                    <telerik:EditorTool Name="InsertDate" />
                    <telerik:EditorTool Name="InsertTime" />
                </telerik:EditorToolGroup>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="FormatBlock" />
                    <telerik:EditorTool Name="FontName" ShortCut="CTRL+SHIFT+F" />
                    <telerik:EditorTool Name="RealFontSize" ShortCut="CTRL+SHIFT+P" />
                </telerik:EditorToolGroup>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="SelectAll" ShortCut="CTRL+A" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="Bold" ShortCut="CTRL+B" />
                    <telerik:EditorTool Name="Italic" ShortCut="CTRL+I" />
                    <telerik:EditorTool Name="Underline" ShortCut="CTRL+U" />
                    <telerik:EditorTool Name="StrikeThrough" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="JustifyLeft" />
                    <telerik:EditorTool Name="JustifyCenter" />
                    <telerik:EditorTool Name="JustifyRight" />
                    <telerik:EditorTool Name="JustifyFull" />
                    <telerik:EditorTool Name="JustifyNone" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="Indent" />
                    <telerik:EditorTool Name="Outdent" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="InsertOrderedList" />
                    <telerik:EditorTool Name="InsertUnorderedList" />
                    <telerik:EditorTool Name="ToggleTableBorder" />
                </telerik:EditorToolGroup>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="ForeColor" />
                    <telerik:EditorTool Name="BackColor" />
                    <telerik:EditorTool Name="ApplyClass" />
                    <telerik:EditorTool Name="FormatStripper" />
                </telerik:EditorToolGroup>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="InsertSymbol" />
                    <telerik:EditorTool Name="InsertTable" />
                    <telerik:EditorTool Name="InsertFormElement" />
                    <telerik:EditorTool Name="InsertSnippet" />
                    <telerik:EditorTool Name="ImageMapDialog" />
                    <telerik:EditorTool Name="InsertCustomLink" ShortCut="CTRL+ALT+K" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="ConvertToLower" />
                    <telerik:EditorTool Name="ConvertToUpper" />
                    <telerik:EditorSeparator />
                    <telerik:EditorTool Name="AboutDialog" />
                    <telerik:EditorTool Name="Zoom" />
                    <telerik:EditorTool Name="ModuleManager" />
                    <telerik:EditorTool Name="ToggleScreenMode" ShortCut="F11" />
                </telerik:EditorToolGroup>
            </Tools>
        </telerik:RadEditor>