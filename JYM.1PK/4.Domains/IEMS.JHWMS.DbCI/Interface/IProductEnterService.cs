using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.DbCI
{
   public interface IProductEnterService : IDbCIService
    {
        /// <summary>
        /// 获取任务
        /// </summary>
        PageResult GetProductData(PageResult pageResult);
        PageResult GetBatchNoTable(PageResult pageResult);
    }
}
