
function SetTopNavSiteMapLinkBorder(strTdId, fIsHover)
{
	if (!document.getElementById ||
		'undefined' == typeof(document.getElementById))
		return;

	var tdCell = document.getElementById(strTdId);
	if ('undefined' == typeof(tdCell) ||
		null == tdCell ||
		'undefined' == typeof(tdCell.className))
		return; 

	if (fIsHover)
		tdCell.className = 'TopNavCellLinkHover';
	else
		tdCell.className = 'TopNavCellLink';
}

function EncodeUrlComponent(strUrlComponent)
{
	if (typeof(strUrlComponent) == "undefined" ||
		null == strUrlComponent)
		return "";

	if (typeof(encodeURIComponent) != "undefined") 
		return EncodeUrlComponent55(strUrlComponent);

	return EncodeUrlComponent50(strUrlComponent);
}

function EncodeUrlComponent55(strUrlComponent)
{
	return encodeURIComponent(strUrlComponent);
}

function EncodeUrlComponent50(strUrlComponent)
{
	var i=0;
	var strEncoded = "";
	for (i=0; i < strUrlComponent.length; i++)
		{
		var chr = strUrlComponent.charAt(i);
		var iChr = strUrlComponent.charCodeAt(i);

		if (iChr < 128)
			{
			if ('!' == chr || '\'' == chr || '(' == chr || 	')' == chr || '~' == chr)
				strEncoded += chr;
			else if (0 == iChr)
				strEncoded += "%00";
			else if (127 == iChr)
				strEncoded += "%7F";
			else if ('+' == chr)
				strEncoded += "%2B";
			else if ('/' == chr)
				strEncoded += "%2F";
			else if ('@' == chr)
				strEncoded += "%40";
			else
				strEncoded += escape(chr);
			}
		else if (iChr < 2048)
			{
			strEncoded += "%";
			strEncoded += ( (iChr >> 6) + 192).toString(16).toUpperCase();

			strEncoded += "%";
			strEncoded += ( (iChr & 63) + 128).toString(16).toUpperCase();
			}
		else 
			{
			strEncoded += "%";
			strEncoded += ( (iChr >> 12) + 224).toString(16).toUpperCase();

			strEncoded += "%";
			strEncoded += ( ((iChr >> 6) & 63) + 128).toString(16).toUpperCase();

			strEncoded += "%";
			strEncoded += ( (iChr & 63) + 128).toString(16).toUpperCase();
			}
		}

	return strEncoded;
}

function StrTrim(str)
{
	if (typeof(str) == "undefined" || null == str)
		return null;

	while (str.length > 0 && str.charCodeAt(0) <= 32)
		str = str.substring(1);

	while (str.length > 0 && str.charCodeAt(str.length-1) <= 32)
		str = str.substring(0, str.length-1);

	return str;
}

function FIsEmailAddressValid(strEmail)
{
	if (typeof(strEmail) == "undefined")
		return true;

	if (null == strEmail)
		return true;

	if (0 == strEmail.length)
		return true;

	for (var i=0; i < strEmail.length; i++)
		{
		if (strEmail.charCodeAt(i) > 127 )
			return false;
		}

	return true;
}

function FIsSupportedWindows()
{
	return ("Win32" == navigator.platform &&
		-1 == navigator.userAgent.indexOf("Windows 95") &&
		-1 == navigator.userAgent.indexOf("Windows 98") &&
		-1 == navigator.userAgent.indexOf("Windows ME") &&
		-1 == navigator.userAgent.indexOf("Windows NT 4") &&
		-1 == navigator.userAgent.indexOf("Windows CE"));
}









