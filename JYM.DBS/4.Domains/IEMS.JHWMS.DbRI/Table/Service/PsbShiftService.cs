using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_SHIFT - 基础表操作接口
    /// </summary>
    public interface IPsbShiftService : ITableViewService<PsbShift>
    {
    }

    /// <summary>
    /// PSB_SHIFT - 基础表操作类
    /// </summary>
    internal class PsbShiftService : TableViewService<PsbShift>, IPsbShiftService
    {
        #region 构造方法
        public PsbShiftService() : base() { }
        public PsbShiftService(string dbName) : base(dbName) { }
        #endregion
    }
}