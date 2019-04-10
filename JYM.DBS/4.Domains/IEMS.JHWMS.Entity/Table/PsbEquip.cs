using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PSB_EQUIP [PSB_EQUIP] - 实体类
    /// </summary>
    [Entity(TableName = "PSB_EQUIP", Description = "PSB_EQUIP")]
    public class PsbEquip : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "Equip_no", Description = "",
               DbType = "varchar(20)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string EquipNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "Equip_Name", Description = "",
               DbType = "varchar(20)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string EquipName { get; set; }
    }
}
