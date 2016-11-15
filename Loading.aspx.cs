using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loading : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string GetRedirectUrl()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["RedirectUrl"]))
        {
            return Convert.ToString(Request.QueryString["RedirectUrl"]);
        }
        return string.Empty;
    }
}