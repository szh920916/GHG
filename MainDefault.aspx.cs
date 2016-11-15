using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_EUoI_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //TODO此处需要优化

            if (UserInfo.RoleId == 10000014 )//如果为企业用户
            {
                lnkInfo.NavigateUrl = @"~\Modules\Common\UserAdmin\CompanyEdit.aspx";
            }
            else if (UserInfo.RoleId == 10000016)//核查机构用户
            {
                lnkInfo.NavigateUrl = @"~\Modules\Common\UserAdmin\HeChaJiGouEdit.aspx";
            }
            else 
            {
                Response.Redirect( @"~\Modules\Common\UserAdmin\UserInfo.aspx");
            }
            
        }

    }
}