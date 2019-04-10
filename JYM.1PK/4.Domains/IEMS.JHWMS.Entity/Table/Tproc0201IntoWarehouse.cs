using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// TPROC_0201_INTO_WAREHOUSE [TPROC_0201_INTO_WAREHOUSE] - 实体类
    /// </summary>
    [Entity(TableName = "TPROC_0201_INTO_WAREHOUSE", Description = "TPROC_0201_INTO_WAREHOUSE")]
    public class Tproc0201IntoWarehouse : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "OBJID", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = true, Nullable = false)]
        public int? ObjId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ERR_CODE", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? ErrCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ERR_DESC", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string ErrDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "PROC_STATUS", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? ProcStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "PROC_CREATE_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? ProcCreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "PROC_EXCUTE_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? ProcExcuteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "PROC_FINISH_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? ProcFinishTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "SLMS_FLAG", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? SlmsFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "UPDATE_DATE", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "BATCH_NO", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string BatchNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "BIN_AREA", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string BinArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "READ_USER_ID", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string ReadUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "DeleteFlag", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = false)]
        public int? Deleteflag { get; set; }
    }
}
