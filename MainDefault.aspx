<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainDefault.aspx.cs" Inherits="Modules_EUoI_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎使用 河南省温室气体排放数据报送平台</title>
    <link href="../../Themes/Default/layout.css" type="text/css" rel="stylesheet" />
</head>
<body style="font-size:medium">
    <form id="form1" runat="server">
    <div style="font-size: large; text-align: center;">
    <br />
    <br />
        <h1>
            河南省温室气体排放数据报送平台</h1>
    </div>
    <div style="margin-left:10%; margin-right:10%; margin-top:25px">
        <p class="pre">
            河南省温室气体排放数据报送平台，提供数据上报以及统计分析服务的信息处理平台。</p>
        <p><span class="icon"/>为企业提供一个24小时在线的数据保存地，通过网络可随时随地访问您的数据</p>
        <p><span class="icons"/>为管理机构提供完善的数据报表统计分析服务</p>
        <br />
        <p>开始操作前，请<asp:HyperLink ID="lnkInfo" runat="server">完善详细信息</asp:HyperLink>，否则将无法进行数据上报。</p>
    </div>

    </form>
</body>
</html>
