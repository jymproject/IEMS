using IEMS.JHWMS.DbRI;
using IEMS.JHWMS.Entity;
using IEMS.JHWMS.VoDto;
using MSTL.DbAccess;
using MSTL.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.DbCI
{
    internal class BinDataService : DbCIService, IBinDataService
    {
        public int GetMaxRealGroupNo()
        {
            var dTable = this.GetDataTableByStatement("GetMaxRealGroupNo", null);
            foreach (DataRow dRow in dTable.Rows)
            {
                return Convert.ToInt32(dRow.StringValue("MaxRealGroupNo"));
            }
            return 0;
        }
        private string getMaxBinNo(object paem)
        {
            var dTable = this.GetDataTableByStatement("GetMaxBinNo", paem);
            foreach(DataRow dRow in dTable.Rows)
            {
               return dRow.StringValue("MaxBinNo");
            }
            return string.Empty;
        }
        private string getMaxBinNo(int realGroupNo)
        {
            var where = new Hashtable();
            var param = new Hashtable();
            param["REAL_GROUP_NO"] = realGroupNo;
            where["where"] = param;
            var dTable = this.GetDataTableByStatement("GetMaxBinNo", where);
            foreach (DataRow dRow in dTable.Rows)
            {
                return dRow.StringValue("MaxBinNo");
            }
            return string.Empty;
        }
        public StoreBinData GetStoreBinData(int x)
        {
            var result = new StoreBinData();
            result.MaxBin = new BinData();
            var where = new Hashtable();
            var param = new Hashtable();
            param["BinStart"] = x.ToString("D2");
            where["where"] = param;
            if (x == 99)
            {
                result.MaxBin.BinNo = getMaxBinNo(null);
            }
            else
            {
                result.MaxBin.BinNo = getMaxBinNo(where);
            }
            var dTable = this.GetDataTableByStatement("GetBinDataByBinNoStart", where);
            var bins = new List<BinData>();
            foreach(DataRow dRow in dTable.Rows)
            {
                var bin= new BinData();
                bins.Add(bin);
                bin.BinNo = dRow.StringValue("BIN_NO");
                bin.UsedFlag = dRow.IntValue("USED_FLAG", 0);
                bin.BinSize = dRow.StringValue("BIN_SIZE");
                bin.BinStatus = dRow.StringValue("BIN_STATUS");
                bin.BinBizStatus = dRow.StringValue("BIN_BIZ_STATUS");
                bin.BinWeight = dRow.IntValue("BIN_WEIGHT", 0);
                bin.BinArea = dRow.StringValue("BIN_AREA");
                bin.CrnNo = dRow.StringValue("CRN_NO");
                bin.GroupNo = dRow.StringValue("GROUP_NO");
                bin.OrderLineGuid = dRow.StringValue("ORDER_LINE_GUID");
                bin.BinAgvNo = dRow.StringValue("BIN_AGV_NO");
                bin.BinPlcNo = dRow.StringValue("BIN_PLC_NO");
                bin.PalletNo = dRow.StringValue("PALLET_NO");
                bin.MaterNo = dRow.StringValue("MATER_NO");
                bin.MaterName = dRow.StringValue("MATER_NAME");
                bin.ProductDate = dRow.StringValue("PRODUCT_DATE");
                bin.CreateDate = dRow.StringValue("CREATION_DATE"); 
                bin.CrnNo = dRow.StringValue("CRN_NO");
            }
            result.AllBin = bins.ToArray();
            return result;
        }

        public StoreBinData GetStoreBinDataByRealGroupNo(int realGroupNo)
        {
            var result = new StoreBinData();
            result.MaxBin = new BinData();
            result.MaxBin.BinNo = getMaxBinNo(realGroupNo);
            var where = new Hashtable();
            var param = new Hashtable();
            param["REAL_GROUP_NO"] = realGroupNo;
            where["where"] = param;
            var dTable = this.GetDataTableByStatement("GetBinDataByRealGroupNo", where);
            var bins = new List<BinData>();
            foreach (DataRow dRow in dTable.Rows)
            {
                var bin = new BinData();
                bins.Add(bin);
                bin.BinNo = dRow.StringValue("BIN_NO");
                bin.UsedFlag = dRow.IntValue("USED_FLAG", 0);
                bin.BinSize = dRow.StringValue("BIN_SIZE");
                bin.BinStatus = dRow.StringValue("BIN_STATUS");
                bin.BinBizStatus = dRow.StringValue("BIN_BIZ_STATUS");
                bin.BinWeight = dRow.IntValue("BIN_WEIGHT", 0);
                bin.BinArea = dRow.StringValue("BIN_AREA");
                bin.CrnNo = dRow.StringValue("CRN_NO");
                bin.GroupNo = dRow.StringValue("GROUP_NO");
                bin.OrderLineGuid = dRow.StringValue("ORDER_LINE_GUID");
                bin.BinAgvNo = dRow.StringValue("BIN_AGV_NO");
                bin.BinPlcNo = dRow.StringValue("BIN_PLC_NO");
                bin.PalletNo = dRow.StringValue("PALLET_NO");
                bin.MaterNo = dRow.StringValue("MATER_NO");
                bin.MaterName = dRow.StringValue("MATER_NAME");
                bin.ProductDate = dRow.StringValue("PRODUCT_DATE");
                bin.CreateDate = dRow.StringValue("CREATION_DATE");
                bin.CrnNo = dRow.StringValue("CRN_NO");
                if (!string.IsNullOrEmpty(dRow.StringValue("CHECK_STATUS")))
                {
                    if (dRow.StringValue("CHECK_STATUS").Equals("0"))
                    {
                        bin.CheckStatus = "待检";
                    }
                    else if (dRow.StringValue("CHECK_STATUS").Equals("1"))
                    {
                        bin.CheckStatus = "合格";
                    }
                    else
                    {
                        bin.CheckStatus = "不合格";
                    }
                }
                else
                {
                    bin.CheckStatus = dRow.StringValue("CHECK_STATUS");
                }
            }
            result.AllBin = bins.ToArray();
            result.MaxBin = bins[dTable.Rows.Count - 1];//为了解决中间巷道跟两边巷道层高不一致的问题，anc-2018-9-27
            return result;
        }
        public DataTable GetProductStatistics()
        {
            var dTable = this.GetDataTableByStatement("GetProductStatistics", null);
            return dTable;
        }
        public DataTable GetErrBinNo()
        {
            var dTable = this.GetDataTableByStatement("GetErrBinNo", null);
            return dTable;
        }

        public PageResult GetBinData(PageResult pageResult)
        {
            string stmtId = "GetBinData";
            pageResult.StatementId = stmtId;
            return this.GetPageDataByReader(pageResult);
        }

        //public DataTable GetBinCheckDataTable()
        //{
        //    var dTable = this.GetDataTableByStatement("GetBinCheckDataTable", null);
        //    return dTable;
        //}

        public PageResult GetBinCheckDataInfo(PageResult pageResult)
        {
            string stmtId = "GetBinCheckDataInfo";
            pageResult.StatementId = stmtId;
            return this.GetPageDataByReader(pageResult);
        }
    }
}
