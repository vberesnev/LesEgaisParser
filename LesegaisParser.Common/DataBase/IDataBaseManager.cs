using System.Threading.Tasks;
using LesegaisParser.Common.Model;

namespace LesegaisParser.Common.DataBase
{
    public interface IDataBaseManager
    {
        Task<bool> AddDealsAsync(Deal[] deals);
        Deal GetLastDealById();
    }
}