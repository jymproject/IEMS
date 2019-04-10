
namespace IEMS.JHWMS.DbCI
{
    using MSTL.DbAccess;
    using System.Data;

    public interface IEquipService : IDbCIService
    {
        DataTable GetDataTable();
      
    }
}
