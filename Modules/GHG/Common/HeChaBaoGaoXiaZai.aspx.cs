using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Modules_GHG_DataCollection_TaoCi_HeChaBaoGaoXiaZai : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList3.Items.Insert(0, "--请选择--");
        int year = DateTime.Now.Year;// 取当前时间年                
        ListItem yearItem = null;

        //向过去的年份循环100年
        for (int i = year; i > year - 10; i--)
        {
            yearItem = new ListItem(i.ToString(), i.ToString());
            DropDownList1.Items.Add(yearItem);//ddyear为下拉框id
        }

        drDataBing();

    }



    protected void drDataBing()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select 企业组织机构代码 from View_PeiDuiMingDan where 核查机构代码='" + Session["UserName"].ToString() + "'";
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
        
            string QiYeZuZhiJiGouDaiMa = this.DropDownList3.Text.ToString();
            string HeChaJiGouDaiMa = Session["UserName"].ToString().Trim();
            string NianFen = DropDownList1.SelectedValue.ToString();
            string BanBen = DropDownList2.SelectedValue.ToString();
            string p = HeChaJiGouDaiMa + "-" + QiYeZuZhiJiGouDaiMa.Trim() + "-" + DateTime.Now.Year.ToString();
            string path = Server.MapPath("核查报告" + "\\" + NianFen + "\\" + BanBen + "\\" + p);
            //string Nian = DropDownList1.SelectedValue.ToString();
            //string s = DropDownList2.SelectedValue.ToString();
            //string p = QiYeZuZhiJiGouDaiMa + "-" + DateTime.Now.Year;
            int QiYeID = Convert.ToInt32(DateIsExist.XIsExist("QiYeID", "Company", "QiYeZuZhiJiGouDaiMa", QiYeZuZhiJiGouDaiMa));
            bool b = DateIsExist.IsExist("*", "HeChaBaoGao", "QiYeID", QiYeID.ToString());
            bool b1 = DateIsExist.IsExist("FilePath", "HeChaBaoGao", "QiYeID", QiYeID.ToString(), "核查报告" + @"\" + NianFen + @"\" + BanBen + @"\" + p);
           
            if (!b||!b1)
            {
                Response.Write("<script>alert('文件不存在！')</script>");
            }
            else
            {
                string FileType = DateIsExist.XIsExist("FileType", "HeChaBaoGao", "QiYeID", QiYeID.ToString()).ToString();
                //string filetype=Session["FileType"].ToString();
                string fileURL = this.Server.MapPath("./核查报告/" + NianFen + "/" + BanBen + "/" + p + FileType + "");//文件路径，可用相对路径
                FileInfo fileInfo = new FileInfo(fileURL);
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(fileInfo.Name.ToString()));//文件名
                Response.AddHeader("content-length", fileInfo.Length.ToString());//文件大小
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.WriteFile(fileURL);
            }
        }
    
}