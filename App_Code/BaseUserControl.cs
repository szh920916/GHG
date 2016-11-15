using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;

using DotNet.DbUtilities;
using DotNet.Service;
using DotNet.Utilities;
using DotNet.BaseManager;
using DotNet.Model;
using DotNet.Manager;

/// <remarks>
/// BasePage
/// 基础网页类
/// 
/// 修改纪录
/// 
///	版本：2.5 2009.11.09    JiRiGaLa    public void Authorized(string permissionItemCode) 函数进行改进。
///	版本：2.4 2008.03.17    JiRiGaLa    登录程序改进为面向服务的登录。
///	版本：2.3 2008.03.07    JiRiGaLa    登录时页面重新导向功能改进。
///	版本：2.2 2007.12.09    JiRiGaLa    获得页面权限的 GetPermission 函数改进。
///	版本：2.1 2007.12.08    JiRiGaLa    单点登录功能完善。
///	版本：2.0 2006.02.02    JiRiGaLa    页面注释都修改好。
///	
/// 版本：2.5
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.11.09</date>
/// </author> 
/// </remarks>
public class BaseUserControl : System.Web.UI.UserControl
{
    protected string ImagesURL = ConfigurationManager.AppSettings["ImagesURL"];

    protected IDbHelper dbHelper = null;

    /// <summary>
    /// 业务数据库部分
    /// </summary>
    protected IDbHelper DbHelper
    {
        get
        {
            if (dbHelper == null)
            {
                // 当前数据库连接对象
                dbHelper = new SqlHelper(Utilities.BusinessDbConnection);
            }
            return dbHelper;
        }
    }

    protected IDbHelper userCenterDbHelper = null;

    /// <summary>
    /// 用户中心数据库部分
    /// </summary>
    protected IDbHelper UserCenterDbHelper
    {
        get
        {
            if (userCenterDbHelper == null)
            {
                // 当前数据库连接对象
                userCenterDbHelper = new SqlHelper(Utilities.UserCenterDbConnection);
            }
            return userCenterDbHelper;
        }
    }

    private BaseUserInfo userInfo = null;                       // 当前操作员信息对象
    public BaseUserInfo UserInfo
    {
        get
        {
            if (Session["UserInfo"] != null)
            {
                this.userInfo = (BaseUserInfo)Session["UserInfo"];
            }
            if (this.userInfo == null)
            {
                // 从 Session 读取 当前操作员信息
                if (Session["UserInfo"] == null)
                {
                    this.userInfo = new BaseUserInfo();
                    // 获得IP 地址
                    //this.userInfo.Id = Context.Request.ServerVariables["REMOTE_ADDR"];
                    this.userInfo.RealName = Context.Request.ServerVariables["REMOTE_ADDR"];
                    this.userInfo.UserName = Context.Request.ServerVariables["REMOTE_ADDR"];
                    this.userInfo.IPAddress = Context.Request.ServerVariables["REMOTE_ADDR"];
                    // 设置操作员类型，防止出现错误，因为不小心变成系统管理员就不好了
                    // if (this.userInfo.RoleId.Length == 0)
                    //{
                    //    this.userInfo.RoleId = DefaultRole.User.ToString();
                    //}
                }
            }
            return this.userInfo;
        }
        set
        {
            this.userInfo = value;
        }
    }

    /// <summary>
    /// 单点登录唯一识别标识
    /// </summary>
    public string OpenId = string.Empty;

    /// <summary>
    /// 有效显示字符串定义
    /// </summary>
    public string EnableState = "<font color=\"#CC0000\">√<font>";

    /// <summary>
    /// 无效显示字符串定义
    /// </summary>
    public string DisableState = "<font color=\"#CC0000\">-<font>";

