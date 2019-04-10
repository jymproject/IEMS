using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_JOB_STATUS - 基础表操作接口
    /// </summary>
    public interface IPsbJobStatusService : ITableViewService<PsbJobStatus>
    {
    }

    /// <summary>
    /// PSB_JOB_STATUS - 基础表操作类
    /// </summary>
    internal class PsbJobStatusService : TableViewService<PsbJobStatus>, IPsbJobStatusService
    {
        #region 构造方法
        public PsbJobStatusService() : base() { }
        public PsbJobStatusService(string dbName) : base(dbName) { }
        #endregion
    }
}