using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PSB_EQUIP - 基础表操作接口
    /// </summary>
    public interface IPsbEquipService : ITableViewService<PsbEquip>
    {
    }

    /// <summary>
    /// PSB_EQUIP - 基础表操作类
    /// </summary>
    internal class PsbEquipService : TableViewService<PsbEquip>, IPsbEquipService
    {
        #region 构造方法
        public PsbEquipService() : base() { }
        public PsbEquipService(string dbName) : base(dbName) { }
        #endregion
    }
}