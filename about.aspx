<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南省温室气体排放数据报送平台 - 关于我们</title>
    <meta name="DESCRIPTION" content="河南省温室气体排放数据报送平台- 安全、快捷、稳定、易用、专业的数据上报系统"/>
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
            <li id="one1" onclick="setTab('one',1,2)" class="check">关于我们</li>
           
        </ul>
        <div class="helpmaincenter">
            <div class="helpabout " id="con_one_1">
                <div class="ad">
                </div>
                <h2>
                   河南省温室气体排放数据报送平台</h2>
                <p class="pre">
                    河南省温室气体排放数据报送平台是面向河南省工业企业，提供数据上报、统计分析的信息处理平台。</p>
                <p>
                    <span class="icon"></span>为企业提供一个24小时在线的数据保存地，随时随地访问您的数据</p>
                <p>
                    <span class="icons"></span>为管理机构提供完善的数据报表统计分析服务</p>
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
