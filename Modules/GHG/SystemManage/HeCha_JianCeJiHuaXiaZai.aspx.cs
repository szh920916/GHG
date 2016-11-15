using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_HeCha_JianCeJiHuaXiaZai : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList3.Items.Insert(0,"--请选择--");
        bool b = DateIsExist.IsExist("*", "HeCHaJiGou", "HeChaQiYeZuZhiJiGouDaiMa", Session["UserName"].ToString());
        if (!b)
        {
            //提示信息弹不出
            Response.Write("<script language='JavaScript'>alert('请先完善信息');</script>");
            Response.Redirect(@"~\Modules\Common\UserAdmin\HeChaJiGouEdit.aspx");
        }
        else
        {
            int year = DateTime.Now.Year;// 取当前时间年                
            ListItem yearItem = null;

            //向过去的年份循环100年
            for (int i = year; i > year - 10; i--)
            {
                yearItem = new ListItem(i.ToString(), i.ToString());
                DropDownList1.Items.Add(yearItem);//ddyear为下拉框id
            }

        }

        DrDataBind();
        
    }

    protected void DrDataBind()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select 企业名称 from PeiDuiMingDanView where 核查机构代码='" + Session["UserName"].ToString() + "'";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        
        try
        {

            string QiYeZuZhiJiGouDaiMa = Session["UserName"].ToString();
            string Nian = DropDownList1.SelectedValue.ToString();
            string s = DropDownList2.SelectedValue.ToString();
            string p = QiYeZuZhiJiGouDaiMa + "-" + DateTime.Now.Year;
            string path = Server.MapPath("监测计划" + "\\" + Nian + "\\" + s + "\\" + p);

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(p));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度
            Response.AddHeader("Content-Length", file.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载
            Response.ContentType = "application/ms-excel";
            // 把文件流发送到客户端
            Response.WriteFile(file.FullName);
            // 停止页面的执行
            //Response.End();     
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('系统出现以下错误://n" + ex.Message + "!//n请尽快与管理员联系.')</script>");
        }
    }
}