function OpenWindow(url,heigh,width)
{
   var NewWindow= window.open(url,'信息浏览','left=200,top=100,height='+heigh+',width='+width+',menubar=no,status=no,location=no,directories=no,resizable=yes,scrollbars=yes')
   NewWindow.focus();//不要返回return NewWindow;否则原页面会只显示[Object]  alter by lsd 20090306
   
} 
            function fun_option(obj)
            {
                document.Form1.hiduserid.value=obj.value;
            }  
                        function urlto(url)
            {
                document.location.href=url;
            }   
            
          //是否选中所有checkbox             
           function chkAll_true()
            {
                var chkall= document.getElementById("chkAll");
                var chkother = document.getElementsByTagName("input");
                for (var i=0;i<chkother.length;i++)
                {
                    if (chkother[i].type == 'checkbox')
                    {
                        if (chkother[i].id.indexOf('Id') > -1 && !chkother[i].disabled)
                        {
                            if(chkall.checked==true)
                            {
                                chkother[i].checked=true;
                            }
                            else
                            {
                                chkother[i].checked=false;
                            }
                        }
                    }
                }
            }
 
           //是否对选中的记录进行删除操作
            function Delete() {
                var msg = "您确实要删除这些记录？";
                var header = "请选择记录！";
                
                if (arguments.length > 0)
                    msg = arguments[0];
                
                if (arguments.length >= 2)
                    header = arguments[1];
                    
                var al = new Array();
                var chkother = document.getElementsByTagName("input");
                for (var i = 0, j = 0; i < chkother.length; i++) {
                    if (chkother[i].type == 'checkbox') {
                        if (chkother[i].id.indexOf('Id') > -1) {
                            if (chkother[i].checked == true) {
                                al[j] = chkother[i].value;
                                j++;
                            }
                        }
                    }
                }
                if (al == "") {
                    alert(header);
                    return false;
                }
                else if (window.confirm(msg)) {

                    return true;
                }
                else { return false; }
            }

            function Pass() {
                var msg = "您确实要审核通过这些记录？";
                var header = "请选择记录！";

                if (arguments.length > 0)
                    msg = arguments[0];

                if (arguments.length >= 2)
                    header = arguments[1];

                var al = new Array();
                var chkother = document.getElementsByTagName("input");
                for (var i = 0, j = 0; i < chkother.length; i++) {
                    if (chkother[i].type == 'checkbox') {
                        if (chkother[i].id.indexOf('Id') > -1) {
                            if (chkother[i].checked == true) {
                                al[j] = chkother[i].value;
                                j++;
                            }
                        }
                    }
                }
                if (al == "") {
                    alert(header);
                    return false;
                }
                else if (window.confirm(msg)) {

                    return true;
                }
                else { return false; }
            }

            function Reject() {
                var msg = "您确实要审核驳回这些记录？";
                var header = "请选择记录！";

                if (arguments.length > 0)
                    msg = arguments[0];

                if (arguments.length >= 2)
                    header = arguments[1];

                var al = new Array();
                var chkother = document.getElementsByTagName("input");
                for (var i = 0, j = 0; i < chkother.length; i++) {
                    if (chkother[i].type == 'checkbox') {
                        if (chkother[i].id.indexOf('Id') > -1) {
                            if (chkother[i].checked == true) {
                                al[j] = chkother[i].value;
                                j++;
                            }
                        }
                    }
                }
                if (al == "") {
                    alert(header);
                    return false;
                }
                else if (window.confirm(msg)) {

                    return true;
                }
                else { return false; }
            }
            
            //是否对选中的记录进行删除操作 --add by lsd 20081216
            function DeleteMsg(Msg)
            {
               var  al = new Array();
                var chkother= document.getElementsByTagName("input");
                for(var i=0,j=0;i<chkother.length;i++)
                {
                    if( chkother[i].type =='checkbox')
                    {
                        if(chkother[i].id.indexOf('Id')>-1)
                        {
                            if(chkother[i].checked==true)
                            {
                                al[j] =chkother[i].value;
                                j++;
                            }
                        }
                    }
                }
                if (al == "")
                {
                    alert("请选择记录！");
                    return false;
                } 
                else if (window.confirm(Msg))
                {
                 
                    return true;
                }
                else { return false; }           
            }
          
          //是否对选中的记录进行修改操作  
            function Update()
            {
               var  al = new Array();
                var chkother= document.getElementsByTagName("input");
                for(var i=0,j=0;i<chkother.length;i++)
                {
                    if( chkother[i].type =='checkbox')
                    {
                        if(chkother[i].id.indexOf('Id')>-1)
                        {
                            if(chkother[i].checked==true)
                            {
                                al[j] =chkother[i].value;
                                j++;
                            }
                        }
                    }
                } 
                 if (al == "")
                {
                    alert("请选择记录！");
                    return false;
                }
                else if (al.length>1)
                {
                   alert("只能选择一条记录！");
                   return false;
                }
                else { 
                    return true;
                 }           
            }
            
            function UpdateMsg(Msg)
            {
               var  al = new Array();
                var chkother= document.getElementsByTagName("input");
                for(var i=0,j=0;i<chkother.length;i++)
                {
                    if( chkother[i].type =='checkbox')
                    {
                        if(chkother[i].id.indexOf('Id')>-1)
                        {
                            if(chkother[i].checked==true)
                            {
                                al[j] =chkother[i].value;
                                j++;
                            }
                        }
                    }
                } 
                 if (al == "")
                {
                    alert("请选择记录！");
                    return false;
                }
                else if (al.length>1)
                {
                   alert("只能选择一条记录！");
                   return false;
                }
                else if (window.confirm(Msg))
                {
                 
                    return true;
                }
                else { 
                
                    return false;
                 }           
            }
            
            
        function UpdateMsgBox(Msg)
            {
               if (window.confirm(Msg))
                {
                 
                    return true;
                }
                else { 
                
                    return false;
                 }           
            }

            function NeedfulSelectedRecord(msg) {
                var m_msg = "请选择记录！";
                if (msg != "")
                    m_msg = msg;
                var al = new Array();
                var chkother = document.getElementsByTagName("input");
                for (var i = 0, j = 0; i < chkother.length; i++) {
                    if (chkother[i].type == 'checkbox') {
                        if (chkother[i].id.indexOf('Id') > -1) {
                            if (chkother[i].checked == true) {
                                al[j] = chkother[i].value;
                                j++;
                            }
                        }
                    }
                }
                if (al == "") {
                    alert(m_msg);
                    return false;
                }
                return true;
            }
 ///----------------------------------------------------form


            Validator = {
                Require: /.+/,
                Email: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
                Phone: /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/,
                Mobile: /^((\(\d{2,3}\))|(\d{3}\-))?13\d{9}$/,
                Url: /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
                IdCard: "this.IsIdCard(value)  || this.IsMilIDCard(value) ",
                Currency: /^\d+(\.\d+)?$/,
                Number: /^\d+$/,
                Zip: /^[1-9]\d{5}$/,
                QQ: /^[1-9]\d{4,8}$/,
                Integer: /^[-\+]?\d+$/,
                Double: /^\d+(\.\d+)?$/, //update by wxg 2009521
                English: /^[A-Za-z]+$/,
                Chinese: /^[\u0391-\uFFE5]+$/,
                Username: /^[a-z]\w{3,}$/i,
                //UnSafe : /^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/,
                UnSafe: /^((\w|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/,
                IsSafe: function(str) { return !this.UnSafe.test(str); },
                SafeString: "this.IsSafe(value)",
                Filter: "this.DoFilter(value, getAttribute('accept'))",
                Limit: "this.limit(value.length,getAttribute('min'),  getAttribute('max'))",
                LimitB: "this.limit(this.LenB(value), getAttribute('min'), getAttribute('max'))",
                Date: "this.IsDate(value, getAttribute('format'),getAttribute('min'))", //--加入 日期的大小比较
                DateCn: "this.thisDateCn(value)",
                Repeat: "value == document.getElementsByName(getAttribute('to'))[0].value",
                Range: "getAttribute('min') < (value|0) && (value|0) < getAttribute('max')",
                Compare: "this.compare(value,getAttribute('operator'),getAttribute('to'))",
                Custom: "this.Exec(value, getAttribute('regexp'))",
                Group: "this.MustChecked(getAttribute('name'), getAttribute('min'), getAttribute('max'),getAttribute('require'))",
                Select3: "this.MustSelected(getAttribute('name'))", //--如果选择框值不大于0,提示选择,add by liaojf(2004-4-4)
                ErrorItem: [document.forms[0]],
                ErrorMessage: ["以下原因导致保存失败：\t\t\t\t"],
                Validate: function(theForm, mode) {
                    var obj = theForm || event.srcElement;
                    var count = obj.elements.length;
                    this.ErrorMessage.length = 1;
                    this.ErrorItem.length = 1;
                    this.ErrorItem[0] = obj;
                    for (var i = 0; i < count; i++) {
                        with (obj.elements[i]) {
                            obj.elements[i].style.backgroundColor = "#FFFFFF";
                            var _dataType = getAttribute("dataType");
                            if (typeof (_dataType) == "object" || typeof (this[_dataType]) == "undefined") continue;
                            this.ClearState(obj.elements[i]);
                            if (getAttribute("require") == "false" && value == "") continue;
                            switch (_dataType) {
                                case "IdCard":
                                case "Date":
                                case "Repeat":
                                case "Range":
                                case "Compare":
                                case "Custom":
                                case "Group":
                                case "DateCn":
                                case "Select3":
                                case "Limit":
                                case "LimitB":
                                case "SafeString":
                                case "QueryStr":
                                case "Filter":
                                    if (!eval(this[_dataType])) {
                                        //增加一个是否忽略检测的属性ignore,忽略属性为1时表示忽略此项检测
                                        var attr = getAttribute("ignore")
                                        if (!(typeof(attr) != undefined && attr == "1")) {                                            
                                            this.AddError(i, getAttribute("msg"));
                                        }
                                    }
                                    break;
                                default:
                                    if (!this[_dataType].test(value)) {
                                        this.AddError(i, getAttribute("msg"));
                                    }
                                    break;
                            }
                        }
                    }
                    if (this.ErrorMessage.length > 1) {
                        mode = mode || 1;
                        var errCount = this.ErrorItem.length;
                        switch (mode) {
                            case 2:
                                for (var i = 1; i < errCount; i++)
                                //this.ErrorItem[i].style.color = "red";
                                    this.ErrorItem[i].style.backgroundColor = "#FFFFCC";
                            case 1:
                                alert(this.ErrorMessage.join("\n"));
                                try
                                {
                                    this.ErrorItem[1].focus();
                                }catch(e1){}
                                break;
                            case 3:
                                for (var i = 1; i < errCount; i++) {
                                    try {
                                        var span = document.createElement("SPAN");
                                        span.id = "__ErrorMessagePanel";
                                        span.style.color = "red";
                                        this.ErrorItem[i].parentNode.appendChild(span);
                                        span.innerHTML = this.ErrorMessage[i].replace(/\d+:/, "*");
                                    }
                                    catch (e) { alert(e.description); }
                                }
                                try
                                {
                                    this.ErrorItem[1].focus();
                                }catch(e1){}
                                break;
                            default:
                                alert(this.ErrorMessage.join("\n"));
                                break;
                        }
                        return false;
                    }
                    return true;
                },
                limit: function(len, min, max) {
                    min = min || 0;
                    max = max || Number.MAX_VALUE;
                    return min <= len && len <= max;
                },
                LenB: function(str) {
                    return str.replace(/[^\x00-\xff]/g, "**").length;
                },
                ClearState: function(elem) {
                    with (elem) {
                        //			if(style.color == "red")
                        //				style.color = "";
                        if (style.backgroundColor == "#FFFFCC")
                            style.backgroundColor = "";
                        var lastNode = parentNode.childNodes[parentNode.childNodes.length - 1];
                        if (lastNode.id == "__ErrorMessagePanel")
                            parentNode.removeChild(lastNode);
                    }
                },
                AddError: function(index, str) {
                    this.ErrorItem[this.ErrorItem.length] = this.ErrorItem[0].elements[index];
                    this.ErrorMessage[this.ErrorMessage.length] = this.ErrorMessage.length + ":" + str;
                },
                Exec: function(op, reg) {
                    return new RegExp(reg, "g").test(op);
                },
                thisDateCn: function(v) {


                    if (v != '') {
                        psValue = v;
                        if (v.indexOf("年") != -1 & v.indexOf("月") != -1 & v.indexOf("日") != -1) {

                            psValue = v.replace("年", "-").replace("月", "-").replace("日", "");

                        }

                        psValue = psValue.replace("-", "/");
                        psValue = psValue.replace("-", "/");
                        psValue = psValue.replace(".", "/");
                        psValue = psValue.replace(".", "/");
                        psValue = psValue.replace("/0", "/");
                        psValue = psValue.replace("/0", "/");

                        var psValueArray = psValue.split("/");
                        if (psValueArray[0].length != 4) {
                            return false
                        }

                        var oDate = new Date(psValue);

                        var strYear = new String(oDate.getFullYear());
                        var strMonth = new String(oDate.getMonth() + 1);
                        var strDay = new String(oDate.getDate());

                        var strTestDate = strYear + "/" + strMonth + "/" + strDay;
                        return psValue == strTestDate;
                    }
                    else {
                        return false;
                    }


                },
                compare: function(op1, operator, op2) {
                    switch (operator) {
                        case "NotEqual":
                            return (op1 != op2);
                        case "GreaterThan":
                            return (op1 > op2);
                        case "GreaterThanEqual":
                            return (op1 >= op2);
                        case "LessThan":
                            return (op1 < op2);
                        case "LessThanEqual":
                            return (op1 <= op2);
                        default:
                            return (op1 == op2);
                    }
                },
                MustChecked: function(name, min, max, require) {
                    var groups = document.getElementsByName(name);
                    if (require == "false") {
                        return true
                    }

                    var hasChecked = 0;
                    min = min || 1;
                    max = max || groups.length;
                    for (var i = groups.length - 1; i >= 0; i--)
                        if (groups[i].checked) hasChecked++;
                    return min <= hasChecked && hasChecked <= max;
                },
                //--add by liaojf(2004-4-4)
                MustSelected: function(name) {
                    var objselect = document.getElementsByName(name);
                    var getValue ;
                    try
                    {
                        getValue = objselect[0].options[objselect[0].selectedIndex].value;
                    }
                    catch(e5){}
                    var getIntValue = parseInt(getValue);

                    if (isNaN(getIntValue))
                        return false;
                    else {
                        if (getIntValue > 0)
                            return true;
                        else
                            return false;
                    }
                },
                DoFilter: function(input, filter) {
                    return new RegExp("^.+\.(?=EXT)(EXT)$".replace(/EXT/g, filter.split(/\s*,\s*/).join("|")), "gi").test(input);
                },
                IsIdCard: function(number) {
                    var date, Ai;
                    var verify = "10x98765432";
                    var Wi = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
                    var area = ['', '', '', '', '', '', '', '', '', '', '', '北京', '天津', '河北', '山西', '内蒙古', '', '', '', '', '', '辽宁', '吉林', '黑龙江', '', '', '', '', '', '', '', '上海', '江苏', '浙江', '安微', '福建', '江西', '山东', '', '', '', '河南', '湖北', '湖南', '广东', '广西', '海南', '', '', '', '重庆', '四川', '贵州', '云南', '西藏', '', '', '', '', '', '', '陕西', '甘肃', '青海', '宁夏', '新疆', '', '', '', '', '', '台湾', '', '', '', '', '', '', '', '', '', '香港', '澳门', '', '', '', '', '', '', '', '', '国外'];
                    var re = number.match(/^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[x\d])))$/i);
                    if (re == null) return false;
                    if (re[1] >= area.length || area[re[1]] == "") return false;
                    if (re[2].length == 12) {
                        Ai = number.substr(0, 17);
                        date = [re[9], re[10], re[11]].join("-");
                    }
                    else {
                        Ai = number.substr(0, 6) + "19" + number.substr(6);
                        date = ["19" + re[4], re[5], re[6]].join("-");
                    }

                    if (!this.IsDate(date, getAttribute('format'))) return false;
                    var sum = 0;
                    for (var i = 0; i <= 16; i++) {
                        sum += Ai.charAt(i) * Wi[i];
                    }
                    Ai += verify.charAt(sum % 11);
                    return (number.length == 15 || number.length == 18 && number == Ai);
                },
                IsMilIDCard : function(number){	//军官证 空字第00000000号 南字第123456 等格式
		            var date, Ai;
		            var re= number.match(/^[^x00-xff]{1-4}字第\d{6,8}号{0,1}$/i);
		            if (re == null)
			            return false;
		            else
			            return true;
	            },
                IsDate: function(op, formatString) {

                    //formatString = formatString || "ymd"||"xToday"||"dToday";
                    var m, year, month, day;
                    var today1;
                    meizzTheYear = new Date().getFullYear();
                    meizzTheMonth = new Date().getMonth() + 1;
                    today1 = new Date().getDate();
                    if (meizzTheMonth < 10) meizzTheMonth = "0" + meizzTheMonth
                    if (today1 < 10) today1 = "0" + today1
                    today2 = meizzTheYear + "-" + meizzTheMonth + "-" + today1;

                    switch (formatString) {
                        case "ymd":
                            m = op.match(new RegExp("^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$"));
                            if (m == null) return false;
                            day = m[6];
                            month = m[5] * 1;
                            year = (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10));
                            break;
                        case "dmy":
                            m = op.match(new RegExp("^(\\d{1,2})([-./])(\\d{1,2})\\2((\\d{4})|(\\d{2}))$"));
                            if (m == null) return false;
                            day = m[1];
                            month = m[3] * 1;
                            year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10));
                            break;
                        case "xToday":
                            var today = new Date();
                            if (op == null || op == "") return false;

                            if (op <= today2) {
                                // alert("正确")
                                return true;
                            }
                            break;

                        case "dToday":   //大于 		 
                            if (op == null || op == "") return false;
                            if (op >= today2) {
                                // alert("正确")
                                return true;
                            }
                            break;
                        default:
                            break;
                    }

                    if (!parseInt(month)) return false;
                    month = month == 0 ? 12 : month;
                    var date = new Date(year, month - 1, day);
                    return (typeof (date) == "object" && year == date.getFullYear() && month == (date.getMonth() + 1) && day == date.getDate());
                    function GetFullYear(y) { return ((y < 30 ? "20" : "19") + y) | 0; }
                }
            }

 ///---------------------------------------------------form end
 //用于,已添加了验证类型,但当他为空的时候不需要验证 add by wxg 20081204
 function AllowNull(IdValue)
 {
    if(document.getElementById(IdValue).value=="" ||  document.getElementById(IdValue).value==undefined)
    {
        document.getElementById(IdValue).setAttribute("require","false");
    }
 }
 
 
 
 ///------------------------------------------通用弹出窗口
 
 

	                
