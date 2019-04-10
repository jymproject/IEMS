using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PSB_WH [PSB_WH] - 实体类
    /// </summary>
    [Entity(TableName = "PSB_WH", Description = "PSB_WH")]
    public class PsbWh : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "WH_NO", Description = "",
               DbType = "varchar(20)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string WhNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "WH_NAME", Description = "",
               DbType = "varchar(50)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string WhName { get; set; }
    }
}
