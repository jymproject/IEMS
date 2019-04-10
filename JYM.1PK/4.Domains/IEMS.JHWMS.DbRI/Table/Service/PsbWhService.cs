using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_WH - 基础表操作接口
    /// </summary>
    public interface IPsbWhService : ITableViewService<PsbWh>
    {
    }

    /// <summary>
    /// PSB_WH - 基础表操作类
    /// </summary>
    internal class PsbWhService : TableViewService<PsbWh>, IPsbWhService
    {
        #region 构造方法
        public PsbWhService() : base() { }
        public PsbWhService(string dbName) : base(dbName) { }
        #endregion
    }
}