function PublicSelectSelectList(ID,Name,PathName,AspxName)
{   var undefined	//undefined    newdialoguewin!=null &
	
    //alert(AspxName.indexOf(".aspx?"));
    if(AspxName.indexOf(".aspx?") == -1)//updat wxg 2008-05-28 完成能传参数
    {
        var url=encodeURI(PathName+AspxName+"?SelID="+ID+"&Name="+Name) // alter by lsd 2008.06.6 处理中文参数乱码
	    var newdialoguewin = window.showModalDialog(url,window,"dialogWidth:800px;DialogHeight=600px;status:yes");
    }
    else
    {   
        var url=encodeURI(PathName+AspxName+"&SelID="+ID+"&Name="+Name)       
	    var newdialoguewin = window.showModalDialog(url,window,"dialogWidth:800px;DialogHeight=600px;status:yes");

    }
     
    if(newdialoguewin==undefined){
      
     return "||"
    }
    else
    {
    if(newdialoguewin.length>1)
	     {  
    	 
       return newdialoguewin;
	     }
	    }
}
		 
			 
 ///-----------------------------------------
        
 //返回到前一页 history.back()     
 
 
 function WebVlaue(WebObject,ObjectValue)//名字值
 { 
   var  Content=eval("document.all."+WebObject); 
   if(Content==undefined){return;}
    Content.value=ObjectValue; 
 }   
       
 function UpFileHtml(FilePath,TypeCode,ReValue,ReValueTrue,height,width,view)//  路径 类型编码  
 { var FormReValue=eval("document.all."+ReValue);
  // alert(document.all.ReobjValue.value)
  if (view!=0){
 // document.write(" <fieldset><legend>附件</legend>"); 
  document.write("<div>"); };
 // document.write(" <table border=0 width=\"100%\"><tr><td></td></tr></table><table border=0 width=\"100%\"><tr><td>")
   //document.write("<table border=0 width=\"100%\"><tr><td>");
  document.write("<IFRAME id=IFUpFile name=IFUpFile  src="+FilePath+"UploadFile.aspx?EditValue="+FormReValue.value+"&ReValueTrue="+ReValueTrue+"&ReValue="+ReValue+" frameBorder=0 width="+width+" scrolling=no height="+height+" runat=server></IFRAME> ");
 // document.write(" </td></tr></table>");
  
 if (view!=0){  
  document.write("</div>"); 
 //document.write("</fieldset>");
 }
 }  
 //新增20070712
  function UpFileHtmlInfoType(FilePath,TypeCode,ReValue,ReValueTrue,height,width,view)//  路径 类型编码  
 { var FormReValue=eval("document.all."+ReValue);
   if (view!=0){
   document.write("<div>"); };
   document.write("<IFRAME id=IFUpFile name=IFUpFile  src="+FilePath+"UploadFile.aspx?UserSet=1&EditValue="+FormReValue.value+"&ReValueTrue="+ReValueTrue+"&ReValue="+ReValue+" frameBorder=0 width="+width+" scrolling=no height="+height+" runat=server></IFRAME> ");
   if (view!=0){  
  document.write("</div>"); 
  }
 }  
 
 
 //对应代码
 
 
 function PrintCode(){
  	if(typeof(window.opener) != 'undefined')
 		PrintCode1();
 	else
 	    document.write("<div  align=center ><input type=button   class='ButtonCss' value='打 印 '  onclick=\"window.open('../../Print/Print.htm','popUpWin', 'toolbar=no,location=no, directories=no,status=no,menubar=no,scrollbar=yes,resizable=yes,width=800,height=600')\"> <input  class='ButtonCss' type=button  value='返 回'  onclick=\"history.go(-1)\"> </div>")
 
 }
 
 
  function PrintCode1(){
      document.write("<div  align=center ><input type=button   class='ButtonCss' value='打 印 '  onclick=\"window.open('../Print/Print.htm','popUpWin', 'toolbar=no,location=no, directories=no,status=no,menubar=no,scrollbar=yes,resizable=yes,width=800,height=600')\"> <input  class='ButtonCss' type=button  value='关 闭'  onclick=\"window.close()\"> </div>")
 
 }
 
 function hideView(id)
 {var id
    
    //功能 隐藏 显示 仅是日常检查中使用 不通用 
    
   var  ClassThis = document.getElementById("Class"+id);
   var Class_ContentThis=eval("Class_Content"+id);   
    if (ClassThis.innerText=="+")
   {//那么显示检查内容
 
    for(var i=0;i<Class_ContentThis.length;i++)
      {//
          Class_ContentThis[i].style.display="block";    
         // alert()    
      }
        ClassThis.innerText="-";
   }
   else
     {
   //隐藏检查内容
    for(var i=0;i<Class_ContentThis.length;i++)
      {//
          Class_ContentThis[i].style.display="none";
      }
      ClassThis.innerText="+";
     }
 }
 
