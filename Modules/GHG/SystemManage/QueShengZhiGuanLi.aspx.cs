using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_QueShengZhiGuanLi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DropDownList1.Items.Insert(0, new ListItem("--请选择--"));
            BindDr1();
            bindData();
        }
       
    }

    //绑定行业表
    protected void BindDr1()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select HangYeMingCheng from HangYe";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        }
        conn.Close();
    }

    protected void bindData()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
            string s = "select ID,HangYeBianHao, RanLiaoID,DiWeiFaReZhi,DanWeiReZhiHanTanLiang,TanYangHuaLv,DanWei from TaoCi_QueShengZhi ";

            SqlDataAdapter sda = new SqlDataAdapter(s, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
       
        conn.Close();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindData();  //重新绑定GridView
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindData();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        string sqlstr = "delete from TaoCi_QueShengZhi where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(sqlstr, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.DataBind();
        bindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);

        string sqlstr = "update TaoCi_QueShengZhi set DiWeiFaReZhi='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim() + "',DanWeiReZhiHanTanLiang='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim() + "',TanYangHuaLv='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim() + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";

        conn.Open();

        SqlCommand sqlcom = new SqlCommand(sqlstr, conn);

        sqlcom.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        bindData();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string HangYeBianHao =Convert.ToString( DateIsExist.XIsExist("HangYeBianHao", "HangYe", "HangYeMingCheng", this.DropDownList1.SelectedValue.ToString()));

         string s = "select ID,HangYeBianHao, RanLiaoID,DiWeiFaReZhi,DanWeiReZhiHanTanLiang,TanYangHuaLv,DanWei from TaoCi_QueShengZhi where HangYeBianHao='" + HangYeBianHao + "'";

        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "id" };//主键
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //bindData();
    }
}