    #region protected override void OnInit(EventArgs e) 所有页面加载时默认运行的方法
    /// <summary>
    /// 所有页面加载时默认运行的方法
    /// </summary>
    /// <param name="e">系统默认参数</param>
    protected override void OnInit(EventArgs e)
    {
        this.GetParamterOpenId();
        if (!LoginUtilities.UserIsLogin())
        {
            if (this.OpenId.Length > 0)
            {
                this.UserInfo = LoginUtilities.Login(this.OpenId);
            }
            // 判断用户是否已登录
            // this.UserIsLogin();
        }
        // 统一的错误处理页面部分
        // this.Error += new EventHandler(BasePage_Error);
    }
    #endregion

    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}

    public bool UserCanSystemAdmin()
    {
        // 1.先判断是否已登录
        if (Utilities.CheckIsLogin())
        {
            // 2.有没有假劣药审核的权限？
            if (!IsAuthorized("SystemAdmin"))
            {
                //HttpContext.Current.Response.Redirect(Utilities.UserNotLogin);
                Response.Write("<script>window.top.location.href='" + Utilities.UserNotLogin + "'</script>");
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    #region public void GetParamterOpenId() 所有页面基础类的，活得单点登录唯一识别标识的方法
    /// <summary>
    ///所有页面基础类的，活得单点登录唯一识别标识的方法
    /// </summary>
    public void GetParamterOpenId()
    {
        if (Page.Request["SUID"] != null)
        {
            this.OpenId = Page.Request["SUID"].ToString();
        }
        if (Page.Request["OpenId"] != null)
        {
            this.OpenId = Page.Request["OpenId"].ToString();
        }
    }
    #endregion

    #region protected void GetConfig() 读取一些基本配置信息
    /// <summary>
    /// 读取一些基本配置信息
    /// </summary>
    protected void GetConfig()
    {
        // 获取一些运行模式参数
        // this.UserInfo.RunMode = BaseConfiguration.Instance.RunMode;
        // this.UserInfo.WebService = BaseConfiguration.Instance.WebService;
        this.UserInfo.WebServiceUserName = BaseSystemInfo.WebServiceUserName;
        this.UserInfo.WebServicePassword = BaseSystemInfo.WebServicePassword;
    }
    #endregion

    public void Authorized(string permissionItemCode)
    {
        // 若没有相应的权限，那就跳转到没有权限的页面里
        if (!LoginUtilities.UserIsLogin() || !IsAuthorized(permissionItemCode))
        {
            HttpContext.Current.Response.Redirect(Utilities.AccessDenyPage + "?Code=" + permissionItemCode);
        }
    }

    #region public bool IsAuthorized(string permissionItemCode) 是否有相应的权限
    /// <summary>
    /// 是否有相应的权限
    /// </summary>
    /// <param name="permissionItemCode">权限编号</param>
    /// <returns>是否有权限</returns>
    public bool IsAuthorized(string permissionItemCode)
    {
        return ServiceManager.Instance.PermissionService.IsAuthorizedByUser(this.UserInfo, this.UserInfo.Id, permissionItemCode);
        // return BaseResourcePermissionManager.Instance.CheckPermissionByUser(this.UserCenterDbHelper, this.UserInfo, permissionItemCode);
    }
    #endregion

    #region public bool ModuleIsAuthorized(string moduleCode) 是否有相应的模块权限
    /// <summary>
    /// 是否有相应的模块权限
    /// </summary>
    /// <param name="moduleCode">模块编号</param>
    /// <returns>是否有权限</returns>
    public bool ModuleIsAuthorized(string moduleCode)
    {
        if (this.UserInfo.IsAdministrator)
        {
            return true;
        }
        return BaseBusinessLogic.Exists(this.DTModule, BaseModuleTable.FieldCode, moduleCode);
    }
    #endregion

    #region protected void GetModuleDT()
    /// <summary>
    /// 获模块列表
    /// </summary>
    protected void GetModuleDT()
    {
        BaseModuleManager moduleManager = new BaseModuleManager(this.UserCenterDbHelper, this.UserInfo);
        if (this.UserInfo.IsAdministrator)
        {
            DTModule = moduleManager.GetDT(BaseModuleTable.FieldDeletionStateCode, 0, BaseModuleTable.FieldEnabled, 1, BaseModuleTable.FieldSortCode);
        }
        else
        {
            DTModule = moduleManager.GetDTByUser(this.UserInfo.Id);
        }
        // 按有效的模块进行过滤
        BaseBusinessLogic.SetFilter(DTModule, BaseModuleTable.FieldEnabled, "1");
        BaseBusinessLogic.SetFilter(DTModule, BaseModuleTable.FieldDeletionStateCode, "0");
        DTModule.DefaultView.Sort = BaseModuleTable.FieldSortCode;
    }
    #endregion

    protected DataTable DTModule
    {
        get
        {
            // 判断是否有数据，若没数据自动读取一次
            if (HttpContext.Current.Session["_DTModule"] == null)
            {
                // 这里进行了菜单优化，出错问题
                bool openDB = false;
                if (this.UserCenterDbHelper.GetDbConnection() == null)
                {
                    this.UserCenterDbHelper.Open();
                    openDB = true;
                }
                this.GetModuleDT();
                if (openDB)
                {
                    this.UserCenterDbHelper.Close();
                }
            }
            return Utilities.GetFromSession("_DTModule") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTModule", value);
        }
    }

    #region public void LogException(Exception exception) 记录异常信息
    /// <summary>
    /// 记录异常信息
    /// </summary>
    /// <param name="exception">异常信息实体</param>
    public void LogException(Exception exception)
    {
        BaseExceptionManager.LogException(this.UserCenterDbHelper, this.UserInfo, exception);
    }
    #endregion

    //
    // 排序功能部分
    //

    public string SortExpression
    {
        get
        {
            if (ViewState["sortExpression"] == null)
            {
                ViewState["sortExpression"] = BaseNewsTable.FieldSortCode;
            }
            return ViewState["sortExpression"].ToString();
        }
        set
        {
            ViewState["sortExpression"] = value;
        }
    }

    public string SortDire
    {
        get
        {
            if (ViewState["sortDire"] == null)
            {
                ViewState["sortDire"] = " DESC ";
            }
            return ViewState["sortDire"].ToString();
        }
        set
        {
            ViewState["sortDire"] = value;
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        this.UserCenterDbHelper.Close();
        this.DbHelper.Close();
    }
}