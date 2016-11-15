//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd .
//------------------------------------------------------------

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Security;

using DotNet.DbUtilities;
using DotNet.Service;
using DotNet.Utilities;
using DotNet.BaseManager;
using DotNet.Model;
using DotNet.Manager;
using System.Threading;
using System.Reflection;

/// <summary>
/// 登录功能相关部分
/// </summary>
public class LoginUtilities
{
    /// <summary>
    /// 数据库连接串，改进性能只读取一次就可以了
    /// </summary>
    public static readonly string BusinessDbConnection = ConfigurationManager.AppSettings["BusinessDbConnection"];

    /// <summary>
    /// 用户中心数据库连接
    /// </summary>
    public static readonly string UserCenterDbConnection = ConfigurationManager.AppSettings["UserCenterDbConnection"];

    /// <summary>
    /// Cookie 名称
    /// </summary>
    public static string CookieName = "Project";
    public static string CookieUserName = "UserName";
    public static string CookiePassword = "Password";

    /// <summary>
    /// Session 名称
    /// </summary>
    public static string SessionName = "UserInfo";

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
        BaseUserManager userManager = new BaseUserManager(dbHelper, Utilities.GetUserInfo());
        BaseUserInfo userInfo = userManager.LogOn(paramUserName, paramPassword, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"], out returnStatusCode);
        return userInfo;
    }
    #endregion

    public static HttpCookie GetCookie(HttpRequest httpRequest)
    {
        return httpRequest.Cookies[BaseConfiguration.COMPANY_NAME];
    }

    //
    // 二 判断用户是否已登录部分
    //


    #region public static bool UserIsLogin() 判断用户是否已登录
    /// <summary>
    /// 判断用户是否已登录
    /// </summary>
    /// <returns>已登录</returns>
    public static bool UserIsLogin()
    {
        if (HttpContext.Current.Session["UserInfo"] == null)
        {
            // 检查是否有Cookie？
            CheckCookie(HttpContext.Current.Request);
        }
        return HttpContext.Current.Session["UserInfo"] != null;
    }
    #endregion

    #region public static void SetSession(BaseUserInfo userInfo)
    /// <summary>
    /// 保存Session
    /// </summary>
    /// <param name="userInfo">当前用户</param>
    public static void SetSession(BaseUserInfo userInfo)
    {
        // 检查是否有效用户
        if (userInfo.Id.Length > 0)
        {
           
            HttpContext.Current.Session[SessionName] = userInfo;
        }
    }
    #endregion


    //
    // 三 判断当前的CheckCookie内容情况
    //

    #region public static HttpCookie CheckCookie()
    /// <summary>
    /// 检查当前的Cookie内容
    /// </summary>
    public static HttpCookie CheckCookie()
    {
        return CheckCookie(HttpContext.Current.Request);
    }
    #endregion

    #region public static HttpCookie CheckCookie(HttpRequest httpRequest)
    /// <summary>
    /// 检查当前的Cookie内容
    /// </summary>
    /// <param name="httpRequest">当前页</param>
    /// <returns>Cookie内容</returns>
    public static HttpCookie CheckCookie(HttpRequest httpRequest)
    {
        string username = string.Empty;
        string password = string.Empty;
        // 取得cookie的保存信息
        HttpCookie httpCookie = httpRequest.Cookies[CookieName];
        if (httpCookie != null)
        {
            // 读取用户名
            if (!String.IsNullOrEmpty(httpCookie.Values[CookieUserName]))
            {
                username = Decrypt(httpCookie.Values[CookieUserName].ToString());
                if (BaseSystemInfo.RememberPassword)
                {
                    // 读取密码
                    if (!String.IsNullOrEmpty(httpCookie.Values[CookiePassword]))
                    {
                        password = Decrypt(httpCookie.Values[CookiePassword].ToString());
                    }
                    // 进行登录
                    Login(username, password);
                }
            }
        }
        return httpCookie;
    }
    #endregion

    #region public static void SaveCookie(string userName, string password)
    /// <summary>
    ///  保存Cookie
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    public static void SaveCookie(string userName, string password)
    {
        HttpCookie httpCookie = new HttpCookie(CookieName);
        // 需要加密用户名
        httpCookie.Values[CookieUserName] = Encrypt(userName);
        if (BaseSystemInfo.RememberPassword)
        {
            // 需要加密密码
            httpCookie.Values[CookiePassword] = Encrypt(password);
        }
        // 设置过期时间为30天
        DateTime dateTime = DateTime.Now;
        httpCookie.Expires = dateTime.AddDays(30);
        HttpContext.Current.Response.Cookies.Add(httpCookie);
    }
    #endregion


    //
    // 四 用OpenId登录部分
    //