var old_menu = '';
function Show( divnum ) 
{
var obj = eval(divnum+".style");
if( old_menu != divnum) { 

  if( old_menu !='' ) {
   eval(old_menu+".style").display = "none";
  } 

  obj.display = "block";
  old_menu = divnum; 

} else { 

  obj.display = "none";
  old_menu = '';
}
}
 
 //处理选择题中如果是需要填入到 问题区域值 
 
 
function  ContentInfo_Value(ContentInfoID,Id,Class_Next_id,ClassIDValue_txt_obj_value){
//ContentInfoID 内容的ID 号   ID－－处理方式  1 是增加 0 是取消 
//innerText   
//ContentInfoValue_1  内容项   ContentInfoValue_2 依据项 
//Class_Next_id 是某一类下的序号 
 
var  ContentInfoValueHtmlText1 = document.getElementById("ContentInfoValue_1"+ContentInfoID).innerText;
var  ContentInfoValueHtmlText2 = document.getElementById("ContentInfoValue_2"+ContentInfoID).innerText;
var  AllContentInfoValueHtml="\n"+ContentInfoValueHtmlText1+"--"+ContentInfoValueHtmlText2
//var  AllContentInfoValueHtml1=ContentInfoValueHtmlText1+"--"+ContentInfoValueHtmlText2
 
if(Id=="1")/////////////////////////////
{//将源来的增加
//将内容放到 理由中 

////////////////////////////////////////////////////////////////////////////修改4-29

//ClassIDValue
 

 //var aaww="document.eForm1.mcMemo"+ClassIDValue_txt_obj_value
var  ObjTxtcMemo1 = eval("document.eForm1.mcMemo"+ClassIDValue_txt_obj_value); 
 
for(h=0;h<=ObjTxtcMemo1.length;h++)
{
if (ObjTxtcMemo1.length==0)
{ 
   ObjTxtcMemo1.value=ContentInfoValueHtmlText1
}
else
{
if (h==Class_Next_id){ObjTxtcMemo1[h].value=ContentInfoValueHtmlText1}//将数据添加的理由中
}

}
 
//ObjTxtcMemo1.value=AllContentInfoValueHtml
var  ObjTxtcMemo=document.getElementById("TxtcMemo")
//检查是否存在
  var str;
 str=ObjTxtcMemo.value;
 
 var pos = str.indexOf(AllContentInfoValueHtml)
    if (pos=-1)
    { 
     ObjTxtcMemo.value=ObjTxtcMemo.value.replace(/\r\n/g,'')+AllContentInfoValueHtml
     }
     //.replace(/\r\n/g,'')
    }
if(Id==0)
{//移除源来的
//alert();
var  ObjTxtcMemo=document.getElementById("TxtcMemo")
if (ObjTxtcMemo.value==""){ObjTxtcMemo.value=""}
 ObjTxtcMemo.value=ObjTxtcMemo.value.replace(AllContentInfoValueHtml,'')//.replace(/\r\n/g,'')
}
 
 //取消理由的内容
 
 var  ObjTxtcMemo1 = eval("document.eForm1.mcMemo"+ClassIDValue_txt_obj_value); 
 
for(h=0;h<=ObjTxtcMemo1.length;h++)
{
if (ObjTxtcMemo1.length==0)
{ 
   ObjTxtcMemo1.value=""
}
else
{
if (h==Class_Next_id){ObjTxtcMemo1[h].value=""}//将数据添加的理由中
}

}

}
 
