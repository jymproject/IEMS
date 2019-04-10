using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_PRODUCT_PLAN - 基础表操作接口
    /// </summary>
    public interface IPsbProductPlanService : ITableViewService<PsbProductPlan>
    {
    }

    /// <summary>
    /// PSB_PRODUCT_PLAN - 基础表操作类
    /// </summary>
    internal class PsbProductPlanService : TableViewService<PsbProductPlan>, IPsbProductPlanService
    {
        #region 构造方法
        public PsbProductPlanService() : base() { }
        public PsbProductPlanService(string dbName) : base(dbName) { }
        #endregion
    }
}