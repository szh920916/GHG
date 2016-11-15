<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessDeny.aspx.cs" Inherits="AccessDeny" %>
<html>
<head>
    <title id="Title1" runat="server">访问被拒绝</title>
    <meta name="Coding" content="郑州锐升软件技术有限公司" />
    <meta name="Author" content="ZhengzhouRising@126.com">
    <base target="_self" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <style>
        .Button
        {
	        background-image: url(../../../Themes/Default/Images/Button.gif);
        }
        .ButtonLarge
        {
	        background-image: url(../../../Themes/Default/Images/ButtonLarge.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" method="post" runat="server">
        <table width="100%" height="100%">
            <tr>
                <td>
                    <div class="breadcrumbHeader">
                        <b>访问被拒绝</b>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="100%" height="100%" valign="middle">
                    <table style="table-layout: fixed">
                        <tr>
                            <td style="color: Red" align="center">
                                您没有访问此页面的权限.</td>
                            <tr>
                                <td style="color: Black" align="center">
                                    如有疑问,请与系统管理员联系.</td>
                            </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" style="height: 20px">
                    <asp:Button ID="btnBack" runat="server" Text="返回首页(B)" CssClass="Button" AccessKey="B"
                        TabIndex="2" onclick="btnBack_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>