//kstatus();
//function kstatus(){
//self.status="易盛FDAMIS";
//setTimeout("kstatus()",0);
//}
 

function check(e)
{
	var k = window.event.keyCode;
	if (k < 48 || k > 57){
		alert("你输入的不是数字！")
		window.event.keyCode = 0 ;}
		else
		{
		//alert("你输入数字！")
		}
}
function onblurCheck()
{
  
  var  ClassIDValueThis = eval("document.eForm1.ClassIDValue");
  //取的该ClassIDValue 的数量
 var mcAccountValue_ClassThisV_alue
  if (ClassIDValueThis.length!=undefined)
 {
       for(var v=0;v<=ClassIDValueThis.length-1;v++)
         {  
      var ClassThisV_alue
      if (ClassIDValueThis.length==0){      
          ClassThisV_alue=eForm1.ClassIDValue.value;    
         }
         else
         {
          ClassThisV_alue=ClassIDValueThis[v].value;//取的值
          }
          
          Z_heji(ClassThisV_alue)
      }
 }
  else
 {
 
 Z_heji(ClassIDValueThis.value)
 
 }

}


//合计

function Z_heji(ClassThisV_alue)
{

       var  ClassIDValueThis1 = eval("document.eForm1.mcAccountValue"+ClassThisV_alue);
            eForm1.AccountValueAll.value=0;
           if (ClassIDValueThis1.length!=undefined){
            for(var n=0;n<=ClassIDValueThis1.length-1;n++)
            {  
               if (ClassIDValueThis1.length==0)
                  { //主要考虑到一个文件
                  if(ClassIDValueThis1.value!="")
                  {
                  eForm1.AccountValueAll=ClassIDValueThis1.value 
                  }
                 
                  }
                 else
                 {//合计开始 需要考虑空的情况 
                  
                    if (ClassIDValueThis1[n].value!="")
                         {
                         var tmpVal=parseInt(ClassIDValueThis1[n].value);
			            sumcell= isNaN(tmpVal)?0:tmpVal;
                        eForm1.AccountValueAll.value=parseInt(eForm1.AccountValueAll.value)+sumcell
                      }             
                 }
            
            }
            }
            else
            {eForm1.AccountValueAll.value=ClassIDValueThis1.value}
}

//
document.write("<base onmouseover=\"window.status='网新易盛';return true\"> ")


//ScriptViewAt(); 显示附件

function ScriptViewAt(FilePath,ViewmcOperationID)
{  
 // document.write("<TR id=ViewAt_tr ><TD colSpan=\"2\" id=ViewAt></TD></TR>")
  document.write("<div id=ViewAt></div>");
  document.write(" <IFRAME  src="+FilePath+"Public/UploadFileList.aspx?FilePath="+FilePath+"&ViewmcOperationID="+ViewmcOperationID+" frameBorder=0 width=0 height=0 runat=server></IFRAME> ")


}

function NewScriptViewAt(FilePath,ViewmcOperationID,DivId)
{ 
 // document.write("<TR id=ViewAt_tr ><TD colSpan=\"2\" id=ViewAt></TD></TR>")
  document.write("<div id=ViewAt></div>");
  document.write(" <IFRAME  src="+FilePath+"Public/UploadFileList.aspx?DIVid="+DivId+"&FilePath="+FilePath+"&ViewmcOperationID="+ViewmcOperationID+" frameBorder=0 width=0 height=0 runat=server></IFRAME> ")


}

//ScriptViewAt(); 显示附件
/*
function ScriptViewAt(UrlPath,FilePath,ViewmcOperationID)
{  
  //document.write("<TR id=ViewAt_tr ><TD colSpan=\"2\" id=ViewAt></TD></TR>")
  document.write("<div id=ViewAt></div>");
 document.write(" <IFRAME  src="+UrlPath+"Public/UploadFileList.aspx?FilePath="+UrlPath+"&ViewmcOperationID="+ViewmcOperationID+"  frameBorder=0 width=0 height=0 runat=server></IFRAME> ");


}
*/
//ScriptViewAt(); 显示附件

function ScriptViewAtNew(FilePath,ViewmcOperationID)
{ 
  document.write("<div id=ViewAt></div>");
  document.write(" <IFRAME  src="+FilePath+"Public/UploadFileList.aspx?FilePath="+FilePath+"&ViewmcOperationID="+ViewmcOperationID+" frameBorder=0 width=0 height=0 runat=server></IFRAME> ")
}

