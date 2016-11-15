<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南省温室气体上报管理系统 - 登录系统</title>
    <link href="Themes/Default/layout.css" type="text/css" rel="stylesheet" />
    <script src="JavaScript/loginValidate.js" type="text/javascript"></script>


    <!--悬浮窗-->

 <style type="text/css">
#msg_win{border:1px solid #A67901;background:#EAEAEA;width:240px;position:absolute;right:0;font-size:12px;font-family:Arial;margin:0px;display:none;overflow:hidden;z-index:99;}
#msg_win .icos{position:absolute;top:2px;*top:0px;right:2px;z-index:9;}
.icos a{float:left;color:#833B02;margin:1px;text-align:center;font-weight:bold;width:14px;height:22px;line-height:22px;padding:1px;text-decoration:none;font-family:webdings;}
.icos a:hover{color:#fff;}
#msg_title{background:#FECD00;border-bottom:1px solid #A67901;border-top:1px solid #FFF;border-left:1px solid #FFF;color:#000;height:25px;line-height:25px;text-indent:5px;}
#msg_content{margin:5px;margin-right:0;width:230px;height:126px;overflow:hidden;}
</style>
</head>



<body>


<div id="msg_win" style="display:block;top:490px;visibility:visible;opacity:1;">
<div class="icos"><a id="msg_min" title="最小化" href="javascript:void 0" _fcksavedurl="javascript:void 0">_</a><a id="msg_close" title="关闭" href="javascript:void 0" _fcksavedurl="javascript:void 0">×</a></div>
<div id="msg_title">系统更新提示</div>
<div id="msg_content">1、系统版本已经升级，填报时请查看填报注意事项及新版用户手册
<br />
2、系统访问网址：http://gynyly.smehen.gov.cn/</div>
</div>
<script language="javascript">
    var Message = {
        set: function () {//最小化与恢复状态切换
            var set = this.minbtn.status == 1 ? [0, 1, 'block', this.char[0], '最小化'] : [1, 0, 'none', this.char[1], '恢复'];
            this.minbtn.status = set[0];
            this.win.style.borderBottomWidth = set[1];
            this.content.style.display = set[2];
            this.minbtn.innerHTML = set[3]
            this.minbtn.title = set[4];
            this.win.style.top = this.getY().top;
        },
        close: function () {//关闭
            this.win.style.display = 'none';
            window.onscroll = null;
        },
        setOpacity: function (x) {//设置透明度
            var v = x >= 100 ? '' : 'Alpha(opacity=' + x + ')';
            this.win.style.visibility = x <= 0 ? 'hidden' : 'visible'; //IE有绝对或相对定位内容不随父透明度变化的bug
            this.win.style.filter = v;
            this.win.style.opacity = x / 100;
        },
        show: function () {//渐显
            clearInterval(this.timer2);
            var me = this, fx = this.fx(0, 100, 0.1), t = 0;
            this.timer2 = setInterval(function () {
                t = fx();
                me.setOpacity(t[0]);
                if (t[1] == 0) { clearInterval(me.timer2) }
            }, 10);
        },
        fx: function (a, b, c) {//缓冲计算
            var cMath = Math[(a - b) > 0 ? "floor" : "ceil"], c = c || 0.1;
            return function () { return [a += cMath((b - a) * c), a - b] }
        },
        getY: function () {//计算移动坐标
            var d = document, b = document.body, e = document.documentElement;
            var s = Math.max(b.scrollTop, e.scrollTop);
            var h = /BackCompat/i.test(document.compatMode) ? b.clientHeight : e.clientHeight;
            var h2 = this.win.offsetHeight;
            return { foot: s + h + h2 + 2 + 'px', top: s + h - h2 - 2 + 'px' }
        },
        moveTo: function (y) {//移动动画
            clearInterval(this.timer);
            var me = this, a = parseInt(this.win.style.top) || 0;
            var fx = this.fx(a, parseInt(y));
            var t = 0;
            this.timer = setInterval(function () {
                t = fx();
                me.win.style.top = t[0] + 'px';
                if (t[1] == 0) {
                    clearInterval(me.timer);
                    me.bind();
                }
            }, 10);
        },
        bind: function () {//绑定窗口滚动条与大小变化事件
            var me = this, st, rt;
            window.onscroll = function () {
                clearTimeout(st);
                clearTimeout(me.timer2);
                me.setOpacity(0);
                st = setTimeout(function () {
                    me.win.style.top = me.getY().top;
                    me.show();
                }, 600);
            };
            window.onresize = function () {
                clearTimeout(rt);
                rt = setTimeout(function () { me.win.style.top = me.getY().top }, 100);
            }
        },
        init: function () {//创建HTML
            function $(id) { return document.getElementById(id) };
            this.win = $('msg_win');
            var set = { minbtn: 'msg_min', closebtn: 'msg_close', title: 'msg_title', content: 'msg_content' };
            for (var Id in set) { this[Id] = $(set[Id]) };
            var me = this;
            this.minbtn.onclick = function () { me.set(); this.blur() };
            this.closebtn.onclick = function () { me.close() };
            this.char = navigator.userAgent.toLowerCase().indexOf('firefox') + 1 ? ['_', '::', '×'] : ['0', '2', 'r']; //FF不支持webdings字体
            this.minbtn.innerHTML = this.char[0];
            this.closebtn.innerHTML = this.char[2];
            setTimeout(function () {//初始化最先位置
                me.win.style.display = 'block';
                me.win.style.top = me.getY().foot;
                me.moveTo(me.getY().top);
            }, 0);
            return this;
        }
    };
    Message.init();
</script>


    <form id="from1" runat="server" method="post">
    <div style="width: 1100px;">
        <div class="entermain">
            <div class="enterheader">
            </div>
            <div class="entercenter">
                <div class="enteright">
                    <p class="aimienter">
                        <em class="aimicons"></em><a href="#">河南省温室气体上报管理系统</a></p>
                    <table>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <em class="infogray" id="delever"></em><em class="info" id="loginTip" runat="server">
                                </em>&nbsp;&nbsp;<em class="info" id="passwordTip"></em><em class="info" id="validateid"></em>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                用户名：
                            </th>
                            <td>
                                <input type="text" class="enterinputext" id="txtUserName" name="username" maxlength="256"
                                    value="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                密码：
                            </th>
                            <td>
                                <input type="password" class="enterinputext" id="txtPassword" name="password" maxlength="32"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td class="loginclause">
                                <asp:CheckBox type="checkbox" ID="chkPersistCookie" runat="server" Checked="false" Visible="false" />
                                <%--<em>记住密码</em>--%><asp:Button ID="btnLogin" CssClass="enterbutton" runat="server" Text=""
                                    OnClientClick="return submitLogin()" OnClick="btnLogin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="enterfooter">
            <div class="entercopyrights">
                <ul>
                    <li><a href="about.aspx" target="_blank">关于我们</a></li>
                    <li><a href="ContactUs.aspx" target="_blank">联系我们</a></li>
                    <li><a href="service.aspx" target="_blank">服务条款</a></li>
                    <li  class="last">河南省冶金研究所有限责任公司 版权所有</li>
                </ul>
            </div>
        </div>
    </div>
  
    
    </form>
</body>
</html>
