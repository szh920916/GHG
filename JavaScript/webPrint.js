
        var HKEY_Root, HKEY_Path, HKEY_Key;
        HKEY_Root = "HKEY_CURRENT_USER";
        HKEY_Path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";    
        function fn01() {
            try {
                var Wsh = new ActiveXObject("WScript.Shell");
                HKEY_Key = "header";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
                HKEY_Key = "footer";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
            }
            catch (e) { }
            var oricontent = window.document.body.innerHTML;
            var content = window.document.getElementById("content").innerHTML;
            if (content.indexOf("id=\"WebBrowser\"") < 0)
                content = content + "<object id=\"WebBrowser\" classid=\"CLSID:8856F961-340A-11D0-A96B-00C04FD705A2\" height=\"0\" width=\"0\">";
            parent.document.getElementById("topfram").style.display = "none";
            parent.document.getElementById("leftfram").style.display = "none";
            parent.document.frames[2].document.body.innerHTML = content;
            var rows = parent.frames["parentfram"].rows;
            var cols = parent.frames["myframeset"].cols;
            parent.frames["parentfram"].rows = "0,*";
            parent.frames["myframeset"].cols = "0,*";
            parent.frames["myframeset"].style.border = 0;
            parent.frames["parentfram"].style.border = 0;
            parent.frames["parentfram"].frameBorder = "no";
            parent.frames["myframeset"].border = 0;
            parent.frames["myframeset"].frameBorder = "no";
            WebBrowser.ExecWB(7, 1);
            parent.document.getElementById("topfram").style.display = "block";
            parent.document.getElementById("leftfram").style.display = "block";
            parent.frames["parentfram"].rows = rows;
            parent.frames["myframeset"].cols = cols;
            parent.frames["parentfram"].frameBorder = "yes";
            parent.frames["myframeset"].border = 1;
            parent.frames["myframeset"].frameBorder = "yes";
            window.document.body.innerHTML = oricontent;
        }
        function fn03() {
            try {
                var Wsh = new ActiveXObject("WScript.Shell");
                HKEY_Key = "header";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
                HKEY_Key = "footer";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
            }
            catch (e) { }
            var oricontent = window.document.body.innerHTML;
            var content = window.document.getElementById("content").innerHTML;
            alert(content);
            if (content.indexOf("id=\"WebBrowser\"") < 0)
                content = content + "<object id=\"WebBrowser\" classid=\"CLSID:8856F961-340A-11D0-A96B-00C04FD705A2\" height=\"0\" width=\"0\">";
            parent.document.getElementById("topfram").style.display = "none";
            parent.document.getElementById("leftfram").style.display = "none";
            window.document.body.innerHTML = content;
            var rows = parent.frames["parentfram"].rows;
            var cols = parent.frames["myframeset"].cols;
            parent.frames["parentfram"].rows = "0,*";
            parent.frames["myframeset"].cols = "0,*";
            parent.frames["parentfram"].frameBorder = "no";
            parent.frames["myframeset"].border = 0;
            parent.frames["myframeset"].frameBorder = "no";
            WebBrowser.ExecWB(6, 1);
            parent.document.getElementById("topfram").style.display = "block";
            parent.document.getElementById("leftfram").style.display = "block";
            parent.frames["parentfram"].rows = rows;
            parent.frames["myframeset"].cols = cols;
            parent.frames["parentfram"].frameBorder = "yes";
            parent.frames["myframeset"].border = 1;
            parent.frames["myframeset"].frameBorder = "yes";

            window.document.body.innerHTML = oricontent;

        }
        function fn02() {
            var oricontent = window.document.body.innerHTML;
            var content = window.document.getElementById("content").innerHTML;
            print(content);
        }

        function print(PrintContent) {
            var w = screen.availWidth - 10;
            var h = screen.availHeight - 50;
            var url = document.URL;
            var index = url.lastIndexOf('/');
            url = url.substring(0,index + 1) + "print.html";
            var printWindow = window.open("", "print", 'left = 0,top = 0,width= ' + w + ',height=' + h + ',resizable = yes,toolbar= yes,menubar = yes,status = yes,location = yes,scrollbars= yes');
            var html = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"><html>";
            var header = "<head>";
            var link = '<link type=\"text/css\" rel=\"stylesheet\" href=\"../../../Themes/GHG/global.css\" />';
            link += '<link type=\"text/css\" rel=\"stylesheet\" href=\"../../../Themes/GHG/skin_163blue.css\" />';
            link += '<link href=\"../../../Themes/GHG/ReportLayout.css\" rel=\"stylesheet\" type=\"text/css\" />';
            var script = '<script language=\"javascript\">';
            script += "function $(obj) { return window.document.getElementById(obj);} ";
            script += "function fPrint(){$('t1').style.display = 'none';$('t2').style.display = 'none';$('line1').style.display = 'none';$('line2').style.display = 'none';window.print();window.location.reload();$('t1').style.display = '';$('t2').style.display = '';$('line1').style.display = '';$('line2').style.display = '';}"; //window.location.reload(); $('t1').style.display = '';$('t2').style.display = '';}";
            script += "<\/script>";
            header += link;
            header += '<title>打印</title><meta http-equiv=\"content-type\" content=\"text/html\"; charset=\"gb2312\">';
            header += script;
            header += "</head>";
            var body = "<body bgcolor='#ffffff'>";
            var main = "<div class='gRead gRead-newwin'><div id='t1' class='g-toolbar'>";
            var toolbarHeader = "<div class='btngrp'><div class='btn btn-dft' onclick='fPrint()' onmouseup=\"this.className='btn btn-dft btn-dft-hover'\" onmousedown=\"this.className='btn btn-dft btn-dft-active'\" onmouseout=\"this.className='btn btn-dft'\" onmouseover=\"this.className='btn btn-dft btn-dft-hover'\"><span>打印报表</span></div></div>";
            toolbarHeader += "<div class='btngrp'><div class='btn btn-dft' onclick='window.close();' onmouseup=\"this.className='btn btn-dft btn-dft-hover'\" onmousedown=\"this.className='btn btn-dft btn-dft-active'\" onmouseout=\"this.className='btn btn-dft'\" onmouseover=\"this.className='btn btn-dft btn-dft-hover'\"><span>关闭该页面</span></div></div></div>";
            main += toolbarHeader;
            main += "<div id='line1' class='ln-thin ln-c-mid'></div>";
            //var content = "<div style='text-align:center;'><!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"><HTML><HEAD><STYLE></STYLE></HEAD><body bgcolor='#ffffff'>" + PrintContent + "</body></html></div>";
            var content = "<div style='text-align:center;'>" + PrintContent + "</div>";
            main += content;
            main += "<div id='line2' class='ln-thin ln-c-mid'></div>";
            main += "<div id='t2' class='g-toolbar'>";
            main += toolbarHeader;
            main += "</div>";
            body += main;
            body += "</body>";
            html += header + body;
            html += "</html>";
            printWindow.document.write(html);
            printWindow.focus();
        }