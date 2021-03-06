﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_CRN - 基础表操作接口
    /// </summary>
    public interface IPsbCrnService : ITableViewService<PsbCrn>
    {
    }

    /// <summary>
    /// PSB_CRN - 基础表操作类
    /// </summary>
    internal class PsbCrnService : TableViewService<PsbCrn>, IPsbCrnService
    {
        #region 构造方法
        public PsbCrnService() : base() { }
        public PsbCrnService(string dbName) : base(dbName) { }
        #endregion
    }
}