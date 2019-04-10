using Ext.Net;
using IEMS.Frame.WebUI;
using IEMS.Frame.WebUI.Entity;
using IEMS.JHWMS.AppBiz;
using IEMS.JHWMS.Entity;
using System;
using System.Collections.Generic;

public partial class Plugins_JHWMS_EquipManager_ManipulatorEnable : IEMS.JHWMS.WebUI.Page
{
    #region 权限定义
    protected __ _ = new __();
    public class __ : IEMS.Frame.WebUI.___   //必须继承___   //Action不能重复，重复会被覆盖
    {
        public __()
        {
            堆垛机管理 = new PageAction() { ActionId = 1, ActionName = "堆垛机管理" };
        }
        public PageAction 堆垛机管理 { get; private set; } //必须为 public
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            IniPageFieldData();
        }
    }

    private void IniPageFieldData()
    {
        

    }

    /// <summary>
    /// 行数据信息
    /// </summary>
    [DirectMethod]
    public object GridPanelBindData(string action, Dictionary<string, object> extraParams)
    {
        try
        {
            var manager = AppBizFactory.CreateInstance<IPsbEquipManager>();
            var data = manager.GetDataTable();
            var total = data.Rows.Count;
            return new { data = data, total };
        }
        catch (Exception ex)
        {
            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示",
                Message = ex.Message.ToString(),
                Icon = MessageBox.Icon.WARNING
            });
        }
        return null;
    }

    /// <summary>
    /// 设置入库
    /// </summary>
    [DirectMethod]
    public string ChangeEnable(string equipNo, string enable)
    {
        try
        {
            var flag = 0;
            int.TryParse(enable, out flag);
            if (flag == 0)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
            var manager = AppBizFactory.CreateInstance<IPsbEquipManager>();
            manager.SetEnable(equipNo, flag);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return string.Empty;
    }

   


   
}