//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Zhengzhou Rising Software Technology Co., Ltd .
//------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Utilities;
using DotNet.Model;

/// <remarks>
/// LeftSubMenu
/// 左边子菜单
///
/// 修改记录
/// 
///		2009.11.23 版本：1.0 JiRiGaLa 优化菜单速度，不产生树型结构，没必要打开数据库。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.11.23</date>
/// </author>
/// </remarks>
public partial class LeftSubMenu : BasePage
{
    /// <summary>
    /// 加载菜单的编号
    /// </summary>
    private string ModuleCode = string.Empty;

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["ModuleCode"] != null)
        {
            this.ModuleCode = Page.Request["ModuleCode"].ToString();
        }
        else
        {
            this.ModuleCode = BaseSystemInfo.RootMenuCode;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetParamter();
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // this.UserCenterDbHelper.Open();
        this.LoadModules();
        // this.UserCenterDbHelper.Close();
    }
    #endregion

    #region private void LoadModules()
    /// <summary>
    /// 加载模块树的代码
    /// </summary>
    private void LoadModules()
    {
        string moduleId = BaseBusinessLogic.GetProperty(this.DTModule, BaseModuleTable.FieldCode, this.ModuleCode, BaseModuleTable.FieldId);
        DataRow[] dataRows = this.DTModule.Select(BaseModuleTable.FieldParentId + "='" + moduleId + "'", BaseModuleTable.FieldSortCode);
        for (int i = 0; i < dataRows.Length; i++)
        {

            TreeNode treeNode = new TreeNode();

            treeNode.Value = dataRows[i][BaseModuleTable.FieldId].ToString();
            string s = treeNode.Value;
            treeNode.Text = dataRows[i][BaseModuleTable.FieldFullName].ToString();
            treeNode.Target = dataRows[i][BaseModuleTable.FieldTarget].ToString();
            treeNode.Expanded = dataRows[i][BaseModuleTable.FieldExpand].ToString().Equals("1");
            treeNode.NavigateUrl = dataRows[i][BaseModuleTable.FieldNavigateUrl].ToString();
            // 树型结构不要生成，否则速度会比较慢一些
            // this.LoadModules(treeNode);
            this.tvModules.Nodes.Add(treeNode);

        }
    }
    #endregion

    private void LoadModules(TreeNode treeNode)
    {
        DataRow[] dataRows = this.DTModule.Select(BaseModuleTable.FieldParentId + "='" + treeNode.Value + "'", BaseModuleTable.FieldSortCode);
        for (int i = 0; i < dataRows.Length; i++)
        {
            TreeNode subTreeNode = new TreeNode();
            subTreeNode.Value = dataRows[i][BaseModuleTable.FieldId].ToString();
            subTreeNode.Text = dataRows[i][BaseModuleTable.FieldFullName].ToString();
            subTreeNode.Target = dataRows[i][BaseModuleTable.FieldTarget].ToString();
            subTreeNode.Expanded = dataRows[i][BaseModuleTable.FieldExpand].ToString().Equals("1");
            subTreeNode.NavigateUrl = dataRows[i][BaseModuleTable.FieldNavigateUrl].ToString();
            treeNode.ChildNodes.Add(subTreeNode);
            this.LoadModules(subTreeNode);
        }
    }
}