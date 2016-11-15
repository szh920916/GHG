//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2016 , Rising , Ltd .
//-------------------------------------------------------------------------------------

using System;
using System.Data;

namespace GHG.Model
{
  using DotNet.Utilities;

 /// <summary>
 /// CompanyEntity
 /// 企业表
 ///
 /// 修改纪录
 ///
 ///		2016-10-08 版本：1.0  创建主键。
 ///
 /// 版本：1.0
 ///
 /// <author>
 ///		<name></name>
 ///		<date>2016-10-08</date>
 /// </author>
 /// </summary>
 [Serializable]
 public class CompanyEntity
 {
  private int? qiYeID = 0;
  /// <summary>
  /// 
  /// </summary>
  public int? QiYeID
  {
      get
      {
          return this.qiYeID;
      }
      set
      {
          this.qiYeID = value;
      }
  }

  private String qiYeZuZhiJiGouDaiMa = null;
  /// <summary>
  /// 
  /// </summary>
  public String QiYeZuZhiJiGouDaiMa
  {
      get
      {
          return this.qiYeZuZhiJiGouDaiMa;
      }
      set
      {
          this.qiYeZuZhiJiGouDaiMa = value;
      }
  }

  private int? suoshudishixian = 0;
  /// <summary>
  /// 
  /// </summary>
  public int? DiShiBianHao
  {
      get
      {
          return this.suoshudishixian;
      }
      set
      {
          this.suoshudishixian = value;
      }
  }

  private int? hangYeBianHao = 0;
  /// <summary>
  /// 行业编号
  /// </summary>
  public int? HangYeBianHao
  {
      get
      {
          return this.hangYeBianHao;
      }
      set
      {
          this.hangYeBianHao = value;
      }
  }

  private String qiYeMingCheng = null;
  /// <summary>
  /// 
  /// </summary>
  public String QiYeMingCheng
  {
      get
      {
          return this.qiYeMingCheng;
      }
      set
      {
          this.qiYeMingCheng = value;
      }
  }

  private String xiangXiDiZhi = null;
  /// <summary>
  /// 
  /// </summary>
  public String XiangXiDiZhi
  {
      get
      {
          return this.xiangXiDiZhi;
      }
      set
      {
          this.xiangXiDiZhi = value;
      }
  }

  private String lianXiRen = null;
  /// <summary>
  /// 
  /// </summary>
  public String LianXiRen
  {
      get
      {
          return this.lianXiRen;
      }
      set
      {
          this.lianXiRen = value;
      }
  }

  private String lianXiDianHua = null;
  /// <summary>
  /// 
  /// </summary>
  public String LianXiDianHua
  {
      get
      {
          return this.lianXiDianHua;
      }
      set
      {
          this.lianXiDianHua = value;
      }
  }

  private String qiYeFaRen = null;
  /// <summary>
  /// 
  /// </summary>
  public String QiYeFaRen
  {
      get
      {
          return this.qiYeFaRen;
      }
      set
      {
          this.qiYeFaRen = value;
      }
  }

  private String tongXinDiZhi = null;
  /// <summary>
  /// 
  /// </summary>
  public String TongXinDiZhi
  {
      get
      {
          return this.tongXinDiZhi;
      }
      set
      {
          this.tongXinDiZhi = value;
      }
  }

  private String youBian = null;
  /// <summary>
  /// 
  /// </summary>
  public String YouBian
  {
      get
      {
          return this.youBian;
      }
      set
      {
          this.youBian = value;
      }
  }

  /// <summary>
  /// 构造函数
  /// </summary>
  public CompanyEntity()
  {
  }

  /// <summary>
  /// 构造函数
  /// </summary>
  /// <param name="dataRow">数据行</param>
  public CompanyEntity(DataRow dataRow)
  {
      this.GetFrom(dataRow);
  }

  /// <summary>
  /// 构造函数
  /// </summary>
  /// <param name="dataReader">数据流</param>
  public CompanyEntity(IDataReader dataReader)
  {
      this.GetFrom(dataReader);
  }

  /// <summary>
  /// 构造函数
  /// </summary>
  /// <param name="dataTable">数据表</param>
  public CompanyEntity(DataTable dataTable)
  {
      this.GetFrom(dataTable);
  }

  /// <summary>
  /// 从数据表读取
  /// </summary>
  /// <param name="dataTable">数据表</param>
  public CompanyEntity GetFrom(DataTable dataTable)
  {
      if ((dataTable == null) || (dataTable.Rows.Count == 0))
      {
          return null;
      }
      foreach (DataRow dataRow in dataTable.Rows)
      {
          this.GetFrom(dataRow);
          break;
      }
      return this;
  }

  /// <summary>
  /// 从数据行读取
  /// </summary>
  /// <param name="dataRow">数据行</param>
  public CompanyEntity GetFrom(DataRow dataRow)
  {
      this.QiYeID = BaseBusinessLogic.ConvertToInt(dataRow[CompanyTable.FieldQiYeID]);
      this.QiYeZuZhiJiGouDaiMa = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldQiYeZuZhiJiGouDaiMa]);
      this.DiShiBianHao = BaseBusinessLogic.ConvertToInt(dataRow[CompanyTable.FieldDiShiBianHao]);
      this.HangYeBianHao = BaseBusinessLogic.ConvertToInt(dataRow[CompanyTable.FieldHangYeBianHao]);
      this.QiYeMingCheng = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldQiYeMingCheng]);
      this.XiangXiDiZhi = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldXiangXiDiZhi]);
      this.LianXiRen = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldLianXiRen]);
      this.LianXiDianHua = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldLianXiDianHua]);
      this.QiYeFaRen = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldQiYeFaRen]);
      this.TongXinDiZhi = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldTongXinDiZhi]);
      this.YouBian = BaseBusinessLogic.ConvertToString(dataRow[CompanyTable.FieldYouBian]);
      return this;
  }

  /// <summary>
  /// 从数据流读取
  /// </summary>
  /// <param name="dataReader">数据流</param>
  public CompanyEntity GetFrom(IDataReader dataReader)
  {
      this.QiYeID = BaseBusinessLogic.ConvertToInt(dataReader[CompanyTable.FieldQiYeID]);
      this.QiYeZuZhiJiGouDaiMa = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldQiYeZuZhiJiGouDaiMa]);
      this.DiShiBianHao = BaseBusinessLogic.ConvertToInt(dataReader[CompanyTable.FieldDiShiBianHao]);
      this.HangYeBianHao = BaseBusinessLogic.ConvertToInt(dataReader[CompanyTable.FieldHangYeBianHao]);
      this.QiYeMingCheng = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldQiYeMingCheng]);
      this.XiangXiDiZhi = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldXiangXiDiZhi]);
      this.LianXiRen = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldLianXiRen]);
      this.LianXiDianHua = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldLianXiDianHua]);
      this.QiYeFaRen = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldQiYeFaRen]);
      this.TongXinDiZhi = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldTongXinDiZhi]);
      this.YouBian = BaseBusinessLogic.ConvertToString(dataReader[CompanyTable.FieldYouBian]);
      return this;
  }
  }
}
