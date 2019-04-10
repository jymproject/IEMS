using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PEM_CRN_FORK_STATUS [PEM_CRN_FORK_STATUS] - 实体类
    /// </summary>
    [Entity(TableName = "PEM_CRN_FORK_STATUS", Description = "PEM_CRN_FORK_STATUS")]
    public class PemCrnForkStatus : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "CRN_FORK_NO", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = true, IsIdentity = false, Nullable = false)]
        public string CrnForkNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "CRN_NO", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = false)]
        public string CrnNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "LAST_TASK_TYPE", Description = "",
               DbType = "char(1)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = false)]
        public string LastTaskType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "TASK_TYPE", Description = "",
               DbType = "char(1)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string TaskType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "TASK_NO", Description = "",
               DbType = "numeric(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? TaskNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "RETRY_COUNT", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = false)]
        public int? RetryCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "RECORD_TIME", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? RecordTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "FIP_FLAG", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? FipFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "FIP_DATE", Description = "",
               DbType = "datetime", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public DateTime? FipDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "FIP_HANDLE_RESULT", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string FipHandleResult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "FIP_FAULT_NO", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? FipFaultNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "DeviceId", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string Deviceid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "HeartBeat", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Heartbeat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "OperateMode", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Operatemode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MissionState", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Missionstate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MissionType", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Missiontype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "MissionId", Description = "",
               DbType = "numeric(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Missionid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "PalletId", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string Palletid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActPosBay", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Actposbay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActPosLevel", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Actposlevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActPosX", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actposx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActPosY", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actposy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActPosZ", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actposz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActPosZDeep", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actposzdeep { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActSpeedX", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actspeedx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActSpeedY", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actspeedy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActSpeedZ", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actspeedz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "ActSpeedZDeep", Description = "",
               DbType = "decimal(9)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public decimal? Actspeedzdeep { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "LoadStatus", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Loadstatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "FaultNo", Description = "",
               DbType = "int(4)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public int? Faultno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "NoFunction", Description = "",
               DbType = "varchar(80)", DefaultValue = "",
               IsPrimaryKey = false, IsIdentity = false, Nullable = true)]
        public string Nofunction { get; set; }
    }
}
