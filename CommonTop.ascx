<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommonTop.ascx.cs" Inherits="CommonTop" %>
<script type="text/javascript" language="javascript">
    function AddFavorite(sURL, sTitle) {
        try {
            window.external.addFavorite(sURL, sTitle);
        }
        catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e) {
                alert("加入收藏失败，请使用Ctrl+D进行添加");
            }
        }
    }
    function SetHome(obj, vrl) {
        try {
            obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
        }
        catch (e) {
            if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                }
                catch (e) {
                    alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将[signed.applets.codebase_principal_support]设置为'true'");
                }
                var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
                prefs.setCharPref('browser.startup.homepage', vrl);
            }
        }
    }
</script>
<style type="text/css">
    .menuclass
    {
        color: #5c6d71;
    }
    
    .menuover
    {
        color: #ffffff;
        background-color: #007ac7;
    }
    .menuover a
    {
        color: #ffffff;
    }
    .menuover a:hover
    {
        color: #ffffff;
    }
    .menuclick
    {
        color: #ffffff;
        background-color: #007ac7;
        font-weight: bold;
    }
    .menuclick a
    {
        color: #ffffff;
        background-color: #007ac7;
    }
</style>
<div id="bannel1" style="border: 0 0 0; text-align: center;" runat="server">
    <table width="100%" border="0" style="text-align: center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 1; background-color: #FFFFFF">
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 24; background-color: #747a7d">
                <table width="98%" border="0" cellpadding="0" cellspacing="0" id="menu-list">
                    <tr>
                        <td align="left">
                            <asp:Label ID="dateInfo" runat="server" Text="" Style="color: #fff000; font-weight: bold;"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblLoginInfo" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:HyperLink ID="HyperLink2" runat="server" Target="_top" NavigateUrl="Default.aspx">返回首页</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="Manual.zip">帮助手册</asp:HyperLink>
                            <asp:HyperLink ID="hypMyInfo" runat="server" Target="fraContent" NavigateUrl="Modules/Common/UserAdmin/UserInfo.aspx">我的信息</asp:HyperLink>
                            <a href="#" onclick="AddFavorite(window.location,document.title)">加入收藏</a> 
                            <a href="#" onclick="SetHome(this,window.location)">设为首页</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 1; background-color: #FFFFFF">
            </td>
        </tr>
    </table>
    <table width="100%" border="0" style="text-align: center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="background-image: Themes/Blue/Images/Home/bg_top.jpg">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 80px; width: 100%">
                            <img src="Themes/Blue/Images/Home/top-h.jpg" style="width: 100%; height: 80px" />
                            <%--<script type="text/javascript">                                InsertFlash("Themes/Blue/Images/Home/top.swf", "100%", "<%=FlashHeight %>", "top");</script>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" style="text-align: center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 13px; width: 100%">
                <img src="Themes/Blue/Images/Home/line_top.jpg" style="width: 100%; height: 13px" />
            </td>
        </tr>
    </table>
</div>
<div id="bannel3" style="border: 0 0 0; text-align: center;" runat="server">
    <table background="Themes/Blue/Images/Home/bg_menu.jpg" width="100%" border="0" style="text-align: left"
        cellpadding="0" cellspacing="0">
        <tr>
            <td width="15" height="20" nowrap>
            </td>
            <td>
                <asp:Literal runat="server" ID="Module_Title"></asp:Literal>
            </td>
        </tr>
    </table>
</div>
<script language="javascript">
    // 鼠标移入时
    function img_mouseover(obj) {
        var objsrc = obj.src;
        obj.src = obj.src.replace("_01", "_02");
    }

    //鼠标移出时
    function img_mouseout(obj) {
        var objsrc = obj.src;
        obj.src = obj.src.replace("_02", "_01");
    }

    //全局变量
    var oldMenuClassName = null;
    //选中事件
    function changeMenu(obj) {
        oldMenuClassName = obj.className;
        obj.className = "menuover";
    }

    //选中事件
    function OutMenu(obj) {
        obj.className = oldMenuClassName;
    }
</script>
