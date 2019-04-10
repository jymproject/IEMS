using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// Z40_CHECK_LOG - 基础表操作接口
    /// </summary>
    public interface IZ40CheckLogService : ITableViewService<Z40CheckLog>
    {
    }

    /// <summary>
    /// Z40_CHECK_LOG - 基础表操作类
    /// </summary>
    internal class Z40CheckLogService : TableViewService<Z40CheckLog>, IZ40CheckLogService
    {
        #region 构造方法
        public Z40CheckLogService() : base() { }
        public Z40CheckLogService(string dbName) : base(dbName) { }
        #endregion
    }
}