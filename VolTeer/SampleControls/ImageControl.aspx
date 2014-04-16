<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="ImageControl.aspx.cs" Inherits="VolTeer.SampleControls.ImageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />

    <style type="text/css">
        ._Telerik_IE9 .RadDock.rieDialogs {
            z-index: 20001;
        }
                ._Telerik_IE9 .rcbSlide {
            z-index: 20002 !important;
        }
                        #dwndWrapper {
            height: 85px;
            background-image: url("../../images/upload_100.png");
            background-position: left;
            background-repeat: no-repeat;
            padding: 15px 0 0 100px;
        }
                                div.RadUpload .ruBrowse {
            background-position: 0 -46px;
            width: 115px !important;
        }
                                        div.RadUpload_Default .ruFileWrap .ruButtonHover {
            background-position: 100% -46px !important;
        }
    </style>

    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function OnClientFilesUploaded(sender, args) {
                $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadImageEditor1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <div id="dwndWrapper">
        <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server"
            OnClientFilesUploaded="OnClientFilesUploaded" OnFileUploaded="AsyncUpload1_FileUploaded"
            MaxFileSize="2097152" AllowedFileExtensions="jpg,png,gif,bmp"
            AutoAddFileInputs="false" Localization-Select="Upload Image" />
        <asp:Label ID="Label1" Text="*Size limit: 2MB" runat="server" Style="font-size: 10px;"></asp:Label>
    </div>

    <telerik:RadImageEditor ID="RadImageEditor1" runat="server" Width="680" Height="450"
        ImageUrl="~/ImageEditor/images/waterpool.jpg" OnImageLoading="RadImageEditor1_ImageLoading">
    </telerik:RadImageEditor>

</asp:Content>
