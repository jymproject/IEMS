using System.Collections.Generic;

namespace IEMS.JHWMS.AppBiz
{
    using MSTL.DbAccess;
    using IEMS.JHWMS.Entity;

    public interface IDeptManager : IAppBizManager
    {
        PageResult GetPageDataByReader(PageResult pageResult);

        SsbDept GetByObjId(int ObjId);

        IList<SsbDept> GetEntityList(SsbDept entity);
        IList<SsbDept> GetEntityList(SsbDept entity,string orderby);
        int Update(SsbDept update,SsbDept where);
        int Insert(SsbDept entity);
        int GetRowCount(SsbDept entity);
    }
}
