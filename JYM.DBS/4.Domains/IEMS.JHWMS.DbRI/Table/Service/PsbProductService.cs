using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_PRODUCT - 基础表操作接口
    /// </summary>
    public interface IPsbProductService : ITableViewService<PsbProduct>
    {
    }

    /// <summary>
    /// PSB_PRODUCT - 基础表操作类
    /// </summary>
    internal class PsbProductService : TableViewService<PsbProduct>, IPsbProductService
    {
        #region 构造方法
        public PsbProductService() : base() { }
        public PsbProductService(string dbName) : base(dbName) { }
        #endregion
    }
}