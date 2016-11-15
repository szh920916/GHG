using System;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using System.Threading;

public partial class Login : BasePage
{
    #region public string ReturnURL 目的跳转页面
    private string returnURL = "Default.aspx";
    public string ReturnURL
    {
        get
        {
            return returnURL;
        }
        set
        {
            returnURL = value;
        }
    }
    #endregion

    #region public void GetParameters() 获得页面参数
    /// <summary>
    /// 获得页面参数
    /// </summary>
    public void GetParameter()
    {
        //if (Page.Request["ReturnURL"] != null)
        //{
        //    this.ReturnURL = Page.Request["ReturnURL"];
        //}
        //else
        //{
            if (Request.UrlReferrer != null)
            {
                this.ReturnURL = Request.UrlReferrer.ToString();
            }
            if (this.ReturnURL.ToUpper().IndexOf("LOGIN") > 0)
            {
                this.ReturnURL = "Default.aspx";
            }
        //}
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作

    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 设置为保存密码，默认是不保存密码
        Utilities.GetConfiguration();
        if (!String.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            this.txtUserName.Value = Request.QueryString["UserName"];
        }
        else
        {
            //HttpCookie httpCookie = LoginUtilities.CheckCookie();
            //if (httpCookie != null)
            //{
            //    // 读取用户名
            //    string userName = httpCookie.Values[LoginUtilities.CookieUserName];
            //    string password = httpCookie.Values[LoginUtilities.CookiePassword];
            //    if (!String.IsNullOrEmpty(userName))
            //    {
            //        // 这里需要解密用户名
            //        userName = LoginUtilities.Decrypt(userName);
            //        // 这里获取密码
            //        password = LoginUtilities.Decrypt(password);
            //        // 这里进行登录
            //        this.UserLogin(userName, password);
            //    }
            //}
        }
        // 焦点是停留在哪里的设置
        if (String.IsNullOrEmpty(this.txtUserName.Value))
        {
            this.txtUserName.Focus();
        }
        else
        {
            this.txtPassword.Focus();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 设置为保存密码，默认是不保存密码
        // this.cbRemember.Checked = BaseSystemInfo.SavePassword;
        if (!Page.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    private void UserLogin()
    {
        string userName = this.txtUserName.Value;
        string password = this.txtPassword.Value;
        this.UserLogin(userName, password);
    }

    /// <summary>
    /// 用户的登录操作
    /// </summary>
    private void UserLogin(string userName, string password)
    {
        string checkInput = string.Empty;
        try
        {
            string returnStatusCode = string.Empty;
            string returnStatusMessage = string.Empty;
            
            // 登录验证
            LoginUtilities.Login(userName, password, "GHG", this.chkPersistCookie.Checked, false, out returnStatusCode, out returnStatusMessage);
            
            // txtVerifyCode.Text = string.Empty;
            // 登录结果
            if (returnStatusCode.Equals(StatusCode.OK.ToString()))
            {
               Session["PasswordErrorTimes"] = 0;
                // this.AfterLogin();
                // 重新定向到跳转的页面
               Session["userName"] = this.txtUserName.Value.ToString();
                Page.Response.Redirect(this.ReturnURL);
            }
            else if (returnStatusCode.Equals(StatusCode.PasswordError.ToString()))  //若密码错误
            {
                int PasswordErrorTimes = 0;
                string OldPasswordErrorTimes = null;
                if (Session["PasswordErrorTimes"] != null)
                {
                    OldPasswordErrorTimes = Session["PasswordErrorTimes"].ToString();
                }
                if (!string.IsNullOrEmpty(OldPasswordErrorTimes))
                {
                    Int32.TryParse(OldPasswordErrorTimes, out PasswordErrorTimes);

                }
                PasswordErrorTimes++;
                Session["PasswordErrorTimes"] = PasswordErrorTimes;

                if (PasswordErrorTimes > 5)
                {
                    Thread.Sleep((PasswordErrorTimes - 5) * (PasswordErrorTimes - 5) * 60000);
                }

                checkInput = "<script>alert('提示信息：登录失败，请检查你的用户名和密码是否输入有误。您已经出错" + PasswordErrorTimes.ToString() + "次，系统将根据您的出错次数锁定一定时长！');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", checkInput);
                this.txtUserName.Focus();
            }
            else
            {
                checkInput = "<script>alert('提示信息：" + returnStatusMessage + "');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", checkInput);
                this.txtUserName.Focus();
            }
        }
        catch
        {
            checkInput = "<script>alert('提示信息：登录失败，请检查你的用户名和密码是否输入有误。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", checkInput);
            this.txtUserName.Focus();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // 用户的登录操作
        if (String.IsNullOrEmpty(this.txtUserName.Value.Trim()) || String.IsNullOrEmpty(this.txtPassword.Value.Trim()))
        {
            ScriptUtil.Alert("用户名和密码不能为空。");
            return;
        }
        /*
        string verifyCode = this.txtVerifyCode.Text;
        if (String.Compare(Session["VerifyCode"].ToString(), verifyCode, true) != 0)
        {
            txtVerifyCode.Text = "";
            txtPassword.Focus();
            ScriptUtil.Alert("验证码错误，请输入正确的验证码。");
            return;
        }
        */
        this.UserLogin();
    }
}