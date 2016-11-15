using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Modules_GHG_DataCollection_JianCeJiHuaShangChuan : System.Web.UI.Page
{
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn1 = new SqlConnection(strConn);
               
    protected void Page_Load(object sender, EventArgs e)
    {
        
            bool b = DateIsExist.IsExist("*", "Company", "QiYeZuZhiJiGouDaiMa", Session["UserName"].ToString());
            object o =DateIsExist.XIsExist("QiYeID", "Company", "QiYeZuZhiJiGouDaiMa", Session["UserName"].ToString());
            int QiYeID = Convert.ToInt32(o);
            bool b1 = DateIsExist.IsExist("*", "JianCeJiHua", "QiYeID", QiYeID.ToString());
            if (!b)//判断企业信息是否完善
            {
                //提示信息弹不出
                MessageBox("请完善企业信息");
                Response.Redirect(@"~\Modules\Common\UserAdmin\CompanyEdit.aspx");
            }


            else
            {
                if (DateIsExist.IsExist("Code","JianCeJiHua", "QiYeID", QiYeID.ToString(),"1"))
                {
                    int count = Convert.ToInt32(DateIsExist.XIsExist("Count", "JianCeJiHua", "QiYeID", QiYeID.ToString(), "Code", "1"));
                    if (b1 && count == 1)
                    {
                        Response.Write("<script>alert('已经上传，只允许查看!');location.href='JianCeJiHuaChaKan.aspx';</script>");
                        Response.End();
                    }
                    else
                    {
                       
                    }
                }

                int year = DateTime.Now.Year;// 取当前时间年                
                ListItem yearItem = null;
                //向过去的年份循环100年
                for (int i = year; i > year - 2000; i--)
                {
                    yearItem = new ListItem(i.ToString(), i.ToString());
                    DropDownList1.Items.Add(yearItem);//ddyear为下拉框id
                }

            }
       

        //}
        
    }
    protected void BtnUp_Click(object sender, EventArgs e)
    {
       
            if (FileUpload.PostedFile.FileName == string.Empty)
            {
                Response.Write("<script>alert('请选择要上传的文件！');</script>");
            }
            else
            {
                conn1.Open();
                string BZ = TextBox1.Text;
                string QiYeZuZhiJiGouDaiMa = Session["UserName"].ToString();
                string cmdtextQiYeID = "select QiYeID from Company where QiYeZuZhiJiGouDaiMa='" + QiYeZuZhiJiGouDaiMa + "'";
                SqlCommand cmdQiYeID = new SqlCommand(cmdtextQiYeID, conn1);
                int QiYeID =Convert.ToInt32(cmdQiYeID.ExecuteScalar().ToString());
                conn1.Close();
                //获取要上传的文件的信息
                string filepath = FileUpload.PostedFile.FileName;//文件路径
                string oldfilename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//文件名
                string FileExtension = Path.GetExtension(oldfilename); //文件的扩展名
                int filelength = (int)oldfilename.Length;//文件名长度
                string newfilename = QiYeZuZhiJiGouDaiMa + "-" + DateTime.Now.Year; 
                   
               
                string UpLoadName = DateTime.Now.Year.ToString();
                bool FileUploadPathExists = File.Exists(Server.MapPath("监测计划" + "\\" + UpLoadName+ "\\"+"初版"));
                bool FileUploadPathExists1 = File.Exists(Server.MapPath("监测计划" + "\\" + UpLoadName + "\\" + "终版"));
                //指定文件夹不存在，如果不存在就创建该文件夹
                if (!FileUploadPathExists)
                {
                    Directory.CreateDirectory(Server.MapPath("监测计划" + "\\" + UpLoadName + "\\" + "初版"));
                }
                if (!FileUploadPathExists1)
                {
                    Directory.CreateDirectory(Server.MapPath("监测计划" + "\\" + UpLoadName + "\\" + "终版"));
                }


                //保存上传的文件

                string savapath = Server.MapPath("监测计划" + "\\" + UpLoadName + "\\" + "初版");//保存路径

                string savapath3 = Server.MapPath("监测计划" + "\\" + UpLoadName + "\\" + "终版");//保存路径

                string savapath1 = "监测计划" + "\\" + UpLoadName + "\\" + "初版" + "\\" + newfilename;//保存路径

                string savapath2 = "监测计划" + "\\" + UpLoadName + "\\" + "终版" + "\\" + newfilename;//保存路径

                //FileUpload.PostedFile.SaveAs(savapath + "\\" + newfilename + "." + FileExtension);
                //连接数据库字符串
                
                DateTime TiJiaoShiJian=DateTime.Now;
                
                SqlConnection conn0 = new SqlConnection(strConn);
                conn0.Open();

                string cmdtext2 = "select count(*) from JianCeJiHua where Code='1' and QiYeID='" + QiYeID + "'";
                string cmdtext3 = "select count(*) from JianCeJiHua where Code='2' and QiYeID='" + QiYeID + "'";

                SqlCommand cmd0 = new SqlCommand(cmdtext2, conn0);
                SqlCommand cmd3 = new SqlCommand(cmdtext3, conn0);
                
                int count2 = int.Parse(cmd0.ExecuteScalar().ToString());
                int count3 = int.Parse(cmd3.ExecuteScalar().ToString());

                if (count2 > 0&&count3<=0)
                {
                    FileUpload.PostedFile.SaveAs(savapath3 + "\\" + newfilename  + FileExtension);
                    string cmdtext = "insert into JianCeJiHua(FileType,FilePath,Time,QiYeID,Code,BeiZhu,NianFen,Count) values('" + FileExtension + "','" + savapath2 + "','" + TiJiaoShiJian + "','" + QiYeID + "','" + '2' + "','" + BZ + "','" + DateTime.Now.Year.ToString() + "','" + '1' + "')";
                    SqlCommand cmd = new SqlCommand(cmdtext, conn0);
                    cmd.ExecuteNonQuery();
                }
                
                else if (count2 > 0 && count3 > 0)
                {
                    FileUpload.PostedFile.SaveAs(savapath3 + "\\" + newfilename  + FileExtension);
                    string cmdtext1 = "update JianCeJiHua set FileType='" + FileExtension + "', FilePath='" + savapath2 + "', Time= '" + TiJiaoShiJian + "',Code= '" + '2' + "', BeiZhu= '" + BZ + "',NianFen= '" + DateTime.Now.Year.ToString() + "' where Code='2' and QiYeID='" + QiYeID + "'";
                    SqlCommand cmd1 = new SqlCommand(cmdtext1, conn0);
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    FileUpload.PostedFile.SaveAs(savapath + "\\" + newfilename+ FileExtension);
                    string cmdtext = "insert into JianCeJiHua(FileType,FilePath,Time,QiYeID,Code,BeiZhu,NianFen,Count) values('" + FileExtension + "','" + savapath1 + "','" + TiJiaoShiJian + "','" + QiYeID + "','" + '1' + "','" + BZ + "','" + DateTime.Now.Year.ToString() + "','" + '1' + "')";
                    SqlCommand cmd = new SqlCommand(cmdtext, conn0);
                    cmd.ExecuteNonQuery();
                }
                
                try
                {
                    System.Text.StringBuilder strMsg = new System.Text.StringBuilder();
                    strMsg.Append("<font color=green>文件上传成功<br>");
                }
                catch (Exception error)
                {
                    Response.Write(error.ToString());
                }
                finally
                {
                    conn0.Close();
                }
                Session["FileType"] = FileExtension;
                Response.Write("<script>alert('上传成功，请查看!');location.href='JianCeJiHuaChaKan.aspx';</script>");
            }

    }
    protected void MessageBox(string str)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str + "');</script>");
    }

}