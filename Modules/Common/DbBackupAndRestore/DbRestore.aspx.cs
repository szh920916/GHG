using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DotNet.Service;
using System.IO;

public partial class Modules_Common_DbRestore : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindDropdownList();
            
        }
    }

    public void BindDropdownList()
    {
        //绑定数据库
        DDLDataBase.Items.Clear();
        string cmdTxt = "Exec sp_helpdb";
        SqlDataReader dr = (SqlDataReader)UserCenterDbHelper.ExecuteReader(cmdTxt);
        this.DDLDataBase.DataSource = dr;
        this.DDLDataBase.DataTextField = "name";
        this.DDLDataBase.DataBind();

        DDLDataBase.Items.Insert(0,new ListItem("-请选择-", "-1"));

        //扫描目中的bak文件
        string fullDirectory = System.Web.HttpContext.Current.Server.MapPath("~/Resource/DbBackup/");
        DirectoryInfo backFolder = new DirectoryInfo(fullDirectory);
        //遍历文件夹(子文件夹不予理睬)
        //DirectoryInfo[] dirInfo = TheFolder.GetDirectories();
        ////遍历文件夹
        //foreach (DirectoryInfo NextFolder in dirInfo)
        //    this.listBox1.Items.Add(NextFolder.Name);
        DDLFileName.Items.Clear();
        DDLFileName.Items.Add(new ListItem("-请选择-", "-1"));
        FileInfo[] fileInfo = backFolder.GetFiles("*.bak");
        //遍历文件
        foreach (FileInfo nextFile in fileInfo)
        {
            DDLFileName.Items.Add(new ListItem(nextFile.Name, nextFile.Name));
        }

    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
        if (DDLFileName.SelectedValue == "-1")
        {
            string errMsg = "<script>alert('提示信息：请选择需要还原的备份。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);
        }
        else
        {

            if (DDLDataBase.SelectedValue == "-1")
            {
                string errMsg = "<script>alert('提示信息：请选择需要还原的数据库。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);
            }
            else
            {
                string fullExpFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Resource/DbBackup/") + DDLFileName.SelectedValue.ToString();

                string cmdTxt = "use master restore database " + DDLDataBase.SelectedValue + " from disk='" + fullExpFilePath + "'";
                try
                {
                    UserCenterDbHelper.ExecuteNonQuery(cmdTxt);

                    string errMsg = "<script>alert('提示信息：还原数据库成功。');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);
                }
                catch (Exception ex)
                {
                    string errMsg = "<script>alert('提示信息：还原数据库失败，请联系管理员。');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "message", errMsg);

                }
            }
        }
    }
}