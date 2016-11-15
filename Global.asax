<%@ Application Language="C#" %>
<%@ Import Namespace="DotNet.Utilities" %>
<%@ Import Namespace="System.Configuration" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
        // 计算人数
        Application.Lock();
        Application["CurrentUsers"] = 0;
        Application["AllUsers"] = 0;
        Application.UnLock();
        // 读取配置文件
        BaseSystemInfo.ConfigurationFrom = ConfigurationCategory.Configuration;
        BaseConfiguration.GetSetting();
        // 不检查在线状态
        BaseSystemInfo.CheckOnLine = false;
        // 是否需要注册
        BaseSystemInfo.NeedRegister = false;
        // 保存密码功能开启
        BaseSystemInfo.RememberPassword = true;
        // 加密密码
        BaseSystemInfo.EncryptPassword = true;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
        Exception objErr = Server.GetLastError().GetBaseException();
        string error = "发生异常页: " + Request.Url.ToString() + "\r\n";
        error += "异常信息: " + objErr.Message;
        // Logger.LogError(error);
        Application["error"] = error;
        Application["errorStack"] = objErr.ToString();
        //清空错误，以使错误不要联级触发！
        Server.ClearError();
        Server.Transfer("~/Error.aspx");
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码
        // 计算人数
        Application.Lock();
        Application["CurrentUsers"] = (int)Application["CurrentUsers"] + 1;
        Application["AllUsers"] = (int)Application["AllUsers"] + 1;
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。
        // 计算人数
        Application.Lock();
        Application["CurrentUsers"] = (int)Application["CurrentUsers"] - 1;
        Application.UnLock();
    }

</script>
