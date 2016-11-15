using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_QiYeHeSuanFangFa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            //绑定数据;
            bind();
        }
    }

     
    protected void bind()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
       
        conn.Open();
        string s = "select id, HangYeBianHao,JiSuanGongShi from TaoCi_JiSuanGongShi ";

        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "id" };//主键
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        string s = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string sqlstr = "delete from TaoCi_JiSuanGongShi where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(sqlstr,conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.DataBind();
        bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        //object s = GridView1.Rows[e.RowIndex].Cells[3].Controls[0];

        string sqlstr = "update TaoCi_JiSuanGongShi set JiSuanGongShi='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";

        conn.Open();

        SqlCommand sqlcom = new SqlCommand(sqlstr, conn);
      
        sqlcom.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddQiYeHeSuanFangFa.aspx");
        //GridViewRow rowseparator = new GridViewRow(0, 0, DataControlRowType.Separator, DataControlRowState.Normal);

        //for (int i = 0; i < GridView1.Rows[0].Cells.Count; i++)
        //{

        //    TableCell separatorcell = new TableCell();
        //    separatorcell.ColumnSpan = 0;
        //    if (i == 0)
        //    {
        //        CheckBox ckb = new CheckBox();
        //        separatorcell.Controls.Add(ckb);
        //        rowseparator.Cells.Add(separatorcell);
        //    }
        //    if (i == 1)
        //    {
        //        TextBox txt = new TextBox();
        //        separatorcell.Controls.Add(txt);
        //        rowseparator.Cells.Add(separatorcell);
        //    }
        //    if (i == 2)
        //    {
        //        TextBox txt = new TextBox();
        //        separatorcell.Controls.Add(txt);
        //        rowseparator.Cells.Add(separatorcell);
        //    }

        //}
        //rowseparator.Visible = true;

        //GridView1.Controls[0].Controls.AddAt(GridView1.Rows.Count + 1, rowseparator);


        
    }
}