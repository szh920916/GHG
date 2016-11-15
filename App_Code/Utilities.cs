//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd .
//------------------------------------------------------------

using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

using DotNet.DbUtilities;
using DotNet.Service;
using DotNet.Utilities;
using DotNet.Manager;
using DotNet.Model;

using System.Data.SqlClient;

public class Utilities
{
    public static string BusinessDbConnection = ConfigurationManager.AppSettings["BusinessDbConnection"];
    public static string UserCenterDbConnection = ConfigurationManager.AppSettings["UserCenterDbConnection"];

    //如果report中数值为0或为空时默认写入值，默认值为null
    public static double? ReportDefaultValueIfEmpty = null;

    public static string UploadFiles = "UploadFiles";                        // 上传文件的路径定义
    public static bool ShowInformation = true;                               // 是否显示提示信息
    public static string LangSaveConfirm = " You confirm must preserve? ";	// 您确认要保存吗
    public static string LangDeleteConfirm = " You confirm must delete? ";	    // 您确认要删除吗
    public static string LangConfirm = " Please careful checkup data! The confirmation input is correct? "; // 请仔细核对数据，确认输入的正确吗？

    public static string CompanyFullName = string.Empty;   // 公司名称   
    public static string SoftFullName = string.Empty;   // 软件名称  
    public static string Version = string.Empty;   // 版本号
    public static string IEDownloadUrl = string.Empty;   // IE下载地址
    public static string Designed = string.Empty;   // 设计者
    public static string Update = string.Empty;   // 更新

    public static string DefaultPage = @"Default.aspx";    // 默认页面
    public static string NotFindPage = @"Default.aspx";    // 内容未找到页面
    public static string UserNotLogin = @"Login.aspx";  // 用户未登录页面
    public static string AccessDenyPage = @"~/Modules/Common/System/AccessDeny.aspx";  // 访问没有权限被拒绝页面
    public static string UserIsNotAdminPage = @"~/Modules/Common/System/AccessDeny.aspx";    // 当前操作员不是系统管理员页面

    public static string ServiceMailBox = "ZhengzhouRising@126.com";  // 服务邮箱
    public static string ServiceMailBoxDisplayname = "ZhengzhouRising@126.com";  // 服务邮箱显示名称
    public static string ServiceMailBoxPassword = "Rising";  // 服务邮箱密码
    public static string ServiceMailBoxSMTP = "SMTP.126.COM";  // SMTP地址
    public static int ServiceMailBoxSMTPPort = 25;  // SMTP地址

    public static Boolean IsSendBug = true;  // 是否发送bug到开发方
    public static string BugFeedbackMailBox = "ZhengzhouRising@126.com";  // bug发送地址

    protected bool SimpleManagerMode = true;            // 选择是简易管理模式，是否部门管理权限管理角色管理等页面很复杂？

    #region public static void GetConfiguration() 读取一些基本配置信息
    /// <summary>
    /// 读取一些基本配置信息
    /// </summary>
    public static void GetConfiguration()
    {
        try
        {
            // 获取一些显示信息
            Utilities.CompanyFullName = ConfigurationManager.AppSettings["CustomerCompanyName"];
            Utilities.SoftFullName = ConfigurationManager.AppSettings["SoftFullName"];
            Utilities.Version = ConfigurationManager.AppSettings["Version"];
            Utilities.IEDownloadUrl = ConfigurationManager.AppSettings["IEDownloadUrl"];
            Utilities.Designed = ConfigurationManager.AppSettings["Designed"];
            Utilities.Update = ConfigurationManager.AppSettings["Update"];


            Utilities.ServiceMailBox = ConfigurationManager.AppSettings["ServiceMailBox"];  // 服务邮箱
            Utilities.ServiceMailBoxDisplayname = ConfigurationManager.AppSettings["ServiceMailBoxDisplayname"];  // 服务邮箱显示名称
            Utilities.ServiceMailBoxPassword = ConfigurationManager.AppSettings["ServiceMailBoxPassword"];  // 服务邮箱密码

            Utilities.ServiceMailBoxSMTP = ConfigurationManager.AppSettings["ServiceMailBoxSMTP"];  // SMTP地址
            Utilities.ServiceMailBoxSMTPPort = int.Parse(ConfigurationManager.AppSettings["ServiceMailBoxSMTPPort"]);  // SMTP地址

            Utilities.IsSendBug = ConfigurationManager.AppSettings["IsSendBug"].ToLower().Equals("true");  // 是否发送bug到开发方
            Utilities.BugFeedbackMailBox = ConfigurationManager.AppSettings["BugFeedbackMailBox"];  // bug发送地址
        }
        catch 
        {
        }
    }
    #endregion

