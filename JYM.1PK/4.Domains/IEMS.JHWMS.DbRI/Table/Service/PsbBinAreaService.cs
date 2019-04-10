using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_BIN_AREA - 基础表操作接口
    /// </summary>
    public interface IPsbBinAreaService : ITableViewService<PsbBinArea>
    {
    }

    /// <summary>
    /// PSB_BIN_AREA - 基础表操作类
    /// </summary>
    internal class PsbBinAreaService : TableViewService<PsbBinArea>, IPsbBinAreaService
    {
        #region 构造方法
        public PsbBinAreaService() : base() { }
        public PsbBinAreaService(string dbName) : base(dbName) { }
        #endregion
    }
}