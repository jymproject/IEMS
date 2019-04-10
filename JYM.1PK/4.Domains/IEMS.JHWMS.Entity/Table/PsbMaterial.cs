using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PSB_MATERIAL [PSB_MATERIAL] - 实体类
    /// </summary>
    [Entity(TableName = "PSB_MATERIAL", Description = "PSB_MATERIAL")]
    public class PsbMaterial : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_NO", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = true, IsIdentity = false, Nullable = false)]
        public string MaterNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_NAME", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MaterName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_CODE", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MaterCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_MKIND", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MaterMkind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MKIND_NAME", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MkindName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_IKIND", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MaterIkind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "IKIND_NAME", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string IkindName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MAIN_UNIT", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MainUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MIN_TIME", Description = "",
               DbType = "numeric(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? MinTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MAX_TIME", Description = "",
               DbType = "numeric(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? MaxTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_SPEC", Description = "",
               DbType = "varchar(200)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MaterSpec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MATER_DESC", Description = "",
               DbType = "varchar(200)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string MaterDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "CREATION_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "DELETE_FLAG", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? DeleteFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "RECORD_USER_ID", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? RecordUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "RECORD_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? RecordTime { get; set; }
    }
}