    #region public static bool SetDropDownListValue(DropDownList dropDownList, string selectedValue)
    /// <summary>
    /// 设置下拉框的被选中值
    /// </summary>
    /// <param name="dropDownList">下拉框</param>
    /// <param name="selectedValue">被选中的值</param>
    /// <returns>是否找到</returns>
    public static bool SetDropDownListValue(DropDownList dropDownList, string selectedValue)
    {
        bool returnValue = false;
        if (dropDownList.SelectedItem != null)
        {
            dropDownList.SelectedItem.Selected = false;
        }
        // 按值找
        ListItem listItem = dropDownList.Items.FindByValue(selectedValue);
        if (listItem == null)
        {
            // 按显示的文本找
            for (int i = 0; i < dropDownList.Items.Count; i++)
            {
                if (dropDownList.Items[i].Text.Equals(selectedValue))
                {
                    dropDownList.Items[i].Selected = true;
                    returnValue = true;
                    break;
                }
            }
            // 还是没找到
            if (dropDownList.SelectedItem == null)
            {
                listItem = new ListItem(selectedValue, selectedValue);
                dropDownList.Items.Insert(0, listItem);
            }
        }
        else
        {
            // 设置为被选中状态
            listItem.Selected = true;
        }
        return returnValue;
    }
    #endregion

    #region private string GetSession(string session) 安全获取Session的值
    /// <summary>
    /// 安全获取Session的值
    /// </summary>
    /// <param name="session">变量名</param>
    /// <returns>字符串</returns>
    private string GetSession(string session)
    {
        string returnValue = string.Empty;
        if (HttpContext.Current.Session[session] != null)
        {
            returnValue = HttpContext.Current.Session[session].ToString();
        }
        return returnValue;
    }
    #endregion

    #region protected string CheckCodeImage 登录验证码读取
    /// <summary>
    /// 登录验证码读取
    /// </summary>
    protected string CheckCodeImage
    {
        get
        {
            return this.GetSession("LoginCheckCode");
        }
        set
        {
            HttpContext.Current.Session["LoginCheckCode"] = value;
        }
    }
    #endregion

    public static BaseUserInfo GetUserInfo()
    {
        BaseUserInfo userInfo = null;
        if (HttpContext.Current.Session != null)
        {
            if (HttpContext.Current.Session["UserInfo"] != null)
            {
                userInfo = (BaseUserInfo)HttpContext.Current.Session["UserInfo"];
            }
            if (userInfo == null)
            {
                // 从 Session 读取 当前操作员信息
                if (HttpContext.Current.Session["UserInfo"] == null)
                {
                    userInfo = new BaseUserInfo();
                    // 获得IP 地址
                    //userInfo.Id = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    userInfo.RealName = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    userInfo.UserName = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    userInfo.IPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // 设置操作员类型，防止出现错误，因为不小心变成系统管理员就不好了
                    // if (String.IsNullOrEmpty(userInfo.RoleId))
                    // {
                    //     userInfo.RoleId = DefaultRole.User.ToString();
                    // }
                }
            }
        }
        return userInfo;
    }

    //
    // 当前操作员权限相关检查函数
    //

    #region public static bool UserIsLogin() 判断用户是否已登录
    /// <summary>
    /// 判断用户是否已登录
    /// </summary>
    /// <returns>是否</returns>
    public static bool UserIsLogin()
    {
        if (HttpContext.Current.Session["UserInfo"] == null)
        {
            CheckCookie(HttpContext.Current.Request);
        }
        return HttpContext.Current.Session["UserInfo"] != null;
    }
    #endregion

    #region public static bool UserIsAdministrator() 判断当前用户是否为系统管理员
    /// <summary>
    /// 判断当前用户是否为系统管理员
    /// </summary>
    /// <returns>是否</returns>
    public static bool UserIsAdministrator()
    {
        bool returnValue = false;
        if (UserIsLogin())
        {
            BaseUserInfo userInfo = (BaseUserInfo)HttpContext.Current.Session["UserInfo"];
            returnValue = userInfo.IsAdministrator;
        }
        return returnValue;
    }
    #endregion