////显示意见框 
//function ScriptViewAtIdea(FilePath,ControlName,InfoType)
//{ 
//  document.write("<div id='DivIdea'></div>");
//  document.write(" <IFRAME  src="+FilePath+"Public/UserSetIdea.aspx?ControlName="+ControlName+"&InfoType="+InfoType+" width=0 height=0 frameBorder=0></IFRAME> ")
//}

//function SetIdea(sourceCtrl, targetCtrl) {
//    var ddl = document.getElementById(sourceCtrl);
//    var obj = document.getElementById(targetCtrl);
//    for (var i = 0; i < ddl.options.length; i++)
//        if (ddl.options[i].selected && ddl.options[i].value != '')
//        obj.value += ddl.options[i].text;
//}

//ByTypelist(); 显示经营范围
function ByTypeList(FilePath,id)
{ 
  document.write("<span id=ByTypeListHtml ></span>") 
  document.write(" <IFRAME src="+FilePath+"Enterprise/ByTypeList.aspx?ID="+id+" frameBorder=0 width=0 height=0 runat=server></IFRAME> ")
  

}
function
FlowDefault(FilePath,id,TypeID)
{
  //这里处理　隐藏　审批的  
 //SelUserName显示选择的信息   SelUserNameId 选择的ＩＤ　的内容  id=XZLC
 // //路径　，　流程编号　，　是否启用选择0 不选择 1 可以带流程选择 2 同时存在选择	
 if (TypeID=="0")
 { 
  document.write("<input name='NodeType_Value' TYPE=text value="+id+" class=hide >")
  document.write("<span id=ByTypeListHtml_Flow_view ></span><br><span id=ByTypeListHtml_Flow ></span>  ")
  document.write(" <IFRAME  src="+FilePath+"Public/DefaultFlow.aspx?ID="+id+"&TypeID="+TypeID+"  frameBorder=0 width=0 height=0 runat=server NAME=FL></IFRAME> ")

 document.getElementById("XZLC").className="hide";	
 
 //document.getElementById("SelUserNameTxt").className="hide";	
 }
 
if (TypeID=="1")
 { //提供自定义
 document.getElementById("XZLC").className="hand";	
 
 document.getElementById("SelUserNameTxt").className="InputCss";	
 }
 
 if (TypeID=="2")//是同时存在
 { 
  document.write("<br><span id=ByTypeListHtml_Flow ></span>（你可以选择默认流程）")
  document.write(" <IFRAME  src="+FilePath+"Public/DefaultFlow.aspx?ID="+id+"&TypeID="+TypeID+"   frameBorder=0 width=0 height=0 runat=server NAME=FL></IFRAME> ")
  document.getElementById("XZLC").className="hand"; 
  document.getElementById("SelUserNameTxt").className="InputCss";	
 
 }
 
}
 
 
  function FViewDeal(id)
  {
 
  var  ObjTxtHis = eval("History"+id); 
 
     if (ObjTxtHis.style.display=="none")
        {
               ObjTxtHis.style.display="block";
               document.getElementById("History_Content_img").innerHTML="<img src='../images/minus.gif' class=hand title='收起处理意见' >";
        }
        else
        {
			   ObjTxtHis.style.display="none";
			   document.getElementById("History_Content_img").innerHTML="<img src='../images/plus.gif' class=hand title='浏览处理意见' >"
    
       } 
 
} 


function FViewDealPublicWrite(id)
  {
 
  var  ObjTxtHis = eval("History"+id); 
 
     if (ObjTxtHis.style.display=="none")
        {
               ObjTxtHis.style.display="block";
               document.getElementById("History_Content_img").innerHTML="<img src='../../images/dock.gif' class=hand title='正在提醒设置' >";
        }
        else
        {
			   ObjTxtHis.style.display="none";
			   document.getElementById("History_Content_img").innerHTML="<img src='../../images/cal.gif' class=hand title='提醒设置' >"
    
       } 
 
} 


  function FViewDealPublic(id,Id1)
  {
 
  var  ObjTxtHis = eval(id); 
 
     if (ObjTxtHis.style.display=="none")
        {
               ObjTxtHis.style.display="block";
               document.getElementById(Id1).innerHTML="<img src='../images/minus.gif' class=hand title='收起处理意见' >";
        }
        else
        {
			   ObjTxtHis.style.display="none";
			   document.getElementById(Id1).innerHTML="<img src='../images/plus.gif' class=hand title='浏览处理意见' >"
    
       } 
 
} 
 



//结论类型
function CheckContentList(FilePath,id)
{ 

  document.write("<span id=CheckContentListHtml  ></span>") 
  document.write(" <IFRAME  src="+FilePath+"Public/CheckContentList.aspx?ID="+id+" frameBorder=0 width=0 height=0 runat=server></IFRAME> ")
  

}
//检查类型数据

function TodayCheckInfoList(FilePath)
{ 

  document.write("<span id=TodayCheckInfoListHtml  ></span>") 
  document.write(" <IFRAME  src="+FilePath+"Public/TodayCheckInfo.aspx frameBorder=0 width=0 height=0 runat=server></IFRAME> ")
}


//结论类型 文书每处理的输入框生成 cOperationID_temp 唯一的数据  id 0 表示在立案前的数据  1 是表示立案后的数据资料

 
function WritCaseInput(ID)
{ 
 
 //无刷新提取 组合好的HTML 脚本  

 var objstr=document.getElementById("DocBookMarkListId_7_9").value
 Go(objstr,ID)
}

function jbWrit()
        {
           var A=null; 
               try 
               { 
                   A=new ActiveXObject("Msxml2.XMLHTTP"); 
                } 
           catch(e)
           { 
                  try 
                   { 
                      A=new ActiveXObject("Microsoft.XMLHTTP"); 
                   }
           catch(oc)
          { 
                     A=null 
                   } 
              } 
           if ( !A && typeof XMLHttpRequest != "undefined" ) 
            { 
               A=new XMLHttpRequest() 
             } 
           return A 
        }
        
        //下面Go函数是父列表框改变的时候调用，参数是选择的条目
        var Id;
        function Go(objstr,ID)
        { 
           //得到选择框的下拉列表的value
        //  var svalue = obj.value;
          //cOperationID
           //定义要处理数据的页面
         
           svalue=document.getElementById("cMainOperationID").value;
           
         //+svalue+"&BookMarkStr="+objstr
          var weburl = "WebFormWrit.aspx?ID="+ID+"&cMainOperationID="+svalue+"&BookMarkStr="+objstr;
           //初始化个xmlhttp对象
           // alert(weburl)
          //  return;
           var xmlhttp = jbWrit();
           //提交数据，第一个参数最好为get，第三个参数最好为true
           xmlhttp.open("get",weburl,true);
         //  alert(xmlhttp.responseText);
           //如果已经成功的返回了数据
           xmlhttp.onreadystatechange=function()
           { 
             if(xmlhttp.readyState==4)//4代表成功返回数据
              {
                 var result = xmlhttp.responseText;//得到服务器返回的数据
                 //先清空dListChild的所有下拉项
               //  alert(result)
                 if(result!="")//如果返回的数据不是空
                 {
                //  alert()
                
                   document.getElementById("inputAreaWrit").innerHTML=result;
                   
                   //将已有的数据填入到对应内容中
                   JsDocBookmarksSet();
                 }
               }
           }
           //发送数据，请注意顺序和参数，参数一定为null或者""
           xmlhttp.send(null);
        }
