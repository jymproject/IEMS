using IEMS.JHWMS.Entity;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.AppBiz
{
    public interface IProductManager : IAppBizManager
    {
        /// <summary>
        /// 获取任务信息
        /// </summary>
        PageResult GetProductData(PageResult pageResult);
        bool InsertIntoDataBase(PsbProductPlan viewProductPlan);
        bool DeleteProduct(string objid);
        bool UpdateSlmsFlag(string objid,int userid);
        object UpdateDataBaseByObjid(PsbProductPlan psbProductPlan, string objid);
        PsbShift[] GetShiftTable(PsbShift psbShift);
        PsbEquip[] GetEquipTable(PsbEquip psbShift);
        PsbWh[] GetWhNoTable(PsbWh psbWh);
    }
}