    #region public static BaseUserInfo Login(string openId)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="openId">当点登录识别码</param>
    public static BaseUserInfo Login(string openId)
    {
        // 统一的登录服务
        string returnStatusCode = string.Empty;
        string returnStatusMessage = string.Empty;

        BaseUserInfo userInfo = null;

        using (SqlConnection sqlConnection = new SqlConnection(BusinessDbConnection))
        {
            sqlConnection.Open();
            string sqlQuery = " SELECT * FROM BASE_USERINFO ";
            string sqlWhere = " WHERE Uhid = @openId ";
            sqlQuery = sqlQuery + sqlWhere;
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@openId", openId);
            IDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.Read())
            {
                // 还没有被激活
                if (!dataReader["Isactive"].ToString().Equals("1"))
                {
                    returnStatusCode = DotNet.Utilities.StatusCode.LogOnDeny.ToString();
                    returnStatusMessage = "访问被拒绝，账户还未被激活。";
                }
                else
                {
                    // 若不为空，判断批准文号
                    userInfo = new BaseUserInfo();
                    userInfo.Id = dataReader["Userid"].ToString();
                    userInfo.UserName = dataReader["Loginname"].ToString();
                    userInfo.OpenId = dataReader["Uhid"].ToString();
                    returnStatusCode = DotNet.Utilities.StatusCode.OK.ToString();
                    returnStatusMessage = "成功登录。";
                }
            }
            // 这里必须要关闭读取流。
            dataReader.Close();
            sqlConnection.Close();
        }
        Login(userInfo, false);
        return userInfo;
    }
    #endregion


    //
    // 五 用用户名密码登录部分
    //


    #region public static BaseUserInfo Login(string username, string password)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    public static BaseUserInfo Login(string username, string password)
    {
        return Login(username, password, null, false);
    }
    #endregion

    #region public static BaseUserInfo Login(string username, string password, bool persistCookie, bool formsAuthentication)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="persistCookie">是否保存密码</param>
    /// <param name="formsAuthentication">是否需要重定位</param>
    public static BaseUserInfo Login(string username, string password, bool? persistCookie, bool formsAuthentication)
    {
        // 统一的登录服务
        string returnStatusCode = string.Empty;
        string returnStatusMessage = string.Empty;
        return Login(username, password, persistCookie, formsAuthentication, out returnStatusCode, out returnStatusMessage);
    }
    #endregion

    #region public static BaseUserInfo Login(string username, string password, bool? persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="persistCookie">是否保存密码</param>
    /// <param name="formsAuthentication">表单验证，是否需要重定位</param>
    /// <param name="returnStatusCode"></param>
    /// <param name="returnStatusMessage"></param>
    /// <returns></returns>
    public static BaseUserInfo Login(string username, string password, bool? persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    {
        // 统一的登录服务
        returnStatusCode = string.Empty;
        returnStatusMessage = string.Empty;
        BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.UserLogOn(Utilities.GetUserInfo(), username, password, out returnStatusCode, out returnStatusMessage);
        if (returnStatusCode.Equals(StatusCode.OK.ToString()))
        {
            if (persistCookie != null && (bool)persistCookie)
            {
                SaveCookie(username, password);
            }
            Login(userInfo, formsAuthentication);
        }
        return userInfo;
    }
    #endregion

    #region public static BaseUserInfo Login(string userName, string password, string permissionItemCode, bool persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="permissionItemCode">权限编号</param>
    /// <param name="persistCookie">是否保存密码</param>
    /// <param name="formsAuthentication">表单验证，是否需要重定位</param>
    /// <param name="returnStatusCode"></param>
    /// <param name="returnStatusMessage"></param>
    /// <returns></returns>
    public static BaseUserInfo Login(string userName, string password, string permissionItemCode, bool persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    {
        // 统一的登录服务
        BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.UserLogOn(Utilities.GetUserInfo(), userName, password, out returnStatusCode, out returnStatusMessage);
        // 检查身份
        if (returnStatusCode.Equals(StatusCode.OK.ToString()))
        {
            bool isAuthorized = true;
            // 用户是否有哪个相应的权限
            if (!String.IsNullOrEmpty(permissionItemCode))
            {
                //isAuthorized = ServiceManager.Instance.PermissionService.IsAuthorized(userInfo, permissionItemCode);
                isAuthorized = IsAuthorized(userInfo, permissionItemCode);
            }
            // 有相应的权限才可以登录
            if (isAuthorized)
            {
                if (persistCookie)
                {
                    //SaveCookie(userName, password);
                }
                else
                {
                    RemoveUserCookie();
                }
                Login(userInfo, formsAuthentication);
            }
            else
            {
                returnStatusCode = StatusCode.LogOnDeny.ToString();
                returnStatusMessage = "访问被拒绝、您的账户没有后台管理访问权限。";
            }
        }
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
            Logout();
        }
    }
    #endregion


    //
    // 六 安全退出部分
    //


    #region public static void RemoveUserCookie()
    /// <summary>
    /// 清空cookie
    /// </summary>
    public static void RemoveUserCookie()
    {
        // 清空cookie
        HttpCookie httpCookie = new HttpCookie(CookieName);
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
        HttpContext.Current.Session[SessionName] = null;
    }
    #endregion

    #region public static void Logout()
    /// <summary>
    /// 退出登录部分
    /// </summary>
    public static void Logout()
    {
        // 清除Seesion对象
        RemoveUserSession();
        // 清空cookie
        RemoveUserCookie();
        // Session.Abandon();
        // 在此处放置用户代码以初始化页面
        // FormsAuthentication.SignOut();
        // 重新定位到登录页面
        HttpContext.Current.Response.Redirect("Default.aspx", true);
    }
    #endregion


   
    

    /// <summary>
    /// 更新用户的新密码
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <param name="newPassword">新密码</param>
    /// <returns>影响行数</returns>
    private static int SetPassword(string userId, string newPassword)
    {
        int returnValue = 0;
        return returnValue;
    }

    /// <summary>
    /// 获取密码
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <returns>密码</returns>
    private static string GetPassword(string userId)
    {
        string returnValue = string.Empty;
        return returnValue;
    }


    #region public static int ChangePassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode) 更新密码
    /// <summary>
    /// 更新密码
    /// </summary>
    /// <param name="oldPassword">原密码</param>
    /// <param name="newPassword">新密码</param>
    /// <param name="statusCode">返回状态码</param>
    /// <returns>影响行数</returns>
    public static int ChangePassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode)
    {
        int returnValue = 0;
        statusCode = string.Empty;
        // 新密码是否允许为空
        if (!BaseSystemInfo.AllowNullPassword)
        {
            if (String.IsNullOrEmpty(newPassword))
            {
                statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                return returnValue;
            }
        }
        // 是否加密
        oldPassword = DotNet.Utilities.SecretUtil.md5(oldPassword);
        newPassword = DotNet.Utilities.SecretUtil.md5(newPassword);

        // 判断输入原始密码是否正确
        // 密码错误
        if (!GetPassword(userInfo.Id).Equals(oldPassword))
        {
            statusCode = StatusCode.OldPasswordError.ToString();
            return returnValue;
        }
        // 更改密码
        returnValue = SetPassword(userInfo.Id, newPassword);
        if (returnValue == 1)
        {
            statusCode = StatusCode.ChangePasswordOK.ToString();
        }
        else
        {
            // 数据可能被删除
            statusCode = StatusCode.ErrorDeleted.ToString();
        }
        return returnValue;
    }
    #endregion




    //
    // 九 字符串加密解密部分
    //

    /// <summary>
    /// DES数据加密
    /// </summary>
    /// <param name="targetValue">目标字段</param>
    /// <returns>加密</returns>
    public static string Encrypt(string targetValue)
    {
        return Encrypt(targetValue, "Project");
    }

    /// <summary>
    /// DES数据加密
    /// </summary>
    /// <param name="targetValue">目标值</param>
    /// <param name="key">密钥</param>
    /// <returns>加密值</returns>
    private static string Encrypt(string targetValue, string key)
    {
        return SecretUtil.Encrypt(targetValue, key);
    }


    /// <summary>
    /// DES数据解密
    /// </summary>
    /// <param name="targetValue">目标字段</param>
    /// <returns>解密</returns>
    public static string Decrypt(string targetValue)
    {
        return Decrypt(targetValue, "Project");
    }

    /// <summary>
    /// DES数据解密
    /// </summary>
    /// <param name="targetValue"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    private static string Decrypt(string targetValue, string key)
    {
        return SecretUtil.Decrypt(targetValue, key);
    }





    public static  bool IsAuthorized(BaseUserInfo userInfo, string permissionItemCode)
    {
        return IsAuthorizedByUser(userInfo, userInfo.Id, permissionItemCode);
    }


    public static bool IsAuthorizedByUser(BaseUserInfo userInfo, string userId, string permissionItemCode)
    {
        // 写入调试信息
#if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
#endif
        bool returnValue = false;

        IDbHelper dbHelper = DbHelperFactory.GetHelper();
        try
        {
            dbHelper.Open(UserCenterDbConnection);
            // 是超级管理员,就不用继续判断权限了
            BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
            returnValue = userManager.IsAdministrator(userId);
            if (returnValue)
            {
                return returnValue;
            }
            BasePermissionManager permissionManager = new BasePermissionManager(dbHelper, userInfo);
            returnValue = permissionManager.CheckPermissionByUser(userId, permissionItemCode);
            BaseLogManager.Instance.Add(dbHelper, userInfo, MethodBase.GetCurrentMethod());
        }
        catch (Exception ex)
        {
            BaseExceptionManager.LogException(dbHelper, userInfo, ex);
            throw ex;
        }
        finally
        {
            dbHelper.Close();
        }
        // 写入调试信息
#if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
#endif
        return returnValue;
    }






}