using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// WBS_PACKAGE_DATA - 基础表操作接口
    /// </summary>
    public interface IWbsPackageDataService : ITableViewService<WbsPackageData>
    {
    }

    /// <summary>
    /// WBS_PACKAGE_DATA - 基础表操作类
    /// </summary>
    internal class WbsPackageDataService : TableViewService<WbsPackageData>, IWbsPackageDataService
    {
        #region 构造方法
        public WbsPackageDataService() : base() { }
        public WbsPackageDataService(string dbName) : base(dbName) { }
        #endregion
    }
}