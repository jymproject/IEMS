using IEMS.JHWMS.DbRI;
using IEMS.JHWMS.DbCI;
using IEMS.JHWMS.VoDto;
using IEMS.JHWMS.Entity;
using MSTL.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MSTL.LogAgent;

namespace IEMS.JHWMS.AppBiz
{
    internal class PsbEquipManager : IPsbEquipManager
    {
        #region 系统日志  log
        private ILog log { get { return Log.Store[this.GetType().FullName]; } }

        public DataTable GetDataTable()
        {
            var service = DbCIServiceFactory.CreateInstance<IEquipService>();
            return service.GetDataTable();
        }
        #endregion

        public void SetEnable(string equipNo,int enable)
        {
            try
            {
                var service = TableViewServiceFactory.CreateInstance<IPsbEquipService>();
                service.Update(new PsbEquip() {  IsEnabled = enable }, new PsbEquip() {  EquipNo = equipNo });
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
     
    }
}