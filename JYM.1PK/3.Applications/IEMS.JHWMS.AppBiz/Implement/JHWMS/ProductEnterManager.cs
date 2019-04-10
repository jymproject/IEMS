using IEMS.JHWMS.AppBiz;
using IEMS.JHWMS.DbCI;
using IEMS.JHWMS.DbRI;
using IEMS.JHWMS.Entity;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.AppBiz
{
    public class ProductEnterManager : IProductEnterManager
    {
        public bool DeleteProduct(string objid)
        {
            try
            {
                var psbProduct = TableViewServiceFactory.CreateInstance<ITproc0201IntoWarehouseService>();
                var i = psbProduct.Update(new Tproc0201IntoWarehouse { Deleteflag = 1 }, new Tproc0201IntoWarehouse { ObjId = int.Parse(objid) });
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }


        public bool UpdateSlmsFlag(string objid, int userId)
        {
            try
            {
                var service = ProcedureServiceFactory.CreateInstance<IProc0201IntoWarehouseService>();
                service.ExcuteProcedure(new  Proc0201IntoWarehouse() {  IParamObjid = int.Parse(objid), ReadUserId = userId, OBinNo=0, OErrCode=0, OErrDesc=null });
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }


        public PageResult GetProductData(PageResult pageResult)
        {
            var service = DbCIServiceFactory.CreateInstance<IProductEnterService>();
            return service.GetProductData(pageResult);
        }


        public PsbBinArea[] GetBinAreaTable(PsbBinArea psbBinArea)
        {
            var tdate = TableViewServiceFactory.CreateInstance<IPsbBinAreaService>();
            var where = new PsbBinArea();

            return tdate.GetEntityList(where, "area_no").ToArray();
        }

        public PageResult GetBatchNoTable(PageResult pageResult)
        {
            var service = DbCIServiceFactory.CreateInstance<IProductEnterService>();
            return service.GetBatchNoTable(pageResult);
        }

        public bool InsertIntoDataBase(Tproc0201IntoWarehouse tproc0201IntoWarehouse)
        {
            try
            {
                var psbProduct = TableViewServiceFactory.CreateInstance<ITproc0201IntoWarehouseService>();
                var i = psbProduct.Insert(new Tproc0201IntoWarehouse {  BinArea = tproc0201IntoWarehouse.BinArea, BatchNo = tproc0201IntoWarehouse.BatchNo });
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }

        }
    }
}
