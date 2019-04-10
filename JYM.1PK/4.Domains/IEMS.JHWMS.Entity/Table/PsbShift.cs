using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PSB_SHIFT [PSB_SHIFT] - 实体类
    /// </summary>
    [Entity(TableName = "PSB_SHIFT", Description = "PSB_SHIFT")]
    public class PsbShift : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "SHIFT_ID", Description = "",
               DbType = "varchar(30)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string ShiftId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "SHIFT_NAME", Description = "",
               DbType = "varchar(30)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string ShiftName { get; set; }
    }
}
