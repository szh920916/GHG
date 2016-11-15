using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.IO;

public partial class Modules_GHG_DataCollection_TaoCi_HeChaBaoGaoShangChuan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList3.Items.Insert(0, "--请选择--");

        bool b = DateIsExist.IsExist("*", "HeChaJiGou", "HeChaJiGouDaiMa", Session["UserName"].ToString());

        if (!b)//判断企业信息是否完善
        {
            //提示信息弹不出
            Response.Write("<script language='JavaScript'>alert('请先完善信息');</script>");
            Response.Redirect(@"~\Modules\Common\UserAdmin\HeChaJiGouEdit.aspx");
        }


        int year = DateTime.Now.Year;// 取当前时间年                
        ListItem yearItem = null;
        //向过去的年份循环100年
        for (int i = year; i > year - 100; i--)
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




    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s1 = DropDownList3.Text;
        string cmdtext1 = "select QiYeMingCheng from Company where  QiYeZuZhiJiGouDaiMa='" + s1 + "'";
        SqlCommand cmd = new SqlCommand(cmdtext1, conn);
        string s2 = cmd.ExecuteScalar().ToString();
        TextBox2.Text = s2;
        conn.Close();
    }



    protected void BtnUp_Click(object sender, EventArgs e)
    {
        if (FileUpload.PostedFile.FileName == string.Empty)
        {
            Response.Write("<script>alert('请选择要上传的文件！');</script>");
        }
        else
        {

            string BZ = TextBox3.Text;
            string HeChaJiGouDaiMa = Session["UserName"].ToString();
            string HeChaJiGouMingCheng = Convert.ToString(DateIsExist.XIsExist("HeChaJiGouMingCheng", "HeChaJiGou", "HeChaJiGouDaiMa", HeChaJiGouDaiMa));
            string QiYeZuZhiJiGouDaiMa = DropDownList3.Text;
            string QiYeMingCheng = TextBox2.Text;
            string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmdQiYeID = "select QiYeID from Company where  QiYeZuZhiJiGouDaiMa='" + QiYeZuZhiJiGouDaiMa + "'";
            string cmdJiGouBianHao = "select JiGouBianHao from HeChaJiGou where  HeChaJiGouDaiMa='" + HeChaJiGouDaiMa + "'";
            SqlCommand sql1 = new SqlCommand(cmdQiYeID, conn);
            int QiYeID = Convert.ToInt32(sql1.ExecuteScalar().ToString());
            SqlCommand sql2 = new SqlCommand(cmdJiGouBianHao, conn);
            string JiGouBianHao = sql2.ExecuteScalar().ToString();


            //获取要上传的文件的信息
            string filepath = FileUpload.PostedFile.FileName;//文件路径
            string oldfilename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//文件名
            string FileExtension = Path.GetExtension(oldfilename); //文件的扩展名


            string newfilename = HeChaJiGouDaiMa + "-" + QiYeZuZhiJiGouDaiMa.ToString().Trim() + "-" + DateTime.Now.Year.ToString();

            string UpLoadName = DateTime.Now.Year.ToString();
            bool FileUploadPathExists = File.Exists(Server.MapPath("核查报告" + "\\" + UpLoadName + "\\" + "初版"));
            //指定文件夹不存在，如果不存在就创建该文件夹
            if (!FileUploadPathExists)
            {
                Directory.CreateDirectory(Server.MapPath("核查报告" + "\\" + UpLoadName + "\\" + "初版"));
            }


            //保存上传的文件

            string savapath = Server.MapPath("核查报告" + "\\" + UpLoadName + "\\" + "初版");//保存路径

            string savapath3 = Server.MapPath("核查报告" + "\\" + UpLoadName + "\\" + "终版");//保存路径

            string savapath1 = "核查报告" + "\\" + UpLoadName + "\\" + "初版" + "\\" + newfilename;//保存路径

            string savapath2 = "核查报告" + "\\" + UpLoadName + "\\" + "终版" + "\\" + newfilename;//保存路径

            FileUpload.PostedFile.SaveAs(savapath + "\\" + newfilename);

            DateTime FileTime = DateTime.Now;

            string cmdtext2 = "select count(*) from HeChaBaoGao where Code='1' and JiGouBianHao='" + JiGouBianHao + "'and QiYeID='" + QiYeID + "'";
            string cmdtext3 = "select count(*) from HeChaBaoGao where Code='2' and JiGouBianHao='" + JiGouBianHao + "'and QiYeID='" + QiYeID + "'";
            SqlCommand cmd2 = new SqlCommand(cmdtext2, conn);
            SqlCommand cmd3 = new SqlCommand(cmdtext3, conn);

            int count2 = (int)cmd2.ExecuteScalar();
            int count3 = (int)cmd3.ExecuteScalar();

            if (count2 > 0 && count3 <= 0)
            {
                FileUpload.PostedFile.SaveAs(savapath3 + "\\" + newfilename + FileExtension);
                string cmdtext = "insert into HeChaBaoGao(JiGouBianHao,QiYeID,FileType,FilePath,NianFen,Time,BeiZhu,Code) values('" + JiGouBianHao + "','" + QiYeID + "','" + FileExtension + "','" + savapath2 + "','" + DateTime.Now.Year.ToString() + "','" + FileTime + "' ,'" + BZ + "','" + '2' + "' )";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.ExecuteNonQuery();
            }
            else if (count2 > 0 && count3 > 0)
            {
                FileUpload.PostedFile.SaveAs(savapath3 + "\\" + newfilename + FileExtension);
                string cmdtext = "update HeChaBaoGao set JiGouBianHao='" + JiGouBianHao + "', QiYeID='" + QiYeID + "', Code= '" + '2' + "', BeiZhu= '" + BZ + "', FileType='" + FileExtension + "', FilePath= '" + savapath2 + "',NianFen= '" + DateTime.Now.Year.ToString() + "', Time= '" + FileTime + "' where Code='2' and JiGouBianHao='" + JiGouBianHao + "'";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.ExecuteNonQuery();

            }
            else
            {
                FileUpload.PostedFile.SaveAs(savapath + "\\" + newfilename + FileExtension);
                string cmdtext = "insert into HeChaBaoGao(JiGouBianHao,QiYeID,FileType,FilePath,NianFen,Time,BeiZhu,Code) values('" + JiGouBianHao + "','" + QiYeID + "','" + FileExtension + "','" + savapath1 + "','" + DateTime.Now.Year.ToString() + "','" + FileTime + "','" + BZ + "','" + '1' + "')";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.ExecuteNonQuery();
            }
            try
            {
                Response.Write("<script>alert('上处成功！');</script>");
            }
            catch (Exception error)
            {
                Response.Write(error.ToString());
            }
            finally
            {
                conn.Close();
            }
            Response.Write("<script>alert('上传成功，请查看!');location.href='HeChaBaoGaoChaKan.aspx';</script>");
        }
    }

}