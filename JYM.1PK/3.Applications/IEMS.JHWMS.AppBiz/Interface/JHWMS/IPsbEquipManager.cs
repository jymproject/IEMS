using IEMS.JHWMS.VoDto;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IEMS.JHWMS.AppBiz
{
    public interface IPsbEquipManager : IAppBizManager
    {
       
        void SetEnable(string crnNo, int enable);

        DataTable GetDataTable();


    }
}