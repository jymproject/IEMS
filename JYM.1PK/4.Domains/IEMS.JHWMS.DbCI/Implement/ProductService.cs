using IEMS.JHWMS.DbCI;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.DbCI
{
    public class ProductService : DbCIService,IProductService
    {

        public PageResult GetProductData(PageResult pageResult)
        {
            string stmtId = "GetProductData";
            pageResult.StatementId = stmtId;
            return this.GetPageDataByReader(pageResult);
        }
    }
}
