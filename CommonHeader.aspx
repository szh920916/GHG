<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommonHeader.aspx.cs" Inherits="CommonHeader" %>

<%@ Register Src="CommonTop.ascx" TagName="CommonTop" TagPrefix="CommonTop" %>
<html>
<head id="Head1" runat="server">
    <title>河南省温室气体排放数据报送平台 - 综合管理</title>
    <link href="Themes/Blue/css.css" rel="stylesheet" type="text/css" />
    <link href="Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        // 防止从首页点击进入框架页面，再点击返回按钮出现框架嵌套问题
        if (this.parent.window != this.top) {
            this.top.location.href = this.parent.window.location.href;
        }
    </script>
    <script type="text/javascript" src="JavaScript/flash.js"></script>
</head>
<body style="margin-bottom: 0px; margin-top: 0px; margin-left: 0px;">
    <form id="form1" runat="server">
    <CommonTop:CommonTop ID="TopStyle" runat="server"></CommonTop:CommonTop>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
        <tr>
            <td height="1" colspan="3">
            </td>
        </tr>
        <tr>
            <td width="250" align="left" nowrap="nowrap" background="Themes/Blue/Images/Home/bg_menu_02.gif"
                bgcolor="#f1f1f1" style="height: 20px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="65px" align="center" style="height: 23px">
                            <asp:Image ID="showLeft" BorderWidth="0px" runat="server" />
                        </td>
                        <td width="65px" align="center" style="height: 23px">
                            <img borderwidth="0px" onMouseOver="img_mouseover(this);" onMouseOut="img_mouseout(this);"
                                onclick="Img_Refurbish();" src="Themes/Blue/Images/Home/but_sx_01.gif"
                                border="0" style="cursor: hand" title="点击刷新内容页面">
                        </td>
                        <td width="" align="center" style="height: 23px">                            
                        </td>
                        <td width="65px" align="center" style="height: 23px">
                            <img borderwidth="0px" onMouseOver="img_mouseover(this);" onMouseOut="img_mouseout(this);"
                                onclick="loginOut()" src="Themes/Blue/Images/Home/but_tc_01.gif"
                                border="0" style="cursor: hand" title="点击安全退出本次登录">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100%" align="center" background="Themes/Blue/Images/Home/bg_menu_02.gif"
                bgcolor="#f1f1f1" borderwidth="0px" style="height: 20px">
                <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <asp:Literal ID="Module_SunTitle" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="30" align="center" nowrap="nowrap" background="Themes/Blue/Images/Home/bg_menu_02.gif">
                <asp:Image ID="showTop" runat="server" BorderWidth="0px" />
            </td>
        </tr>
        <tr>
            <td height="1" colspan="3">
            </td>
        </tr>
        <tr>
            <td height="1" colspan="3" bgcolor="#e0e0e0">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script language="javascript">
    function ReloadSession() {

        XmlPost("Modules/Common/User/UserOnLine.aspx");
        // 每100秒钟刷新一次
        // alert("ReloadSession");
        setTimeout("ReloadSession()", 1000 * 100);
    }

    ReloadSession();

    // 打开登录窗口
    function openShowModal() {
        this.top.location.href = "Login.aspx";
        
        /*
        var urlpath = "OpenLogin.aspx?temp=" + new Date().toString();
        var Query = "center: Yes; help: Yes; resizable: No; status: no;scroll:no; dialogHeight :240px; dialogWidth:320px;";

        var tmp = window.showModalDialog(urlpath, window, Query);

        if (tmp == "1") {
            alert("登录成功，欢迎使用本系统。");
        }

        //无论是否登录,均重新刷新
        SetUserLoginInfo();
        */
    }
    
    // 安全退出 注销
    function loginOut(){
        this.top.location.href = "Logouting.aspx";
    }
    
//    // 设置用户登录信息
//    function SetUserLoginInfo() {
//        //运用xmlhttp取得登录用户信息，写到LoginInfo中
//        var UserInfo = XmlPost("WaterHeader.aspx?action=GetUserInfo");
//        //直接运行返回的脚本
//        window.execScript(UserInfo);
//    }

    // 调用设置用户登录信息
    //SetUserLoginInfo();

    // 显示或隐藏左边框架
    //obj:当前点击的图片
    //ExpandWidth:左框架展开的宽度
    function toggleTree(obj, ExpandWidth) {
        //获取当前点击图标的路径
        var imgsrc = obj.src;
        //判断当前左框架宽度
        var mywidth = parent.myframeset.cols;
        if (mywidth == "0,*") {
            //展开左框架
            parent.myframeset.cols = ExpandWidth + ",*";
            //更新图标
            obj.src = imgsrc.replace("but_yc_01.gif", "but_yc_02.gif");
            obj.src = imgsrc.replace("but_xs_01.gif", "but_xs_02.gif");
            obj.title = "点击关闭左侧页面";
            //更新展开信息
            XmlPost("Modules/Common/User/UserOnLine.aspx?ShowLeftFrame=True");
        }
        else
        {
            //收缩左框架
            parent.myframeset.cols = "0,*";
            //更新图标
            obj.src = imgsrc.replace("but_yc_02.gif", "but_yc_01.gif");
            obj.src = imgsrc.replace("but_xs_02.gif", "but_xs_01.gif");

            obj.title = "点击显示左侧页面";

            //更新展开信息
            XmlPost("Modules/Common/User/UserOnLine.aspx?ShowLeftFrame=False");
        }
    }

    // 以XML求取数据
    //webFileUrl:要读取的页面地址,可带参数
    function XmlPost(webFileUrl) {
        try {
            // alert(webFileUrl);
            var result = "";
            var xmlHttp = new ActiveXObject("MSXML2.XMLHTTP");
            xmlHttp.open("POST", webFileUrl, false);
            xmlHttp.send("");
            result = xmlHttp.responseText;
            // alert(result);
            return (result);
        }
        catch (e) {
            return ("脚本错误,未取到正确数据!");
        }
    }

    // 显示或隐藏顶部框架
    //obj:当前点击的图像
    //openHeight:上框架展开的高度
    //offHeight:上框架收缩的高度
    function toggleBanner(obj, openHeight, offHeight, hidTable1) {
        var imgsrc = obj.src;
        var xrows = parent.parentfram.rows;

        if (xrows == (openHeight + ",*").toString()) {
            //如果现有是打开,则关闭
            //更新图标
            obj.src = imgsrc.replace("but_up_01.gif", "but_up_02.gif");
            obj.src = imgsrc.replace("but_down_01.gif", "but_down_02.gif");

            //如果是收缩
            parent.parentfram.rows = offHeight + ",*";
            obj.title = "点击展开头部页面";
            //隐藏顶部表格
            document.all(hidTable1).style.display = "none";
            //更新展开信息
            XmlPost("Modules/Common/User/UserOnLine.aspx?ShowTopFrame=False");
        }
        else
        {
            //更新图标
            obj.src = imgsrc.replace("but_up_02.gif", "but_up_01.gif");
            obj.src = imgsrc.replace("but_down_02.gif", "but_down_01.gif");
            //如果是展开
            obj.title = "点击显示头部页面";
            parent.parentfram.rows = openHeight + ",*";
            //显示顶部表格
            document.all(hidTable1).style.display = "block";
            //更新展开信息
            XmlPost("Modules/Common/User/UserOnLine.aspx?ShowTopFrame=True");
        }
    }

    // 刷新MAIN页面
    function Img_Refurbish() {
        top.frames("fraContent").location.reload()
    }
</script>