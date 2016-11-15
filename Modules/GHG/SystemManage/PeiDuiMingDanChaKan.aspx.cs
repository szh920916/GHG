using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_PeiDuiMingDanChaKan : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定数据;
            BindData();

        }

    }


    protected void BindData()
    {
        //where 企业组织机构代码='" + "888888" + "'"
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = null;
        if (UserInfo.RoleId == 10000016)
        {
            s = "select 企业组织机构代码,企业名称,核查机构代码,核查机构名称,年份 from View_PeiDuiMingDan where 核查机构代码='" + Session["UserName"].ToString() + "'";
           
        }
        else
        {
            s = "select 企业组织机构代码,企业名称,核查机构代码,核查机构名称,年份 from View_PeiDuiMingDan";
        }


        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();  //重新绑定GridView
    }
}