    #region public static bool CheckIsLogin() 检查是否已登录
    /// <summary>
    /// 检查是否已登录
    /// </summary>
    public static bool CheckIsLogin()
    {
        if (!UserIsLogin())
        {
            string js = @"<Script language='JavaScript'>
                    top.window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, Utilities.UserNotLogin);
            HttpContext.Current.Response.Write(js);

            // HttpContext.Current.Response.Redirect(Utilities.UserNotLogin);
            return false;
        }
        return true;
    }
    #endregion

    #region public static void CheckIsAdministrator() 检查判断当前用户是否为系统管理员
    /// <summary> 
    /// 检查判断当前用户是否为系统管理员
    /// </summary>
    public static void CheckIsAdministrator()
    {
        // 检查是否已登录
        Utilities.CheckIsLogin();
        // 是否系统管理员
        if (!UserIsAdministrator())
        {
            HttpContext.Current.Response.Redirect(Utilities.UserIsNotAdminPage);
        }
    }
    #endregion

    #region public DataTable DTPermission 当前操作员的权限数据，一个页面里只读取一次就可以了，不用反复读取权限，可以在 Session 里缓存起来
    /// <summary>
    /// 当前操作员的权限数据，一个页面里只读取一次就可以了，不用反复读取权限，可以在 Session 里缓存起来
    /// </summary>
    public DataTable DTPermission
    {
        get
        {
            return Utilities.GetFromSession("DTPermission") as DataTable;
        }
        set
        {
            Utilities.AddSession("DTPermission", value);
        }
    }
    #endregion

    //
    // 登录功能相关部分
    //

    #region public static void SaveCookie(string userName, string paramPassword)
    /// <summary>
    ///  保存Cookie
    /// </summary>
    /// <param name="paramUserName">用户名</param>
    /// <param name="paramPassword">密码</param>
    public static void SaveCookie(string userName, string paramPassword)
    {
        HttpCookie httpCookie = new HttpCookie(BaseConfiguration.COMPANY_NAME);
        httpCookie.Values[BaseConfiguration.CURRENT_USERNAME] = userName;
        if (BaseSystemInfo.RememberPassword)
        {
            httpCookie.Values[BaseConfiguration.CURRENT_PASSWORD] = paramPassword;
        }
        // 设置过期时间为1天
        DateTime myDateTime = DateTime.Now;
        httpCookie.Expires = myDateTime.AddDays(1);
        HttpContext.Current.Response.Cookies.Add(httpCookie);
    }

    /// <summary>
    ///  保存Cookie
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    public static void SaveCookie2(string key, string value)
    {
        HttpCookie httpCookie = new HttpCookie(LoginUtilities.CookieName);
        httpCookie.Values[key] = value;

        HttpContext.Current.Response.Cookies.Add(httpCookie);
    }

    public static string GetCookie2(string key)
    {
        string temp = string.Empty;
        HttpCookie cookie = CheckCookie();
        try
        {
            temp = cookie[key].ToString();
        }
        catch (Exception)
        {
        }

        return temp;
    }
    #endregion

    #region public static void RemoveUserCookie()
    /// <summary>
    /// 清空cookie
    /// </summary>
    public static void RemoveUserCookie()
    {
        // 清空cookie
        HttpCookie httpCookie = new HttpCookie(LoginUtilities.CookieName);
        // 设置过期时间，1秒钟后删除cookie就不对了,得时间很长才可以服务器时间与客户时间的差距得考虑好
        httpCookie.Expires = new DateTime(1978, 05, 19);
        HttpContext.Current.Response.Cookies.Add(httpCookie);
    }
    #endregion

    #region public static void RemoveUserSession()
    /// <summary>
    /// 清空cookie
    /// </summary>
    public static void RemoveUserSession()
    {
        HttpContext.Current.Session["UserInfo"] = null;
    }
    #endregion

    public static HttpCookie CheckCookie(HttpRequest httpRequest)
    {
        string paramUserName = string.Empty;
        string paramPassword = string.Empty;
        // 取得cookie的保存信息
        HttpCookie httpCookie = httpRequest.Cookies[LoginUtilities.CookieName];
        if (httpCookie != null)
        {
            // 读取用户名
            if (httpCookie.Values[BaseConfiguration.CURRENT_USERNAME] != null)
            {
                paramUserName = httpCookie.Values[BaseConfiguration.CURRENT_USERNAME].ToString();
                if (BaseSystemInfo.RememberPassword)
                {
                    // 读取密码
                    if (httpCookie.Values[BaseConfiguration.CURRENT_PASSWORD] != null)
                    {
                        paramPassword = httpCookie.Values[BaseConfiguration.CURRENT_PASSWORD].ToString();
                    }
                    // 进行登录
                    Login(paramUserName, paramPassword);
                }
            }
        }
        return httpCookie;
    }

    #region public static HttpCookie CheckCookie()
    /// <summary>
    /// 检查当前的Cookie设置
    /// </summary>
    public static HttpCookie CheckCookie()
    {
        return CheckCookie(HttpContext.Current.Request);
    }
    #endregion

    #region public static BaseUserInfo Login(string suid)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="suid">当点登录识别码</param>
    public static BaseUserInfo Login(string suid)
    {
        // 统一的登录服务
        string returnStatusCode = string.Empty;
        string returnStatusMessage = string.Empty;
        BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.LogOnByOpenId(GetUserInfo(), suid, out returnStatusCode, out returnStatusMessage);
        Login(userInfo, false);
        return userInfo;
    }
    #endregion

    #region public static BaseUserInfo Login(string paramUserName, string paramPassword)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="paramUserName">用户名</param>
    /// <param name="paramPasswor">密码</param>
    public static BaseUserInfo Login(string paramUserName, string paramPassword)
    {
        return Login(paramUserName, paramPassword, false, false);
    }
    #endregion

    #region public static BaseUserInfo Login(string paramUserName, string paramPassword, bool paramPersistCookie, bool paramFormsAuthentication)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="paramUserName">用户名</param>
    /// <param name="paramPassword">密码</param>
    /// <param name="paramPersistCookie">是否保存密码</param>
    /// <param name="paramFormsAuthentication">是否需要重定位</param>
    public static BaseUserInfo Login(string paramUserName, string paramPassword, bool paramPersistCookie, bool paramFormsAuthentication)
    {
        // 统一的登录服务
        string returnStatusCode = string.Empty;
        string returnStatusMessage = string.Empty;
        return Login(paramUserName, paramPassword, paramPersistCookie, paramFormsAuthentication, out returnStatusCode, out returnStatusMessage);
    }
    #endregion

    #region public static BaseUserInfo Login(string userName, string password, bool persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="persistCookie">是否保存密码</param>
    /// <param name="formsAuthentication">表单验证，是否需要重定位</param>
    /// <param name="returnStatusCode"></param>
    /// <param name="returnStatusMessage"></param>
    /// <returns></returns>
    public static BaseUserInfo Login(string userName, string password, bool persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    {
        // 统一的登录服务
        // BaseUserInfo userInfo = UserService.Instance.Login(this.UserInfo, paramUserName, paramPassword, out returnStatusCode, out returnStatusMessage);
        BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.UserLogOn(GetUserInfo(), userName, password, out returnStatusCode, out returnStatusMessage);
        // 在本地模式登录
        // this.UserCenterDbHelper.Open();
        // BUBaseLogin myBULogin = this.Login(myDbHelper, paramUserName, paramPassword);
        // this.UserCenterDbHelper.Close();
        // 检查身份
        if (returnStatusCode.Equals(StatusCode.OK.ToString()))
        {
            if (persistCookie)
            {
                SaveCookie(userName, password);
            }
            Login(userInfo, formsAuthentication);
        }
        return userInfo;
    }
    #endregion

    #region public static BaseUserInfo Login(IDbHelper dbHelper, string paramUserName, string paramPassword)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="dbHelper">数据库连接</param>
    /// <param name="paramUserName">用户名</param>
    /// <param name="paramPassword">密码</param>
    /// <param name="paramPersistCookie">是否保存密码</param>
    /// <param name="paramFormsAuthentication">是否需要重定位</param>
    public static BaseUserInfo Login(IDbHelper dbHelper, string paramUserName, string paramPassword)
    {
        string returnStatusCode = string.Empty;
        BaseUserManager userManager = new BaseUserManager(dbHelper, GetUserInfo());
        BaseUserInfo userInfo = userManager.LogOn(paramUserName, paramPassword, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"], out returnStatusCode);
        return userInfo;
    }
    #endregion

    #region public static void Login(BaseUserInfo userInfo, bool redirectFrom)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="userInfo">登录</param>
    /// <param name="redirectFrom">是否需要重定位</param>
    public static void Login(BaseUserInfo userInfo, bool redirectFrom)
    {
        // 检查身份
        if ((userInfo != null) && (!String.IsNullOrEmpty(userInfo.Id)))
        {
            SetSession(userInfo);
            if (redirectFrom)
            {
                FormsAuthentication.RedirectFromLoginPage(BaseConfiguration.COMPANY_NAME, false);
            }
        }
        else
        {
            // 清空cookie
            RemoveUserCookie();
            // 签出当前的注册
            FormsAuthentication.SignOut();
            // 清除Seesion对象
            // Session.Abandon();
            HttpContext.Current.Session["UserInfo"] = null;
        }
    }
    #endregion

    #region public static void SetSession(BaseUserInfo userInfo)
    /// <summary>
    /// 设置Session
    /// </summary>
    /// <param name="userInfo">操作员</param>
    public static void SetSession(BaseUserInfo userInfo)
    {
        // 检查身份
        if (userInfo.Id.Length > 0)
        {
            // if (String.IsNullOrEmpty(userInfo.RoleId))
            // {
            //     userInfo.RoleId = DefaultRole.User.ToString();
            // }
            // 当前操作员信息
            HttpContext.Current.Session["UserInfo"] = userInfo;
        }
    }
    #endregion

    public static void AddSession(string key, Object myObject)
    {
        HttpContext.Current.Session.Add(key, myObject);
    }

    public static Object GetFromSession(string key)
    {
        return HttpContext.Current.Session[key];
    }

    //
    // 上传下载文件部分
    //

    #region public static string UpLoadFile(string categoryID, string objectID, System.Web.HttpPostedFile httpPostedFile, ref string loadDirectory, bool deleteFile) 上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="paramCategoryID">分类代码</param>
    /// <param name="paramObjectID">实物代码</param>
    /// <param name="httpPostedFile">被上传的文件</param>
    /// <param name="paramLoadDirectory">上传目录</param>
    /// <param name="paramDeleteFile">是否删除原文件夹</param>
    /// <returns>上传的文件位置</returns>
    public static string UpLoadFile(string categoryID, string objectID, System.Web.HttpPostedFile httpPostedFile, ref string loadDirectory, bool deleteFile)
    {
        // 服务器上的绝对路径
        string rootPath = HttpContext.Current.Server.MapPath("~/") + Utilities.UploadFiles + "\\";
        // 图片重新指定，这里主要是为了起备份的作用，按日期把新的照片备份好就可以了。
        if (loadDirectory.Length == 0)
        {
            // 当前日期
            // string dateTime = DateTime.Now.ToString(BaseSystemInfo.DateFormat).ToString();
            // loadDirectory = categoryID + "\\" + dateTime + "\\" + objectID;
            loadDirectory = categoryID + "\\" + objectID;
        }
        // 需要创建的目录，图片放在这里，为了保存历史纪录，使用了当前日期做为目录
        string makeDirectory = rootPath + loadDirectory;
        if (deleteFile)
        {
            // 删除原文件
            if (Directory.Exists(makeDirectory))
            {
                Directory.Delete(makeDirectory, true);
            }
        }
        Directory.CreateDirectory(makeDirectory);
        // 获得文件名
        string fileName = HttpContext.Current.Server.HtmlEncode(Path.GetFileName(httpPostedFile.FileName));
        // 图片重新指定，虚拟的路径
        // 这里还需要更新学生的最新照片
        string fileUrl = loadDirectory + "\\" + fileName;
        // 文件复制到相应的路径下
        string copyToFile = makeDirectory + "\\" + fileName;
        httpPostedFile.SaveAs(copyToFile);
        return fileUrl;
    }
    #endregion

    #region public static string UpLoadFile(string categoryID, string objectID, string loadDirectory, bool deleteFile) 上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="categoryID">分类代码</param>
    /// <param name="objectID">实物代码</param>
    /// <param name="loadDirectory">上传目录</param>
    /// <param name="deleteFile">是否删除原文件夹</param>
    /// <returns>上传的文件位置</returns>
    public static string UpLoadFile(string categoryID, string objectID, string loadDirectory, bool deleteFile)
    {
        return UpLoadFile(categoryID, objectID, HttpContext.Current.Request.Files[0], ref loadDirectory, deleteFile);
    }
    #endregion

    #region public static string UpLoadFiles(string categoryID, string objectID, string upLoadDirectory) 上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="paramCategoryID">分类代码</param>
    /// <param name="paramObjectID">实物代码</param>
    /// <param name="upLoadDirectory">上传的目录</param>
    /// <returns>上传目录</returns>
    public static string UpLoadFiles(string categoryID, string objectID, string upLoadDirectory)
    {
        // 上传文件的复制文件部分
        string upLoadFilePath = string.Empty;
        for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
        {
            if (HttpContext.Current.Request.Files[i].ContentLength > 0)
            {
                // 获取文件名
                string fileName = HttpContext.Current.Server.HtmlEncode(Path.GetFileName(HttpContext.Current.Request.Files[i].FileName));
                upLoadFilePath = UpLoadFile(categoryID, objectID, HttpContext.Current.Request.Files[i], ref upLoadDirectory, false);
            }
        }
        return upLoadFilePath;
    }
    #endregion

    //
    // 表格选择记录功能部分 GridView
    //

    #region public static string[] GetSelecteIds(GridView gridView) 获得已选的表格行代码数组
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(GridView gridView)
    {
        return GetSelecteIds(gridView, true);
    }
    #endregion

    #region public static string[] GetUnSelecteIds(GridView gridView) 获得未选的表格行代码数组
    /// <summary>
    /// 获得未选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetUnSelecteIds(GridView gridView)
    {
        return GetSelecteIds(gridView, false);
    }
    #endregion

    #region public static string[] GetSelecteIds(GridView gridView, bool paramChecked)
    /// <summary>
    /// 获得表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(GridView gridView, bool paramChecked)
    {
        return GetSelecteIds(gridView, paramChecked, "chkSelected");
    }
    #endregion

    public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl)
    {
        return GetSelecteIds(gridView, paramChecked, paramControl, string.Empty);
    }

    #region public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl, string key)
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <param name="paramControl">控件名称</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl, string key)
    {
        string[] ids = new string[0];
        string idList = string.Empty;
        for (int i = 0; i < gridView.Rows.Count; i++)
        {
            // 得到选中的ID
            if (gridView.Rows[i].RowType == DataControlRowType.DataRow)
            {
                TableCell tableCell = gridView.Rows[i].Cells[0];
                CheckBox checkBox = (CheckBox)tableCell.FindControl(paramControl);
                if (checkBox != null)
                {
                    if (checkBox.Checked == paramChecked)
                    {
                        // 把选中的ID保存到字符串
                        string id = string.Empty;
                        if (String.IsNullOrEmpty(key))
                        {
                            id = gridView.DataKeys[gridView.Rows[i].RowIndex].Value.ToString();
                        }
                        else
                        {
                            id = gridView.DataKeys[gridView.Rows[i].RowIndex].Values[key].ToString();
                        }

                        if (id.Length > 0)
                        {
                            idList += id + ",";
                        }
                    }
                }
            }
        }
        // 切分ID
        if (idList.Length > 1)
        {
            idList = idList.Substring(0, idList.Length - 1);
            ids = idList.Split(',');
        }
        return ids;
    }
    #endregion

    //
    // 表格选择记录功能部分 DataGrid
    //

    #region public static string[] GetSelecteIds(DataGrid dataGrid) 获得已选的表格行代码数组
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="dataGrid">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(DataGrid dataGrid)
    {
        return GetSelecteIds(dataGrid, true);
    }
    #endregion

    #region public static string[] GetUnSelecteIds(DataGrid dataGrid) 获得未选的表格行代码数组
    /// <summary>
    /// 获得未选的表格行代码数组
    /// </summary>
    /// <param name="dataGrid">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetUnSelecteIds(DataGrid dataGrid)
    {
        return GetSelecteIds(dataGrid, false);
    }
    #endregion

    #region public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked)
    /// <summary>
    /// 获得表格行代码数组
    /// </summary>
    /// <param name="dataGrid">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked)
    {
        return GetSelecteIds(dataGrid, paramChecked, "chkSelected");
    }
    #endregion

    #region public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked, string paramControl)
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <param name="paramControl">控件名称</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked, string paramControl)
    {
        string[] paramIDs = new string[0];
        string IDs = string.Empty;
        for (int i = 0; i < dataGrid.Items.Count; i++)
        {
            // 得到选中的ID
            TableCell myTableCell = dataGrid.Items[i].Cells[0];
            CheckBox myCheckBox = (CheckBox)myTableCell.FindControl(paramControl);
            if (myCheckBox != null)
            {
                if (myCheckBox.Checked == paramChecked)
                {
                    // 把选中的ID保存到字符串
                    string ID = dataGrid.DataKeys[dataGrid.Items[i].ItemIndex].ToString();
                    if (ID.Length > 0)
                    {
                        IDs += ID + ",";
                    }
                }
            }
        }
        // 切分ID
        if (IDs.Length > 1)
        {
            IDs = IDs.Substring(0, IDs.Length - 1);
            paramIDs = IDs.Split(',');
        }
        return paramIDs;
    }
    #endregion

    //
    // 获取图标地址
    //

    #region public static string GetFileIcon(string fileName) 获取图标地址
    /// <summary>
    /// 获取图标地址
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <returns>图标地址</returns>
    public static string GetFileIcon(string fileName)
    {
        // 这里是默认的图标
        string imageUrl = "Themes/Default/Images/Download.gif";
        // 截取后缀名,GetExtension读出来的后缀带"."的
        string extension = System.IO.Path.GetExtension(fileName).ToLower().Substring(1);
        // 这里查找是否有指定的图标
        if (File.Exists(HttpContext.Current.Server.MapPath("~/") + "Themes/Default/Images/" + extension + ".png"))
        {
            // 获取图标地址
            imageUrl = "Themes/Default/Images/" + extension + ".png";
        }
        return imageUrl;
    }
    #endregion


    #region public static bool CheckLAN()
    /// <summary>
    /// 当前电脑是否在局域网络里
    /// </summary>
    /// <returns></returns>
    public static bool CheckLAN()
    {
        string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        if ((ipAddress.Substring(0, 3) == "127") || (ipAddress.Substring(0, 3) == "192") || (ipAddress.Substring(0, 3) == "10."))
        {
            return true;
        }
        return false;
    }
    #endregion

    #region public static void CloseWindow()
    /// <summary>
    /// 关闭窗体
    /// </summary>
    public static void CloseWindow()
    {
        HttpContext.Current.Response.Write("<script language=\"JavaScript\">");
        HttpContext.Current.Response.Write("window.close();");
        HttpContext.Current.Response.Write("</script>");
    }
    #endregion

    /// <summary>
    /// 根据代码获得 单位
    /// </summary>
    /// <param name="daima">代码</param>
    /// <returns></returns>
    public static DataSet GetDanweiByDaimaInDC05Table(string daima)
    {
        string cmdText = @" select * from  DC05Table where daima=@daima";
        SqlConnection sqlConnection = new SqlConnection(Utilities.BusinessDbConnection);
        SqlCommand sc = new SqlCommand(cmdText, sqlConnection);

        sc.Parameters.Add(new SqlParameter("@daima", daima));

        SqlDataAdapter adapter = new SqlDataAdapter(sc);

        sqlConnection.Open();
        try
        {
            DataSet ds = new DataSet("DC05Table");
            adapter.Fill(ds);
            return ds;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }

    /// <summary>
    /// 获取DC05IndexTable1、DC05IndexTable2中的代码和指标名称，并将结果整合到一块后，返回
    /// </summary>
    /// <returns>代码/指标名称，只需Reader["Daima"]/Reader["Zhibiaomingcheng"]即可读出</returns>
    public static SqlDataReader GetDaimaAndZhibiaomingchengInDC05IndexTable()
    {
        SqlConnection sqlConnection = new SqlConnection(Utilities.BusinessDbConnection);
        string cmdText = @"select Daima,Gongye Zhibiaomingcheng from DC05IndexTable_1 
                                                union select daima,Zhibiaomingcheng from DC05IndexTable_2 ";
        SqlCommand sc = new SqlCommand(cmdText, sqlConnection);
        sqlConnection.Open();
        SqlDataReader reader = sc.ExecuteReader(CommandBehavior.CloseConnection);

        return reader;
    }
    /// <summary>
    /// 获取DC05IndexTable2中的代码所对应的单位名称，返回
    /// </summary>
    /// <param name="daima"></param>
    /// <returns></returns>
    public static SqlDataReader GetDaimaAndZhibiaomingchengInDC05IndexTable(string daima)
    {
        SqlConnection sqlConnection = new SqlConnection(Utilities.BusinessDbConnection);
        string cmdText = @" select Zhibiaodanwei from DC05IndexTable_2 where Daima = " + daima;  //增加单位选择  吴飞
        SqlCommand sc = new SqlCommand(cmdText, sqlConnection);
        sqlConnection.Open();
        SqlDataReader reader = sc.ExecuteReader(CommandBehavior.CloseConnection);

        return reader;
    }

    /// <summary>
    /// 统计各个报表的历年信息，取得BaseReport中的年份
    /// </summary>
    /// <param name="DCXXTable">表名，如DC04Table</param>
    /// <returns></returns>
    public static SqlDataReader GetNianfenInBaseReport(string DCXXTable)
    {

        SqlConnection sqlConnection = new SqlConnection(Utilities.BusinessDbConnection);
        string cmdText = @"select distinct year(a.Nianyue) as Nianyue from BaseReport a
                                                where a.Id in ( select b.Baobiaobianhao from BaseTable b 
                                                        where b.Id in ( select c.Biaobianhao from " + DCXXTable + " c))";
        SqlCommand cmd = new SqlCommand(cmdText, sqlConnection);
        //cmd.Parameters.Add(new SqlParameter("@DCXXTable", DCXXTable));
        sqlConnection.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        return reader;
    }

    /// <summary>
    /// 根据城市码获取下属机构信息
    /// </summary>
    /// <param name="cityCode">城市码</param>
    /// <returns>机构信息表</returns>
    public static DataTable GetDTOrganize(string ProvinceCode)
    {
        BaseOrganizeManager baseOrganizeManager = null;
        DataTable dataTable = new DataTable(BaseOrganizeTable.TableName);
        IDbHelper userCenterDbHelper = DbHelperFactory.GetHelper();
        try
        {
            userCenterDbHelper.Open(UserCenterDbConnection);
            baseOrganizeManager = new BaseOrganizeManager(userCenterDbHelper, GetUserInfo());
            dataTable = baseOrganizeManager.GetDT(BaseOrganizeTable.FieldParentId, ProvinceCode, BaseOrganizeTable.FieldSortCode);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            userCenterDbHelper.Close();
        }
        return dataTable;
    }

    /// <summary>
    /// 获取部门信息
    /// </summary>
    /// <returns>部门表</returns>
    //public static DataTable GetDTDepartment()
    //{
    //    DepartmentCodeManager departCodeManager = null;
    //    DataTable dataTable = new DataTable(DepartmentCodeTable.TableName);
    //    IDbHelper dbHelper = DbHelperFactory.GetHelper();
    //    try
    //    {
    //        dbHelper.Open(BusinessDbConnection);
    //        departCodeManager = new DepartmentCodeManager(dbHelper, GetUserInfo());
    //        dataTable = departCodeManager.GetDT();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        dbHelper.Close();
    //    }
    //    return dataTable;
    //}

    /// <summary>
    /// 获取所有企业
    /// </summary>
    /// <returns>企业信息表</returns>
    //public static DataTable GetDTQiYe()
    //{
    //    CompanyManager companyManager = null;
    //    DataTable dataTable = new DataTable(CompanyTable.TableName);
    //    IDbHelper dbHelper = DbHelperFactory.GetHelper();
    //    try
    //    {
    //        dbHelper.Open(BusinessDbConnection);
    //        companyManager = new CompanyManager(dbHelper, GetUserInfo());
    //        dataTable = companyManager.GetDT(CompanyTable.FieldUserType, CompanyEnum.Enterprise.ToString());
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        dbHelper.Close();
    //    }
    //    return dataTable;
    //}

    /// <summary>
    /// 获取行业
    /// </summary>
    /// <returns>数据表</returns>
    //public static DataTable GetDTHangYe()
    //{
    //    IndustryCodeManager manager = null;
    //    DataTable dataTable = new DataTable(IndustryCodeTable.TableName);
    //    IDbHelper dbHelper = DbHelperFactory.GetHelper();
    //    try
    //    {
    //        dbHelper.Open(BusinessDbConnection);
    //        manager = new IndustryCodeManager(dbHelper, GetUserInfo());
    //        dataTable = manager.GetDT();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        dbHelper.Close();
    //    }
    //    return dataTable;
    //}

    /// <summary>
    /// 获取能源分类
    /// </summary>
    /// <returns></returns>
    //public static DataTable GetDTEngergyCategories()
    //{
    //    DC01TemplateManager manager = null;
    //    DataTable dataTable = new DataTable(DC01TemplateTable.TableName);
    //    IDbHelper dbHelper = DbHelperFactory.GetHelper();
    //    try
    //    {
    //        dbHelper.Open(BusinessDbConnection);
    //        manager = new DC01TemplateManager(dbHelper, GetUserInfo());
    //        dataTable = manager.GetDT();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        dbHelper.Close();
    //    }
    //    return dataTable;
    //}

    /// <summary>
    /// 获取当前用户所属地市县编号
    /// </summary>
    /// <returns>返回地市编号，为了方便起见返回string类型</returns>
    //public static string GetCurrentUserSuoshudishixian()
    //{
    //    string userID = GetUserInfo().Id;
    //    string suoshudishixian = string.Empty;

    //    CompanyManager manager = new CompanyManager();
    //    CompanyEntity entity = manager.GetEntity(userID);

    //    suoshudishixian = entity.Suoshudishixian.ToString();

    //    return suoshudishixian;
    //}

    /// <summary>
    /// 获取所属地市县的代码前缀
    /// </summary>
    /// <returns></returns>
    //public static string GetCurrentUserSuoshudishixianPrefix()
    //{
    //    return GetSuoshudishixianPrefix(GetCurrentUserSuoshudishixian());
    //}


    /// <summary>
    /// 根据地市代码获取获取所属地市县的代码前缀
    /// </summary>
    /// <returns></returns>
    public static string GetSuoshudishixianPrefix(string suoshudishixian)
    {
        string suoshudishixianPrefix = string.Empty;
        if (suoshudishixian.EndsWith("0000"))    //河南省
        {
            suoshudishixianPrefix = suoshudishixian.Substring(0, suoshudishixian.Length - 4);
        }
        else if (suoshudishixian.EndsWith("00"))
        {
            suoshudishixianPrefix = suoshudishixian.Substring(0, suoshudishixian.Length - 2);
        }
        else
        {
            suoshudishixianPrefix = suoshudishixian;
        }

        return suoshudishixianPrefix;
    }

    /// <summary>
    /// 通过三级判断用户选择的到底是哪一级
    /// </summary>
    /// <param name="strProvince">省级代码</param>
    /// <param name="StrCity">市级代码</param>
    /// <param name="strArea">县级代码</param>
    /// <returns>最终地市码</returns>
    public static string GetSuoshudishixianFromDropBox(string strProvince, string StrCity, string strArea)
    {
        string suoshudishixian = string.Empty;

        if (!string.IsNullOrEmpty(strArea) && strArea != "-1")
        {
            suoshudishixian = strArea;
        }
        else if (!string.IsNullOrEmpty(StrCity) && StrCity != "-1")
        {
            suoshudishixian = StrCity;
        }
        else if (!string.IsNullOrEmpty(strProvince) && strProvince != "-1")
        {
            suoshudishixian = strProvince;
        }

        return suoshudishixian;
    }

    /// <summary>
    /// 测试辅助方法，记录日志
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    public static void InsertComment(string title, string content)
    {
        //本月用水量
        string sql = @"insert into Base_Comment (title,Content) values(@title,@content);";

        SqlConnection conn = new SqlConnection(Utilities.BusinessDbConnection);
        SqlCommand sc = new SqlCommand(sql, conn);
        sc.Parameters.Add(new SqlParameter("@title", title));
        sc.Parameters.Add(new SqlParameter("@content", content));
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}