
namespace IEMS.JHWMS.DbCI
{
    using MSTL.DbAccess;
    using System.Data;

    public interface ICrnService : IDbCIService
    {
        DataTable GetCrnDataTable();
        /// <summary>
        /// ��ȡ�Ѷ�����쳣״̬
        /// </summary>
        DataTable GetCrnForkErrorStatus();
    }
}
