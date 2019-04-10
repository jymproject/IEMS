using IEMS.JHWMS.DbCI;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.DbCI
{
    public class ProductEnterService : DbCIService, IProductEnterService
    {
        public PageResult GetBatchNoTable(PageResult pageResult)
        {
            string stmtId = "GetBatchNoData";
            pageResult.StatementId = stmtId;
            return this.GetPageDataByReader(pageResult);
        }

        public PageResult GetProductData(PageResult pageResult)
        {
            string stmtId = "GetProductEnterData";
            pageResult.StatementId = stmtId;
            return this.GetPageDataByReader(pageResult);

        }
    }
}
