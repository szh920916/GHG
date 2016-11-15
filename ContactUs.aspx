<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南省温室气体排放数据报送平台 - 关于我们</title>
    <meta name="DESCRIPTION" content="河南省温室气体排放数据报送平台 - 安全、快捷、稳定、易用、专业的数据上报系统"/>
    <meta name="KEYWORDS" content="河南省温室气体排放数据报送平台,数据上报,能源统计报表"/>
    <link href="Themes/Default/layout.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
<!--

        function setTab(name, cursel, n) {
            for (i = 1; i <= n; i++) {
                var menu = document.getElementById(name + i);
                var con = document.getElementById("con_" + name + "_" + i);
                menu.className = i == cursel ? "check" : "";
                if (cursel == 1 && i == cursel) {
                    document.getElementById('none').style.display = "none";
                } else if (cursel == 2 && i == cursel) {
                    document.getElementById('none').style.display = "block";
                    menu.className = 'checks';
                }
                con.style.display = i == cursel ? "block" : "none";
            }
        }
        //-->d
    </script>
</head>
<body class="wrap">
    <div class="helpheader">
        <div class="helplogo" onclick="window.open('login.aspx',target='_top');">
            <a name="a" id="a" />
        </div>
    </div>
    <div class="helpmain">
        <ul class="helpmenu">
            <li id="one1" onclick="setTab('one',1,2)" class="check">联系我们</li>
        </ul>
        <div class="helpmaincenter">
            <div class="helpabout " id="con_one_1">
                <div class="ad">
                </div>
                <h1>
                    河南省冶金研究所有限责任公司</h1>  
                    <br />
                    <br />             
                <p><span class="icons"></span>电话：0371-63902026</p>
                <p><span class="icons"></span>传真：0371-63902025</p>
                <p><span class="icons"></span>邮箱：hngynyly@126.com</p>
                <p><span class="icons"></span>网址：http://hnsyjs.com/dwfw.asp</p>
                <p><span class="icons"></span>地址：郑州市金水区黄河北街4号附1号</p>
                <p><span class="icons"></span>邮编：450000</p>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-8272227-1");
            pageTracker._initData();
            pageTracker._trackPageview();
        } catch (err) { }
    </script>
</body>
</html>
