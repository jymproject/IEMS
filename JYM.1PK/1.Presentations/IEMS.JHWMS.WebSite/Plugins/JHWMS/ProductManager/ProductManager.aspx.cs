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


public partial class Plugins_JHWMS_ProductManager_ProductManager : IEMS.JHWMS.WebUI.Page
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
        //this.txtShiftIdAdd.Items.Clear();
        //this.txtEquipNo_add.Items.Clear();
        //var item1 = new Ext.Net.ListItem();
        //item1.Value = "早";
        //item1.Text = "早";
        //var item2 = new Ext.Net.ListItem();
        //item2.Value = "中";
        //item2.Text = "中";
        //var item3 = new Ext.Net.ListItem();
        //item3.Value = "晚";
        //item3.Text = "晚";
        //var item4 = new Ext.Net.ListItem();
        //item4.Value = "1号机台";
        //item4.Text = "1号机台";
        //var item5 = new Ext.Net.ListItem();
        //item5.Value = "2号机台";
        //item5.Text = "2号机台";
        //var item6 = new Ext.Net.ListItem();
        //item6.Value = "3号机台";
        //item6.Text = "3号机台";
        //this.txtShiftIdAdd.Items.Add(item1);
        //this.txtShiftIdAdd.Items.Add(item2);
        //this.txtShiftIdAdd.Items.Add(item3);

        //this.txtEquipNo_add.Items.Add(item4);
        //this.txtEquipNo_add.Items.Add(item5);
        //this.txtEquipNo_add.Items.Add(item6);

        //this.txtshifid_edit.Items.Clear();
        //this.txtEquipNo_edit.Items.Clear();

        //this.txtshifid_edit.Items.Add(item1);
        //this.txtshifid_edit.Items.Add(item2);
        //this.txtshifid_edit.Items.Add(item3);

        //this.txtEquipNo_edit.Items.Add(item4);
        //this.txtEquipNo_edit.Items.Add(item5);
        //this.txtEquipNo_edit.Items.Add(item6);
        var taskManager = IEMS.JHWMS.AppBiz.AppBizFactory.CreateInstance<IProductManager>();
        //查询业务信息
        PsbShift bizType = new PsbShift();
        setShift(this.txtShiftIdAdd, this.txtshifid_edit, taskManager.GetShiftTable(bizType));
        this.txtShiftIdAdd.SelectFirst();
        PsbEquip psbEquip = new PsbEquip();
        setEquip(this.txtEquipNo_add, this.txtEquipNo_edit, taskManager.GetEquipTable(psbEquip));
        this.txtEquipNo_add.SelectFirst();

        PsbWh psbWh = new PsbWh();
        setWhNo(this.txtWhNo, this.txtWhNo_edit, taskManager.GetWhNoTable(psbWh));
        this.txtWhNo.SelectFirst();


    }
    private void setWhNo(ComboBox comboBox1, ComboBox comboBox2, PsbWh[] psbEquip)
    {
        comboBox1.Items.Clear();
        comboBox2.Items.Clear();

        foreach (var var in psbEquip)
        {
            var item = new Ext.Net.ListItem();
            item.Value = var.WhNo;
            item.Text = var.WhName;
            comboBox1.Items.Add(item);
            comboBox2.Items.Add(item);

        }
    }

    private void setEquip(ComboBox comboBox1, ComboBox comboBox2, PsbEquip[] psbEquip)
    {
        comboBox1.Items.Clear();
        comboBox2.Items.Clear();

        foreach (var var in psbEquip)
        {
            var item = new Ext.Net.ListItem();
            item.Value = var.EquipNo;
            item.Text = var.EquipName;
            comboBox1.Items.Add(item);
            comboBox2.Items.Add(item);

        }

    }

    /// <summary>
    /// 输出业务信息
    /// </summary>
    private void setShift(ComboBox comboBox1, ComboBox comboBox2, PsbShift[] grade)
    {
        comboBox1.Items.Clear();
        comboBox2.Items.Clear();

        foreach (var var in grade)
        {
            var item = new Ext.Net.ListItem();
            item.Value = var.ShiftId;
            item.Text = var.ShiftName;
            comboBox1.Items.Add(item);
            comboBox2.Items.Add(item);
        }
    }
    private object createParameterObject()
    {
        var param = new Hashtable(6);
        if (!string.IsNullOrWhiteSpace(this.txtEquipNo.Text))
        {
            param["EQUIP_NO"] = this.txtEquipNo.StringValue();
        }
        if (!string.IsNullOrWhiteSpace(this.txtShiftId.Text))
        {
            param["SHIFT_ID"] = this.txtShiftId.StringValue();
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
            if (!string.IsNullOrWhiteSpace(this.txtEquipNo.Text))
            {
                param["EQUIP_NO"] = this.txtEquipNo.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtShiftId.Text))
            {
                param["SHIFT_ID"] = this.txtShiftId.StringValue();
            }
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);
            if (prms.Limit <= 0)
            {
                return pageResult.Data;
            }
            pageResult.PageSize = prms.Limit;
            pageResult.PageIndex = prms.Page;
            pageResult.ParameterObject = param;
            pageResult.OrderString = "T.RECORD_TIME ";

            var service = AppBizFactory.CreateInstance<IProductManager>();
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
    /// 强制结束指令
    /// </summary>
    [DirectMethod]
    public string ForceFinishCmd(string Objid)
    {
        if (string.IsNullOrWhiteSpace(Objid) || Objid.Equals("0"))
        {
            return "指令号不能为空！";
        }
        try
        {
            var manager = AppBizFactory.CreateInstance<ITaskManager>();
            var errMsg = manager.FinishWbsTaskCmd(Objid);
            if (string.IsNullOrEmpty(errMsg))
            {
                return string.Empty;
            }
            else
            {
                return "结束失败:" + errMsg;
            }
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
            var manager = AppBizFactory.CreateInstance<IProductManager>();
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
            var manager = AppBizFactory.CreateInstance<IProductManager>();
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
    public string InsertDb(string materNo, string productBatch, string shiftId, string equipNo, string batchNo, string productName, string packType, string standardWeight, string allowErrRange, string srmName, string letterNo, string productQty, string orderQty, string shipDesc, string srmDesc, string whNo, string productDate, string shipDate)
    {

        try
        {
            var manager = AppBizFactory.CreateInstance<IProductManager>();
            PsbProductPlan psbProductPlan = new PsbProductPlan();
            psbProductPlan.MaterNo = materNo;
            psbProductPlan.ShiftId = shiftId;
            psbProductPlan.EquipNo = equipNo;
            psbProductPlan.BatchNo = batchNo;
            psbProductPlan.ProductName = productName;
            psbProductPlan.PackageStyle = packType;
            psbProductPlan.StandardWeight = decimal.Parse(standardWeight);
            psbProductPlan.ErrorWeight = decimal.Parse(allowErrRange);
            psbProductPlan.SrmName = srmName;
            psbProductPlan.LetterNo = letterNo;
            psbProductPlan.ProductQty = decimal.Parse(productQty);
            psbProductPlan.OrderQty = decimal.Parse(orderQty);
            psbProductPlan.ShipmentsDesc = shipDesc;
            psbProductPlan.SrmDesc = srmDesc;
            psbProductPlan.WhNo = whNo;
            psbProductPlan.ProductBatchNo = productBatch;
            psbProductPlan.ProductDate = DateTime.Parse(productDate.Replace('\"', ' '));
            psbProductPlan.ShipmentsDate = DateTime.Parse(shipDate.Replace('\"', ' '));

            return manager.InsertIntoDataBase(psbProductPlan).ToString();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }



    [DirectMethod]
    public string UpdateDb(string materNo, string objid, string productBatch, string shiftId, string equipNo, string batchNo, string productName, string packType, string standardWeight, string allowErrRange, string srmName, string letterNo, string productQty, string orderQty, string shipDesc, string srmDesc, string whNo, string productDate, string shipDate)
    {

        try
        {
            var manager = AppBizFactory.CreateInstance<IProductManager>();
            PsbProductPlan psbProductPlan = new PsbProductPlan();
            psbProductPlan.MaterNo = materNo;
            psbProductPlan.ShiftId = shiftId;
            psbProductPlan.EquipNo = equipNo;
            psbProductPlan.BatchNo = batchNo;
            psbProductPlan.ProductName = productName;
            psbProductPlan.PackageStyle = packType;
            psbProductPlan.StandardWeight = decimal.Parse(standardWeight);
            psbProductPlan.ErrorWeight = decimal.Parse(allowErrRange);
            psbProductPlan.SrmName = srmName;
            psbProductPlan.LetterNo = letterNo;
            psbProductPlan.ProductQty = decimal.Parse(productQty);
            psbProductPlan.OrderQty = decimal.Parse(orderQty);
            psbProductPlan.ShipmentsDesc = shipDesc;
            psbProductPlan.SrmDesc = srmDesc;
            psbProductPlan.WhNo = whNo;
            psbProductPlan.ProductBatchNo = productBatch;
            psbProductPlan.ProductDate = DateTime.Parse(productDate.Replace('\"', ' '));
            psbProductPlan.ShipmentsDate = DateTime.Parse(shipDate.Replace('\"', ' '));

            return manager.UpdateDataBaseByObjid(psbProductPlan, objid).ToString();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
