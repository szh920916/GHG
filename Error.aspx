<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>错误处理页</title>
    <style type="text/css">
        body
        {
            font-size: 13px;
            background: #eee;
            color: #000;
            padding: 32px;
        }
        div#content
        {
            background: #fff;
            padding: 20px;
            border: 1px solid #bbb;
        }
        h1
        {
            padding-right: 0px;
            padding-left: 0px;
            padding-top: 0px;
            padding-bottom: 10px;
            font-weight: bold;
            font-size: 120%;
            margin: 0px;
            color: #904;
        }
        h2
        {
            padding-right: 0px;
            padding-left: 0px;
            font-weight: bold;
            font-size: 105%;
            padding-bottom: 0px;
            margin: 0px 0px 8px;
            text-transform: uppercase;
            color: #999;
            padding-top: 0px;
            border-bottom: #ddd 1px solid;
            font-family: "trebuchet ms" , "" lucida grande "" , verdana, arial, sans-serif;
        }
        p
        {
            padding-right: 0px;
            padding-left: 0px;
            padding-bottom: 6px;
            margin: 0px;
            padding-top: 6px;
        }
        a:link
        {
            color: #002c99;
            text-decoration: none;
        }
        a:visited
        {
            color: #002c99;
            text-decoration: none;
        }
        a:hover
        {
            color: #cc0066;
            background-color: #f5f5f5;
            text-decoration: underline;
        }
        a
        {
            padding: 0px 5px;
        }
    </style>
</head>
<body style="width: 92%">
    <form id="form1" runat="server">
    <div id="content">
        <h1>
            由于安全需要，请重新登录后继续操作...<br />
            如果重新登录后本提示仍然出现，请联系管理员<br />
        </h1>
  
    </form>
</body>
</html>

<script type="text/javascript">
    function ShowStackInfo(chk) {
        if (chk.checked)
            document.getElementById("stackInfo").style.display = "";
        else
            document.getElementById("stackInfo").style.display = "none";
    }
</script>

