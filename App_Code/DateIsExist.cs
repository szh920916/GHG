using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;

/// <summary>
///DateIsExist 的摘要说明
/// </summary>
public class DateIsExist
{
    /// <summary>
    /// 判断是否包含一个值
    /// </summary>
    /// <param name="SelectItem"></param>
    /// <param name="TableName"></param>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    //public static bool IsExist(string SelectItem, string TableName, string Key, string Value,string target)
    //{
    //        SqlConnection conn = new SqlConnection("server=.;uid=sa;pwd=920916;database=GHG2");
           
    //        string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key + " ='" + Value + "'";
    //        DataTable dt = new DataTable();
    //        List<string> ls = new List<string>();
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand(sql, conn);
    //        SqlDataReader sdr = cmd.ExecuteReader();
    //        dt.Load(sdr);
    //        sdr.Close();
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            for (int j = 0; j < dt.Columns.Count; j++)
    //            {
    //                ls.Add(dt.Rows[i][j].ToString());
    //            }
    //        }

    //        bool s1 = ls.Contains(target);
    //        return s1;
        
    //}

    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    /// <summary>
    /// 查询语句,判断某个数据是否存在
    /// </summary>
    /// <param name="SelectItem">查询项</param>
    /// <param name="TableName">表名</param>
    /// <param name="Key">项</param>
    /// <param name="Value">值</param>
    /// <returns></returns>
    public static bool IsExist(string SelectItem, string TableName, string Key, string Value,string target)
    {
        SqlConnection conn = new SqlConnection(strConn);
           
            string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key + " ='" + Value + "'";
            DataTable dt = new DataTable();
            List<string> ls = new List<string>();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ls.Add(dt.Rows[i][j].ToString());
                }
            }

            bool s1 = ls.Contains(target);
            return s1;
        
    }

    /// <summary>
    /// 判断记录是否存在，判断一条记录是否存在
    /// </summary>
    /// <param name="SelectItem"></param>
    /// <param name="TableName"></param>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static bool IsExist(string SelectItem, string TableName, string Key, string Value)
    {
        SqlConnection conn = new SqlConnection(strConn);

        string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key + " ='" + Value + "'";
        DataTable dt = new DataTable();
        
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        sdr.Close();
        conn.Close();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            return true;
        }

        return false;
      
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SelectItem"></param>
    /// <param name="TableName"></param>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    /// <param name="Key2"></param>
    /// <param name="Value1"></param>
    /// <returns></returns>
    public static bool IsExist(string SelectItem, string TableName, string Key, string Value,string Key1,string Value1,string Key2,string Value2)
    {
        SqlConnection conn = new SqlConnection(strConn);

        string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key + " ='" + Value + "' and " + Key1 + " ='" + Value1 + "' and " + Key2 + " ='" + Value2 + "'";
        DataTable dt = new DataTable();

        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        sdr.Close();
        conn.Close();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            return true;
        }

        return false;

    }




   /// <summary>
   /// 取数据库中的值
   /// </summary>
   /// <param name="SelectItem"></param>
   /// <param name="TableName"></param>
   /// <param name="Key1"></param>
   /// <param name="Value1"></param>
   /// <param name="Key2"></param>
   /// <param name="Value2"></param>
   /// <returns></returns>
    public static object XIsExist(string SelectItem, string TableName, string Key1, string Value1,string Key2,string Value2)
    {

        SqlConnection conn = new SqlConnection(strConn);
      
        string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key1 + " ='" + Value1 + "' and " + Key2 + " ='" + Value2 + "' ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        object selectItem = cmd.ExecuteScalar();
        conn.Close();
        return selectItem;

    }


    public static object XIsExist(string SelectItem, string TableName, string Key1, string Value1)
    {

        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key1 + " ='" + Value1 + "' ";
        SqlCommand cmd = new SqlCommand(sql, conn);

        object selectItem = cmd.ExecuteScalar().ToString();
        conn.Close();
        return selectItem;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="SelectItem"></param>
    /// <param name="TableName"></param>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    /// <returns></returns>
    //public static bool isExit(string SelectItem, string TableName, string Key, string Value)
    //{

    //    SqlConnection conn = new SqlConnection("server=.;uid=sa;pwd=920916;database=GHG2");
    //    conn.Open();
    //    string sql = "select  " + SelectItem + "  from  " + TableName + " where  " + Key + " ='" + Value + "'";
    //    SqlCommand cmd = new SqlCommand(sql, conn);
    //    SqlDataReader mysdr = cmd.ExecuteReader();
    //    if (mysdr.HasRows)
    //    {
    //        return true;
    //    }

    //    mysdr.Close();

    //    conn.Close();
    //    return false;

    //}

    //public bool IsExists(string SelectItem, string TableName, string Key1, string Value1)
    //{
    //    SqlConnection conn = new SqlConnection(strConn);
    //    bool flag = false;

    //    string sql = "select SelectItem from TableName where Key1='" + Value1 + "'";
    //    DataTable dt = new DataTable();
    //    conn.Open();
    //    SqlCommand cmd = new SqlCommand(sql, conn);
    //    SqlDataReader sdr = cmd.ExecuteReader();
    //    dt.Load(sdr);
    //    sdr.Close();
    //    //conn.Close();
    //    if (dt.Rows.Count > 0)
    //    {
    //        flag = true;
    //    }
    //    return flag;
    //}
}