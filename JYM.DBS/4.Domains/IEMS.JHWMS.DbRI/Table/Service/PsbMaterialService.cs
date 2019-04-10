using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_MATERIAL - 基础表操作接口
    /// </summary>
    public interface IPsbMaterialService : ITableViewService<PsbMaterial>
    {
    }

    /// <summary>
    /// PSB_MATERIAL - 基础表操作类
    /// </summary>
    internal class PsbMaterialService : TableViewService<PsbMaterial>, IPsbMaterialService
    {
        #region 构造方法
        public PsbMaterialService() : base() { }
        public PsbMaterialService(string dbName) : base(dbName) { }
        #endregion
    }
}