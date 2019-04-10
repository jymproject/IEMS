using IEMS.JHWMS.DbRI;
using IEMS.JHWMS.DbCI;
using IEMS.JHWMS.VoDto;
using IEMS.JHWMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MSTL.DbAccess;

namespace IEMS.JHWMS.AppBiz
{
    internal class BinDataManager : IBinDataManager
    {
        public StoreBinData GetStoreBinData(int x)
        {
            var service = DbCIServiceFactory.CreateInstance<IBinDataService>();
            return service.GetStoreBinData(x);
        }

        public StoreBinData GetStoreBinDataByRealGroupNo(int x)
        {
            var service = DbCIServiceFactory.CreateInstance<IBinDataService>();
            return service.GetStoreBinDataByRealGroupNo(x);
        }

        public DataTable GetEmptyBin()
        {
            var service = DbCIServiceFactory.CreateInstance<IBinDataService>();
            return service.GetErrBinNo();
        }

        public void ClearEmptyBin(string binNo)
        {
            var service = TableViewServiceFactory.CreateInstance<IPsbBinStatusService>();
            service.Update(new PsbBinStatus() { BinBizStatus = "_",BinStatus="_" }, new PsbBinStatus() { BinNo = binNo });
        }

        public void ChanageBinUseFlag(string binNo, int useFlag)
        {
            var service = TableViewServiceFactory.CreateInstance<IPsbBinStatusService>();
            service.Update(new PsbBinStatus() { UsedFlag = useFlag }, new PsbBinStatus() { BinNo = binNo });
        }

        public DataTable GetProductStatistics()
        {
            var service = DbCIServiceFactory.CreateInstance<IBinDataService>();
            return service.GetProductStatistics();
        }

        public string CreatOrder(string orderId, string orderNo, string binNo, string eLocNo)
        {
            var wbsOrder = TableViewServiceFactory.CreateInstance<IWbsOrderService>();
            var wbsOrderLine = TableViewServiceFactory.CreateInstance<IWbsOrderLineService>();
            try
            {
                wbsOrder.Insert(new WbsOrder()
                {
                    OrderNo = orderNo,
                    OrderStatus = 0,
                    OrderTypeNo = "100030",
                    OrderTypeModule = "O",
                    CreatedBy = "WMS",
                    OrderPriority = 1000,
                    SourceType = 0
                });

                wbsOrderLine.Insert(new WbsOrderLine()
                {
                    OrderLineGuid = Guid.NewGuid().ToString(),
                    OrderNo = orderNo,
                    LineId = int.Parse(orderId),
                    LineStatus = 0,
                    ElocNo = eLocNo,
                    RequireQty = 1,
                    LimitBinNo = binNo,
                    LinePriority = 1000
                });
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteBin(string binNo)
        {
            try
            {
                var service = ProcedureServiceFactory.CreateInstance<IProcWmsDeleteBinService>();
                service.ExcuteProcedure(new ProcWmsDeleteBin() { IBinNo = int.Parse(binNo) });
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        //public DataTable GetBinCheckDataTable()
        //{
        //    try
        //    {
        //        var service = DbCIServiceFactory.CreateInstance<IBinDataService>();
        //        return service.GetBinCheckDataTable();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void SetQualifiedBin(string packageGuid, int flag, Z40CheckLog log)
        {
            try
            {
                var service = TableViewServiceFactory.CreateInstance<IWbsPackageDataService>();
                service.Update(new WbsPackageData() { CheckStatus = flag }, new WbsPackageData() { PackageGuid = packageGuid });

                var services = TableViewServiceFactory.CreateInstance<IZ40CheckLogService>();
                services.Insert(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
