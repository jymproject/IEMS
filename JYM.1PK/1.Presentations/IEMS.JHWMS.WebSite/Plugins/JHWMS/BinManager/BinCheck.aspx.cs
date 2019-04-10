using Ext.Net;
using IEMS.Frame.WebUI;
using IEMS.Frame.WebUI.Entity;
using IEMS.JHWMS.AppBiz;
using IEMS.JHWMS.DbCI;
using IEMS.JHWMS.Entity;
using MSTL.DbAccess;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class Plugins_JHWMS_BinManager_BinCheck : IEMS.JHWMS.WebUI.Page
{
    #region 权限定义
    protected __ _ = new __();
    public class __ : IEMS.Frame.WebUI.___   //必须继承___   //Action不能重复，重复会被覆盖
    {
        public __()
        {
            库存质检管理 = new PageAction() { ActionId = 1, ActionName = "库存质检管理" };
        }
        public PageAction 库存质检管理 { get; private set; } //必须为 public
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
        this.txtCheckStatus.Items.Clear();
        this.txtCheckStatus.Items.Add(new Ext.Net.ListItem() { Text = "", Value = "" });
        this.txtCheckStatus.Items.Add(new Ext.Net.ListItem() { Text = "待检", Value = "0" });
        this.txtCheckStatus.Items.Add(new Ext.Net.ListItem() { Text = "合格", Value = "1" });
        this.txtCheckStatus.Items.Add(new Ext.Net.ListItem() { Text = "不合格", Value = "2" });
    }

    /// <summary>
    /// 行数据信息
    /// </summary>
    [DirectMethod]
    public object GridPanelBindData(string action, Dictionary<string, object> extraParams)
    {
        PageResult pageResult = new PageResult();
        try
        {
            //var manager = AppBizFactory.CreateInstance<IBinDataManager>();
            //var data = manager.GetBinCheckDataTable();
            //var total = data.Rows.Count;
            //return new { data = data, total };
            
            var param = new Hashtable(6);
            if (!string.IsNullOrWhiteSpace(this.txtBinNo.Text))
            {
                param["BIN_NO"] = this.txtBinNo.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtPalletNo.Text))
            {
                param["PALLET_NO"] = this.txtPalletNo.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtMaterNo.Text))
            {
                param["MATERIAL_NO"] = this.txtMaterNo.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtBatchNo.Text))
            {
                param["BATCH_NO"] = this.txtBatchNo.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtMemo.Text))
            {
                param["MEMO"] = this.txtMemo.StringValue();
            }
            if (!string.IsNullOrWhiteSpace(this.txtCheckStatus.Value.ToString()))
            {
                param["CHECK_STATUS"] = this.txtCheckStatus.StringValue();
            }
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);
            if (prms.Limit <= 0)
            {
                return pageResult.Data;
            }
            pageResult.PageSize = prms.Limit;
            pageResult.PageIndex = prms.Page;
            pageResult.ParameterObject = param;
            pageResult.OrderString = "B.creation_date ";

            var service = DbCIServiceFactory.CreateInstance<IBinDataService>();
            pageResult = service.GetBinCheckDataInfo(pageResult);
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
        return pageResult.Data;
    }
    /// <summary>
    /// 质检合格
    /// </summary>
    /// <param name="binNo"></param>
    /// <returns></returns>
    [DirectMethod]
    public string QualifiedBin(string packageGuid, string currStatus, string binNo, string creationDate, string materNo, string materName, string palletNo, string batchNo, int productQty, string productDate, string memo) // 
    {
        try
        {
            var flag = 1;
            Z40CheckLog log = new Z40CheckLog();
            log.Guid = Guid.NewGuid().ToString();
            log.PackageGuid = packageGuid;
            log.BinNo = binNo;
            log.CreateDate = Convert.ToDateTime(creationDate);
            log.MaterNo = materNo;
            log.MaterName = materName;
            log.PalletNo = palletNo;
            log.BatchNo = batchNo;
            log.ProductQty = productQty;
            log.ProductDate = productDate;
            log.Memo = memo;
            if (currStatus.Equals("合格"))
            {
                log.CurrStatus = 1;
            }
            else if (currStatus.Equals("不合格"))
            {
                log.CurrStatus = 2;
            }
            else
            {
                log.CurrStatus = 0;
            }
            log.HandleStatus = flag;
            log.HandleDate = DateTime.Now;

            var manager = AppBizFactory.CreateInstance<IBinDataManager>();
            manager.SetQualifiedBin(packageGuid, flag, log);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return string.Empty;
    }
    /// <summary>
    /// 质检不合格
    /// </summary>
    /// <param name="binNo"></param>
    /// <returns></returns>
    [DirectMethod]
    public string UnQualifiedBin(string packageGuid, string currStatus, string binNo, string creationDate, string materNo, string materName, string palletNo, string batchNo, int productQty, string productDate, string memo) //
    {
        try
        {
            var flag = 2;

            Z40CheckLog log = new Z40CheckLog();
            log.Guid = Guid.NewGuid().ToString();
            log.PackageGuid = packageGuid;
            log.BinNo = binNo;
            log.CreateDate = Convert.ToDateTime(creationDate);
            log.MaterNo = materNo;
            log.MaterName = materName;
            log.PalletNo = palletNo;
            log.BatchNo = batchNo;
            log.ProductQty = productQty;
            log.ProductDate = productDate;
            log.Memo = memo;
            if (currStatus.Equals("合格"))
            {
                log.CurrStatus = 1;
            }
            else if (currStatus.Equals("不合格"))
            {
                log.CurrStatus = 2;
            }
            else
            {
                log.CurrStatus = 0;
            }
            log.HandleStatus = flag;
            log.HandleDate = DateTime.Now;
            
            var manager = AppBizFactory.CreateInstance<IBinDataManager>();
            manager.SetQualifiedBin(packageGuid, flag, log);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return string.Empty;
    }
}
