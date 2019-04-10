using System;
using System.Collections.Generic;
using System.Text;

namespace IEMS.JHWMS.DbRI
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    /// <summary>
    /// PROC_0201_INTO_WAREHOUSE - 存储过程操作接口
    /// </summary>
    public interface IProc0201IntoWarehouseService :IProcedureService
    {
	    /// <summary>
        /// PROC_0201_INTO_WAREHOUSE 执行存储过程
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Proc0201IntoWarehouse ExcuteProcedure(Proc0201IntoWarehouse param);
    }

    /// <summary>
    /// PROC_0201_INTO_WAREHOUSE - 存储过程操作类
    /// </summary>
    internal class Proc0201IntoWarehouseService : DbCIService, IProc0201IntoWarehouseService
    {
	    /// <summary>
        /// PROC_0201_INTO_WAREHOUSE 执行存储过程
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Proc0201IntoWarehouse ExcuteProcedure(Proc0201IntoWarehouse param)
		{
		    var result = this.GetDataSetByStatement("PROC_0201_INTO_WAREHOUSE", param);
            param.ProcedureDataSetResult = result;
            return param;
		}
    }
}