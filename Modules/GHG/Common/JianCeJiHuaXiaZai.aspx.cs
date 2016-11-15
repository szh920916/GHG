using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Modules_GHG_DataCollection_TaoCi_JianCeJiHuaXiaZai : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool b = DateIsExist.IsExist("*", "Company", "QiYeZuZhiJiGouDaiMa", Session["UserName"].ToString());
        if (!b)
        {
            MessageBox("请先完善信息");
            //提示信息弹不出
            MessageBox("请先完善企业信息");
            Response.Redirect(@"~\Modules\Common\UserAdmin\CompanyEdit.aspx");

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
        

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            string QiYeZuZhiJiGouDaiMa = Session["UserName"].ToString();
            string Nian = DropDownList1.SelectedValue.ToString();
            string s = DropDownList2.SelectedValue.ToString();
            string p = QiYeZuZhiJiGouDaiMa + "-" + DateTime.Now.Year;
            int QiYeID = Convert.ToInt32(DateIsExist.XIsExist("QiYeID", "Company", "QiYeZuZhiJiGouDaiMa", QiYeZuZhiJiGouDaiMa));
            bool b = DateIsExist.IsExist("*", "JianCeJiHua", "QiYeID", QiYeID.ToString());
            bool b1 = DateIsExist.IsExist("FilePath", "JianCeJiHua", "QiYeID", QiYeID.ToString(), "监测计划" + @"\" + Nian + @"\" + s + @"\" + p);
            if (!b||!b1)
            {
                Response.Write("<script>alert('文件不存在！')</script>");
                return;
            }
            else
            {

                string FileType = DateIsExist.XIsExist("FileType", "JianCeJiHua", "QiYeID", QiYeID.ToString()).ToString();
                //string filetype=Session["FileType"].ToString();
                string fileURL = this.Server.MapPath("./监测计划/" + Nian + "/" + s + "/" + p + FileType + "");//文件路径，可用相对路径
                FileInfo fileInfo = new FileInfo(fileURL);
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(fileInfo.Name.ToString()));//文件名
                
                Response.AddHeader("content-length", fileInfo.Length.ToString());//文件大小
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.WriteFile(fileURL);
            }
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('文件不存在！//n" + ex.Message + "!//n,请检查版本号.')</script>");
        }
        
       
    }

    protected void MessageBox(string str)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str + "');</script>");
    }
}