//转换Input 到area IptTxt
function IptTxt(IptTxtName)
{
 
//取的该名称的值
var str_temp=document.getElementById(IptTxtName).value;
document.getElementById(IptTxtName+"_td").innerHTML="<input id=\""+IptTxtName+"\" Name=\""+IptTxtName+"\"  onblur=\"SetBookmarks('"+IptTxtName+"',this.value);\"   Style=\"width:60%\"  value=\""+str_temp+"\"    > ";//

}

function IptArea(IptTxtName)
{
var str_temp=document.getElementById(IptTxtName).value;
document.getElementById(IptTxtName+"_td").innerHTML="<textarea id=\""+IptTxtName+"\"  Name=\""+IptTxtName+"\"  onblur=\"SetBookmarks('"+IptTxtName+"',this.value);\"   Style=\"width:90%;height:100\"    >"+str_temp+"</textarea>";//

}



function JsDocBookmarksSet()
{  
 
var dd= document.getElementById('DocBookMarkListId_7_9').value.split('№')
 
  var mBookmarkName,mBookmarValue;
  //获取标签总数
   for (var i = 0;i < dd.length-1;i++){
     mBookmarkName = dd[i];         //获取标签名称
      //获取标签值   
     if (document.getElementById(mBookmarkName))
     {
        if (document.getElementById(mBookmarkName).value!="")
           {        
           SetBookmarks(mBookmarkName,document.getElementById(mBookmarkName).value)  
    
           }   
     }
    
  }
  }
  
 ///格式化 年月日时分  2005-7-22  2005年 7月22是
function formattime(str)
{
 
var arraystr,arraydate,arraystrtime,formattime;
arraystr=str.split(" ");
arraydate=arraystr[0].split("-");
arraytime=arraystr[1].split(":");
formattime= arraydate[0] + "年 " + arraydate[1] + "月 " + arraydate[2] + "日 " +  arraytime[0] + "时 " +  

arraytime[1] + "分 ";
return(formattime);
}

function toCHS(s){return s.constructor!=Number?s.constructor!=String?s.constructor!=Date?null:toCHS(s.getFullYear()+"")

+"年 "+toCHS(s.getMonth()+1)+"月 "+toCHS(s.getDate())+"日 "+toCHS(s.getHours())+"时 "+toCHS(s.getMinutes())+"分 "+toCHS

(s.getSeconds())+"秒 ":s.replace(/\d/g,function(a){return"零一二三四五六七八九".charAt(parseInt(a))}):toCHS(((s>19?Math.floor

(s/10):"")+(s>9?("十"):"")+(s%10==0&&s>0?"":s%10)))}

function toCHS1(s){return s.constructor!=Number?s.constructor!=String?s.constructor!=Date?null:toCHS(s.getFullYear()+"")

+" 年"+toCHS(s.getMonth()+1)+" 月"+toCHS(s.getDate())+" 日"+toCHS(s.getHours())+" 时"+toCHS(s.getMinutes())+" 分":s.replace(/\d/g,function(a){return"零一二三四五六七八九".charAt(parseInt(a))}):toCHS(((s>19?Math.floor

(s/10):"")+(s>9?("十"):"")+(s%10==0&&s>0?"":s%10)))}

//  showToCnDate("2005-10-09 11:20")  二零零五十月九日****8*
function showToCnDate(str)
{
var arraystr,arraydate,arraystrtime,formattime;
arraystr=str.split(" ");
arraydate=arraystr[0].split("-");
arraytime=arraystr[1].split(":");

return toCHS(new Date(arraydate[0],arraydate[1],arraydate[2],arraytime[0],arraytime[1]))
}


 /*
  功能:YYYY-MM-DD 数字日期转化为汉字
  例:1984-3-7 -> 一九八四年三月七日
  调用:baodate2chinese("1984-3-7") 
  */
  var chinese = ['0','1','2','3','4','5','6','7','8','9'];
  var len = ['1'];
  var ydm =['年','月','日'];
  function num2chinese(s)
  {

   //将单个数字转成中文.
    s=""+s;
    slen = s.length;
    var result="";
    for(var i=0;i<slen;i++)
    {
        result+=chinese[s.charAt(i)];
    }
     return result;
  }

  function n2c(s)
  { 
    //对特殊情况进行处理.
    s=""+s;
    var result="";
    if(s.length==2)
    {
         if(s.charAt(0)=="1")
         {
            if(s.charAt(1)=="0")return len[0];
            return len[0]+chinese[s.charAt(1)];
          }
     if(s.charAt(1)=="0")return chinese[s.charAt(0)]+len[0];
        return chinese[s.charAt(0)]+len[0]+chinese[s.charAt(1)];
     }
     return num2chinese(s)
  }
  function baodate2chinese1(s)
  {
     //验证输入的日期格式.并提取相关数字.
     var datePat = /^(\d{2}|\d{4})(\/|-)(\d{1,2})(\2)(\d{1,2})$/; 
     var matchArray = s.match(datePat); 
     var ok="";
     if (matchArray == null) return false;
     for(var i=1;i<matchArray.length;i=i+2)
     {
         ok+=n2c(matchArray[i]-0)+ydm[(i-1)/2];
     }
   return ok;
  }

function baodate2chinese(str)
{
if (str.length>0){
var dateArray=str.split("-");
return dateArray[0]+"年"+dateArray[1]+"月"+dateArray[2]+"日";
}
else{
   alert("印发时间不能为空!");
   return false;}
}

 
 
 
//HideViewContent 具体的ID名称  要显示的类型 
function HideViewContent(Name,Name1,ImagesContent)
  {
 
  var  ObjTxtHis = eval(Name); 
 
     if (ObjTxtHis.style.display=="none")
        {
               ObjTxtHis.style.display="block";
               
        }
        else
        {
			   ObjTxtHis.style.display="none";
			 
       } 
 
} 
 
 function Table_TD_Hide(Name)
  {
 
  var  ObjTxtHis = eval(document.getElementById(Name)); 
 
     if (ObjTxtHis.style.display=="none")
        {
               ObjTxtHis.style.display="block";
               
        }
        else
        {
			   ObjTxtHis.style.display="none";
			 
       } 
 
} 
 
 
		function  checkboxSpCheck_(eFormName,ContentName,checkboxName)
		{ 
		 
		    var  eFormName_ = eval(document.getElementById(eFormName)); 
		    var  checkboxName_ = eval(document.getElementById(checkboxName)); 
			if (checkboxName_.checked==true)
			{ 
				HideViewContent(ContentName,'0','0');				 
				eFormName_.setAttribute("require","true"); 
 
			}
			else
			{   HideViewContent(ContentName,'1','')
				eFormName_.setAttribute("require","false") 
			}
		} 
 
 function NewUrlhref(Url,Value)
 {
  location.href=Url+Value;
 }
 
  function GetPeriod(inObjName)
{
    var strURL = AbsPath + "TimePeriod.aspx";
    var strStyle="dialogWidth=168pt;dialogHeight=190pt;status:no;help:no;scrollbars:no";
    var AryDate = window.showModalDialog(strURL,'',strStyle);
	if(AryDate.length==7)	document.all(inObjName).value=AryDate[0];
}

