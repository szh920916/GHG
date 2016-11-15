using System;
using System.Configuration;
using System.Web.UI;

using DotNet.Utilities;

public partial class Work : System.Web.UI.Page
{
    private string defaultPage = "MainDefault.aspx";
    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        string customerCompanyName = ConfigurationManager.AppSettings["SoftFullName"];
        string softFullName = ConfigurationManager.AppSettings["CustomerCompanyName"];
        this.Header.Title = customerCompanyName + " - " + softFullName;
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        this.GetParamter();
       

        // 这里是设置默认加载的菜单 //  + BaseSystemInfo.RootMenuCode
        
        string leftPage = "LeftMenu.aspx";  //没有带上参数的话，从config中读取
        //禁用Leftpage参数，只从config中读取，虽然可能造成不灵活，但是可以防止钓鱼出现 吴亚平 2011-11-17
        //if (Page.Request["Left"] != null)
        //{
        //    leftPage = Page.Request["Left"];
        //}
        string requestQuery = Page.Request.Url.Query;
        //TODO:如果用户没有注册企业信息，那么默认页直接为企业信息注册界面
        //CompanyService service = new CompanyService();
        BaseUserInfo userInfo = (BaseUserInfo)Session["UserInfo"];

        
        this.SetDefaultPage(this.parentfram, leftPage, this.defaultPage, requestQuery);
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 检查用户是否登录
            Utilities.CheckIsLogin();
            this.DoPageLoad();
        }
    }

    /// <summary>
    /// 获取default.aspx页面的显示代码
    /// </summary>
    /// <param name="parentfram">frameset,框架名称</param>
    /// <param name="myLeftUrl">默认指向的左框架页面地址</param>
    /// <param name="myMainUrl">默认指向的main框架页面地址</param>
    /// <param name="myQuery">左框架附带的信息</param>
    public void SetDefaultPage(System.Web.UI.HtmlControls.HtmlGenericControl parentFrame, string leftPage, string mainPage, string requestQuery)
    {
        //定义上框架、左框架打开与关闭的大小
        string frameHtml = "";

        //根据上框架开关决定显示的高度
        if ((new FrameInfo()).ShowTopFrame)
        {
            //如果上框架是展开的
            parentFrame.Attributes.Add("rows", (new FrameInfo()).TopExpandHeight + ",*");
        }
        else
        {
            //如果上框架是收缩的
            parentFrame.Attributes.Add("rows", (new FrameInfo()).TopShrinkHeight + ",*");
        }
        frameHtml = "<frame id=topfram src=\"CommonHeader.aspx" + requestQuery + "\" name=\"topFrame\" scrolling=\"NO\" noresize >";

        //根据左框架开关决定是否显示左框架
        if ((new FrameInfo()).ShowLeftFrame)
        {
            //如果左框架是展开的
            frameHtml += "<frameset id = myframeset cols=\"" + (new FrameInfo()).LeftWidth + ",*\" framespacing=\"1\" frameborder=\"yes\" border=\"1\" bordercolor=\"#6699CC\">";
        }
        else
        {
            //如果左框架是收缩的
            frameHtml += "<frameset id = myframeset cols=\"0,*\" framespacing=\"1\" frameborder=\"yes\" border=\"1\" bordercolor=\"#6699CC\">";
        }

        frameHtml += "<frame id=leftfram src=\"" + leftPage + requestQuery + "\" name=\"leftFrame\" scrolling=\"auto\" marginwidth=0>";
        frameHtml += "<frame id=fraContent src=\"" + mainPage + "\" name=\"fraContent\" scrolling=\"auto\">";
        frameHtml += "</frameset>";

        parentFrame.InnerHtml = frameHtml;
    }
}
