using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IEMS.JHWMS.Entity;
using MSTL.DbAccess;

namespace IEMS.JHWMS.AppBiz
{
    public interface IProductEnterManager : IAppBizManager
    {
        bool DeleteProduct(string objid);
        bool UpdateSlmsFlag(string objid, int userid);
        PageResult GetProductData(PageResult pageResult);
        PsbBinArea[] GetBinAreaTable(PsbBinArea psbShift);
        PageResult GetBatchNoTable(PageResult pageResult);
        bool InsertIntoDataBase(Tproc0201IntoWarehouse tproc0201IntoWarehouse);
    }
}
