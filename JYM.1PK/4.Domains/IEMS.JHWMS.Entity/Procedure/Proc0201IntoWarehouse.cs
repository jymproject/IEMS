using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IEMS.JHWMS.Entity
{
    using MSTL.DbAccess;

    /// <summary>
    /// PROC_0201_INTO_WAREHOUSE [PROC_0201_INTO_WAREHOUSE] - 实体类
    /// </summary>
    [Entity(TableName = "PROC_0201_INTO_WAREHOUSE", Description = "PROC_0201_INTO_WAREHOUSE")]
    public class Proc0201IntoWarehouse : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "I_PARAM_OBJID", Description = "", DbType = "int(4)")]
        public int? IParamObjid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "READ_USER_ID", Description = "", DbType = "int(4)")]
        public int? ReadUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "O_BIN_NO", Description = "", DbType = "int(4)")]
        public int? OBinNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "O_ERR_CODE", Description = "", DbType = "int(4)")]
        public int? OErrCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(FieldName = "O_ERR_DESC", Description = "", DbType = "varchar(80)")]
        public string OErrDesc { get; set; }
        /// <summary>
        /// 存储过程返回 DataSet 数据
        /// </summary>
        public DataSet ProcedureDataSetResult { get; set; }
    }
}
