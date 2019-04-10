using IEMS.JHWMS.VoDto;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.DbCI
{
   public interface IBinDataService : IDbCIService
    {
        int GetMaxRealGroupNo();
        StoreBinData GetStoreBinData(int x);
        StoreBinData GetStoreBinDataByRealGroupNo(int x);
        DataTable GetProductStatistics();
        DataTable GetErrBinNo();
        PageResult GetBinData(PageResult pageResult);
        //DataTable GetBinCheckDataTable();
        PageResult GetBinCheckDataInfo(PageResult pageResult);
    }
}
