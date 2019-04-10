using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// TPROC_0201_INTO_WAREHOUSE - 基础表操作接口
    /// </summary>
    public interface ITproc0201IntoWarehouseService : ITableViewService<Tproc0201IntoWarehouse>
    {
    }

    /// <summary>
    /// TPROC_0201_INTO_WAREHOUSE - 基础表操作类
    /// </summary>
    internal class Tproc0201IntoWarehouseService : TableViewService<Tproc0201IntoWarehouse>, ITproc0201IntoWarehouseService
    {
        #region 构造方法
        public Tproc0201IntoWarehouseService() : base() { }
        public Tproc0201IntoWarehouseService(string dbName) : base(dbName) { }
        #endregion
    }
}