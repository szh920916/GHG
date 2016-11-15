using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_DataCollection_TaoCi_JianCeJiHuaChaKan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定数据;
            BindData();
        }
    }

    //QiYeMingCheng,FilePath,TiJiaoShiJian,BeiZhu
    protected void BindData()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select 企业名称,文件位置,提交时间,备注 from View_JianCeJiHua where 企业组织机构代码='" + Session["UserName"] + "'";

        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

}