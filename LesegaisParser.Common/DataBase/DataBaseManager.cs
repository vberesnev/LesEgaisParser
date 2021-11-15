using System;
using System.Linq;
using System.Threading.Tasks;
using LesegaisParser.Common.Logger;
using LesegaisParser.Common.Model;

namespace LesegaisParser.Common.DataBase
{
    class DataBaseManager : IDataBaseManager
    {
        private readonly ILogger _logger;

        internal DataBaseManager(ILogger logger)
        {
            _logger = logger;
        }    
        
        public async Task<bool> AddDealsAsync(Deal[] deals)
        {
            using (var db = new LesegaisContext())
            {
                try
                {
                    await db.Deals.AddRangeAsync(deals);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch(Exception e)
                {
                    _logger.Print(LogType.Error, $"Эксепшн при загрузке данных в базу: {e.Message}");
                    return false;
                }
            }
        }

        public Deal GetLastDealById()
        {
            using var db = new LesegaisContext();
            return db.Deals.OrderByDescending(u => u.Id).First();
        }
    }
}