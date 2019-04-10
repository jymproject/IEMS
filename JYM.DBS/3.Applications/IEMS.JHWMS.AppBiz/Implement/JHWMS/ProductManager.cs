using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IEMS.JHWMS.DbCI;
using IEMS.JHWMS.Entity;
using IEMS.JHWMS.DbRI;

namespace IEMS.JHWMS.AppBiz
{
    public class ProductManager : IProductManager
    {
        public bool DeleteProduct(string objid)
        {
            try
            {
                var psbProduct = TableViewServiceFactory.CreateInstance<IPsbProductPlanService>();
                var i = psbProduct.Update(new PsbProductPlan {  DeleteFlag = 1} ,new PsbProductPlan { ObjId = int.Parse(objid)});
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        #region  获取任务信息
        public PageResult GetProductData(PageResult pageResult)
        {
            var service = DbCIServiceFactory.CreateInstance<IProductService>();
            return service.GetProductData(pageResult);
        }

        public PsbShift[] GetShiftTable(PsbShift psbShift)
        {
            var tdate = TableViewServiceFactory.CreateInstance<IPsbShiftService>();
            var where = new PsbShift();
           
            return tdate.GetEntityList(where, "SHIFT_NAME").ToArray();
        }

        public PsbEquip[] GetEquipTable(PsbEquip psbShift)
        {
            var tdate = TableViewServiceFactory.CreateInstance<IPsbEquipService>();
            var where = new PsbEquip();

            return tdate.GetEntityList(where, "Equip_no").ToArray();
        }

        public PsbWh[] GetWhNoTable(PsbWh psbWh)
        {
            var tdate = TableViewServiceFactory.CreateInstance<IPsbWhService>();
            var where = new PsbWh();

            return tdate.GetEntityList(where, "WH_NO").ToArray();
        }
        public bool InsertIntoDataBase(PsbProductPlan psbProductPlan)
        {
            try
            {
                var psbProduct = TableViewServiceFactory.CreateInstance<IPsbProductPlanService>();
                var i = psbProduct.Insert(psbProductPlan);
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        public object UpdateDataBaseByObjid(PsbProductPlan psbProductPlan, string objid)
        {
            try
            {
                var viewProduct = TableViewServiceFactory.CreateInstance<IPsbProductPlanService>();
                var i = viewProduct.Update(psbProductPlan, new PsbProductPlan { ObjId = int.Parse(objid) });
                return true;
            }
            catch 
            {

                return false;

            }

        }

        public bool UpdateSlmsFlag(string objid,int userId)
        {
            try
            {
                var psbProduct = TableViewServiceFactory.CreateInstance<IPsbProductPlanService>();
                var i = psbProduct.Update(new PsbProductPlan { SlmsFlag = 1,ReadUserId = userId, ReadTime = DateTime.Now}, new PsbProductPlan { ObjId = int.Parse(objid) });
                return true;
            }
            catch 
            {

                return false;

            }
        }
        #endregion


    }
}
