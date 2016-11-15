using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DotNet.Service;
using System.IO;

public partial class Modules_Common_DbBackup : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

           
        }
    }

    public void BindDropdownList()
    {
        string cmdTxt = "Exec sp_helpdb";        
        SqlDataReader dr = (SqlDataReader)UserCenterDbHelper.ExecuteReader(cmdTxt);
        this.DDLDataBase.DataSource = dr;
        this.DDLDataBase.DataTextField = "name";
        this.DDLDataBase.DataBind();
        DDLDataBase.Items.Insert(0, new ListItem("-请选择-", "-1"));

    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        if (DDLDataBase.SelectedValue == "-1")
        {
            string errMsg = "<script>alert('提示信息：请选择需要备份的数据库。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);
        }
        else
        {
            string fullExpFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Resource/DbBackup/") + DateTime.Now.ToString("yyyyMMdd") + "-" + this.txtFileName.Text.Trim() + ".bak'";

            #region 创建临时文件夹
            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Resource")))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Resource"));
            }

            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Resource/DbBackup")))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Resource/DbBackup"));
            }
            #endregion

            string cmdTxt = "backup database " + DDLDataBase.SelectedValue + " to disk='" + fullExpFilePath;
            try
            {
                UserCenterDbHelper.ExecuteNonQuery(cmdTxt);

                string errMsg = "<script>alert('提示信息：备份数据库成功。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);
            }
            catch (Exception ex)
            {
                string errMsg = "<script>alert('提示信息：备份数据库失败，请联系管理员。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);

            }
        }
    }
}