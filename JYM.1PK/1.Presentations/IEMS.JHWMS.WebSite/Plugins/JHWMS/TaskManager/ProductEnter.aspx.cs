using Ext.Net;
using IEMS.Frame.WebUI.Entity;
using IEMS.JHWMS.AppBiz;
using IEMS.JHWMS.Entity;
using IEMS.Frame.WebUI;
using MSTL.McJson;
using System;
using System.Collections.Generic;
using MSTL.DbAccess;
using System.Collections;
using MSTL.ResultStruct.McException;
using System.Data;
using IEMS.JHWMS.DbCI;


public partial class Plugins_JHWMS_TaskManager_ProductEnter : IEMS.JHWMS.WebUI.Page
{
    #region 权限定义
    protected __ _ = new __();
    public class __ : IEMS.Frame.WebUI.___   //必须继承___   //Action不能重复，重复会被覆盖
    {
        public __()
        {
            查询任务信息 = new PageAction() { ActionId = 1, ActionName = "btnSearch" };
            强制取消 = new PageAction() { ActionId = 2, ActionName = "btnCancel" };
            强制完成 = new PageAction() { ActionId = 3, ActionName = "btnComplete" };
        }
        public PageAction 查询任务信息 { get; private set; } //必须为 public
        public PageAction 强制取消 { get; private set; } //必须为 public
        public PageAction 强制完成 { get; private set; } //必须为 public
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
      
        var taskManager = IEMS.JHWMS.AppBiz.AppBizFactory.CreateInstance<IProductEnterManager>();
        //查询业务信息
        PsbBinArea bizType = new PsbBinArea();
        setBinArea(this.txtAddBinArea, taskManager.GetBinAreaTable(bizType));
        this.txtAddBinArea.SelectFirst();
        PageResult pageResult = new PageResult();
        setBatchNo(this.txtAddBatchNo, taskManager.GetBatchNoTable(pageResult));
        this.txtAddBatchNo.SelectFirst();

      

    }
  

    private void setBatchNo(ComboBox comboBox1,  PageResult psbEquip)
    {
        comboBox1.Items.Clear();
    

        foreach (DataTable var in psbEquip.ResultDataSet.Tables)
        {
            var item = new Ext.Net.ListItem();
            item.Value = var.Rows[0]["BATCH_NO"].ToString();
            item.Text = var.Rows[0]["BATCH_NO"].ToString();
            comboBox1.Items.Add(item);
           

        }

    }

    /// <summary>
    /// 输出业务信息
    /// </summary>
    private void setBinArea(ComboBox comboBox1, PsbBinArea[] grade)
    {
        comboBox1.Items.Clear();
    

        foreach (var var in grade)
        {
            var item = new Ext.Net.ListItem();
            item.Value = var.AreaNo;
            item.Text = var.AreaNo;
            comboBox1.Items.Add(item);
         
        }
    }
    private object createParameterObject()
    {
        var param = new Hashtable(6);
        if (!string.IsNullOrWhiteSpace(this.txtBinArea.Text))
        {
            param["BIN_AREA"] = this.txtBinArea.StringValue();
        }
        if (!string.IsNullOrWhiteSpace(this.txtBatchNo.Text))
        {
            param["BATCH_NO"] = this.txtBatchNo.StringValue();
        }
        return param;
    }

    /// <summary>
    /// 指令信息
    /// </summary>
    /// <param name="action"></param>
    /// <param name="extraParams"></param>
    /// <returns></returns>
    [DirectMethod]
    public object GetProductInfo(string action, Dictionary<string, object> extraParams)
    {
        PageResult pageResult = new PageResult();
        try
        {
            var param = new Hashtable(6);
            if (!string.IsNullOrWhiteSpace(this.txtBinArea.Text))
            {
                param["BIN_AREA"] = this.txtBinArea.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtBatchNo.Text))
            {
                param["BATCH_NO"] = this.txtBatchNo.StringValue();
            }
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);
            if (prms.Limit <= 0)
            {
                return pageResult.Data;
            }
            pageResult.PageSize = prms.Limit;
            pageResult.PageIndex = prms.Page;
            pageResult.ParameterObject = param;
            pageResult.OrderString = "T.OBJID desc ";

            var service = AppBizFactory.CreateInstance<IProductEnterManager>();
            pageResult = service.GetProductData(pageResult);
        }
        catch (Exception ex)
        {
            X.MessageBox.Show(new MessageBoxConfig() { Title = "提示", Message = ex.Message, Icon = MessageBox.Icon.WARNING });
        }
        return pageResult.Data;
    }

    /// <summary>
    /// 强制重发指令
    /// </summary>
    [DirectMethod]
    public string ForceResendCmd(string Objid)
    {
        if (string.IsNullOrWhiteSpace(Objid) || Objid.Equals("0"))
        {
            return "指令号不能为空！";
        }
        try
        {
            var manager = AppBizFactory.CreateInstance<ITaskManager>();
            var i = manager.ResendWbsTaskCmd(Objid);
            if (i > 0)
            {
                return string.Empty;
            }
            return "重发失败";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

   

    /// <summary>
    /// 强制删除
    /// </summary>
    [DirectMethod]
    public string ForceDelete(string Objid)
    {
        if (string.IsNullOrWhiteSpace(Objid) || Objid.Equals("0"))
        {
            return "OBJID不能为空！";
        }
        try
        {
            var manager = AppBizFactory.CreateInstance<IProductEnterManager>();
            if (manager.DeleteProduct(Objid))
            {
                return string.Empty;
            }
            return "取消失败";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// 切换
    /// </summary>
    [DirectMethod]
    public string ForceExchange(string objid)
    {
        if (string.IsNullOrWhiteSpace(objid))
        {
            return "OBJID不能为空！";
        }
        try
        {
            var manager = AppBizFactory.CreateInstance<IProductEnterManager>();
            var userID = this.Data.User.UserId;
            //  var userName = Session["LoginUserName"];
            if (manager.UpdateSlmsFlag(objid, userID))
            {
                return string.Empty;
            }
            return "切换失败";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    [DirectMethod]
    public string InsertDb(string binArea, string batchNo)
    {

        try
        {
            var manager = AppBizFactory.CreateInstance<IProductEnterManager>();
            Tproc0201IntoWarehouse  tproc0201IntoWarehouse = new Tproc0201IntoWarehouse();
            tproc0201IntoWarehouse.BatchNo = batchNo;
            tproc0201IntoWarehouse.BinArea = binArea;


            return manager.InsertIntoDataBase(tproc0201IntoWarehouse).ToString();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }



  
}
