using IEMS.JHWMS.VoDto;
using MSTL.DbAccess;
using MSTL.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.DbCI
{
    internal class EquipService : DbCIService, IEquipService
    {
        public DataTable GetDataTable()
        {
            var dTable = this.GetDataTableByStatement("GetPsbEquipDataTable", null);
            return dTable;
        }

     
    }
}
