using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PSB_JOB_STATUS [PSB_JOB_STATUS] - 实体类
    /// </summary>
    [Entity(TableName = "PSB_JOB_STATUS", Description = "PSB_JOB_STATUS")]
    public class PsbJobStatus : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ID", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = true, IsIdentity = true, Nullable = false)]
        public int? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "JOB_NO", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string JobNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "JOB_NAME", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string JobName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "INTERVAL", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Interval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "JOB_STATUS", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? JobStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "EXCUTE_RESULT", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string ExcuteResult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "USED_FLAG", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? UsedFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "LAST_EXCUTE_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? LastExcuteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MAX_EXCUTE_TIME", Description = "",
               DbType = "numeric(13)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? MaxExcuteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MIN_EXCUTE_TIME", Description = "",
               DbType = "numeric(13)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? MinExcuteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "AVG_EXCUTE_TIME", Description = "",
               DbType = "numeric(13)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? AvgExcuteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "TOTAL_EXCUTE_TIME", Description = "",
               DbType = "numeric(13)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? TotalExcuteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "EXCUTE_COUNT", Description = "",
               DbType = "numeric(13)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? ExcuteCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "SP_NAME", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string SpName { get; set; }
    }
}