//打开全屏 wxg
function fullWinOpen(url)
{
	var targeturl=url
	newwin=window.open("","","")
	if (document.all)
	{
		newwin.moveTo(0,0)
		newwin.resizeTo(screen.width,screen.height)
	}
	newwin.location=targeturl
}

//打开／收缩 add by wxg
var expandedImgPath = '../images/Icon_Open.gif';
var contractedImgPath = '../Images/Icon_Close.gif';

function shrink(idName,imgTag)
{
   var trTag = document.getElementById(idName);
   var img = document.getElementById(imgTag);
   //alert(trTag.style.display);
   if(trTag.style.display == 'none')
   {
        trTag.style.display = 'block';
        img.src = expandedImgPath;
   }
   else
   {
		trTag.style.display = 'none';
		img.src = contractedImgPath;
   }
}

function shrink2(idName,imgTag,imgUrl)
{
    expandedImgPath = imgUrl + '../images/Icon_Open.gif';
    contractedImgPath = imgUrl + '../Images/Icon_Close.gif';
    
    //alert(expandedImgPath);
    shrink(idName,imgTag);
}

//关闭本窗口，刷新父窗口
function CloseAndRefreshParentWindow()
{
     window.opener.location.reload();
    window.close();
}

//显示加载条 add by wxg 080806
function showProcess()  
{  
     GetMsg();
} 
var timerId=null;
function GetMsg()
{
    var msg = document.getElementById("divShowLoading");
    msg.style.left = (document.body.clientWidth - 220) / 2;
    msg.style.top = window.screen.height / 3 - 120;
    if(window.document.readyState != null && window.document.readyState != 'complete')
    {
        msg.style.display = "block";
    }    
    else
    {
        msg.style.display = "none";
        window.clearTimeout(timerId);
        return;
    }
    timerId=window.setTimeout('GetMsg()',1000);
}

//打开非模态对话框,显示在屏幕中间的位置 add by wxg 20081010
function OpenWinCentre(url,height,width)
{
	var iTop = (window.screen.availHeight-height)/2;       //获得窗口的垂直位置;
	var iLeft = (window.screen.availWidth-width)/2;           //获得窗口的水平位置;
	window.open(url,"", "top="+iTop+",left="+iLeft+",toolbar=no,location=no, directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width="+width+",height="+height)
}


//选择人员 add by wxg 20081117
function person(obj,GoUrl)
{
	var strName,strCardID,strPosition,strWorkYear;
	
	if(obj == 1)
	{
		strName = $("#itCorporation").val(); //document.getElementById("itCorporation").value;
		strCardID = $("#itCorporationID").val();//document.getElementById("itCorporationID").value;
	}
	else if(obj == 2)
	{
		strName = document.getElementById("itDirector").value;
		strCardID = document.getElementById("itDirectorID").value;
	}
	else if(obj == 3)
	{
		strName = document.getElementById("itQualityDirector").value;
		strCardID = document.getElementById("itQualityDirectorID").value;
	}
	else if(obj == 4)
	{
		strName = document.getElementById("itQualityController").value;
		strCardID = document.getElementById("itQualityControllerID").value;
    }
    else if(obj == 13)
	{
	        strName = document.getElementById("itPharmacist").value;
	        strCardID = document.getElementById("itPharmacistID").value;
    }
    else if (obj == 20) {
        strName = document.getElementById("itPharmacistFilinged").value;
        strCardID = document.getElementById("itPharmacistFilingedID").value;
    }    
    else if (obj == 26) {
        strName = document.getElementById("itQualityOrgDirector").value;
        strCardID = document.getElementById("itQualityOrgDirectorID").value;
    }
    else if (obj == 27) {
        strName = document.getElementById("itPharmacyTechnician").value;
        strCardID = document.getElementById("itPharmacyTechnicianID").value;
    }
	else if(obj == 25)
	{
	   // alert(obj);
	}
	else if(obj > 4 && obj != 25 && obj != 20 && obj != 26 && obj != 27)
	{
	    //alert("有时候缺少对象"+obj);
		strName = document.getElementById("itPNameList"+obj).value;
		strCardID = document.getElementById("itIDCardList" + obj).value;
    }	
	if(strName != undefined && strName != "")
	{
		GoUrl += "&PName="+escape(strName);
	}
	if(strCardID != undefined && strCardID != "")
	{
		GoUrl += "&cIDCard="+strCardID;
    }

    //新增一个包含选中岗位的参数一般判断是否为驻店药师岗位  shizy 20090825
    var objJobList = document.getElementById("JobList" + obj);
    if (objJobList != undefined) {
        strExtJobList = document.getElementById("JobList" + obj).value;
        if (strExtJobList != undefined && strExtJobList != "") {
            GoUrl += "&ExtJobList=" + escape(strExtJobList);
        }
    }
	if(obj > 0)
	{
		GoUrl += "&jobType="+obj;
	}
	
	OpenWinCentre(GoUrl,700,800);
}


//选择人员 将原来的质量管理人员验证改成驻店药师 shizy 20090806
function personForResidentPharmacist(obj, GoUrl) {
    var strName, strCardID, strPosition, strWorkYear;

    if (obj == 1) {
        strName = $("#itCorporation").val(); //document.getElementById("itCorporation").value;
        strCardID = $("#itCorporationID").val(); //document.getElementById("itCorporationID").value;
    }
    else if (obj == 2) {
        strName = document.getElementById("itDirector").value;
        strCardID = document.getElementById("itDirectorID").value;
    }
    else if (obj == 3) {
        strName = document.getElementById("itQualityDirector").value;
        strCardID = document.getElementById("itQualityDirectorID").value;
    }
    else if (obj == 4) {
        strName = document.getElementById("itResidentPharmacists").value;
        strCardID = document.getElementById("itResidentPharmacistsID").value;
    }
    else if (obj == 25) {
        // alert(obj);
    }
    else if (obj > 4 && obj != 25) {
        strName = document.getElementById("itPNameList" + obj).value;
        strCardID = document.getElementById("itIDCardList" + obj).value;
    }

    if (strName != undefined && strName != "") {
        GoUrl += "&PName=" + escape(strName);
    }
    if (strCardID != undefined && strCardID != "") {
        GoUrl += "&cIDCard=" + strCardID;
    }
    if (obj > 0) {
        GoUrl += "&jobType=" + obj;
    }

    OpenWinCentre(GoUrl, 700, 800);
}

