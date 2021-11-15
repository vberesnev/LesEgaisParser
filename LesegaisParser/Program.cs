using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LesegaisParser.Common;
using LesegaisParser.Common.DataLoading;
using LesegaisParser.Common.Logger;
using LesegaisParser.Common.Model;

namespace LesegaisParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logger = CommonFactory.CreateLogger();
            var parser = CommonFactory.CreateParser();
            var dataBaseManager = CommonFactory.CreateDataBaseManager(logger);


            logger.Print(LogType.Debug, "Начинаю скачивание данных с сайта");

            var page = 0;
            using (var dataLoader = CommonFactory.CreateDataLoader())
            {
                while (true)
                {
                    var requestBody = CommonFactory.CreateRequestBodyWithDateDeskSorting(100, page++);
                    var response = await dataLoader.Load(requestBody);
                    if (!response.IsSuccess)
                    {
                        if (response.StatusCode == -1)
                            logger.Print(LogType.Error, $"Эксепшн при загрузке данных: {response.ResponseString}");
                        else
                            logger.Print(LogType.Debug, $"Получен код {response.StatusCode} при загрузке данных.");
                        break;
                    }

                    var deals = parser.ParseData(response.ResponseString);

                    if (deals?.Length > 0)
                    {
                        logger.Print(LogType.Success, $"Получено {deals.Length} сделок. Начинаю загрузку в БД");
                        var result = await dataBaseManager.AddDealsAsync(deals);
                        if (!result)
                            logger.Print(LogType.Error, "Загрузка данных в БД завершилась с ошибкой");
                    }
                    else
                    {
                        logger.Print(LogType.Error, "Нет данных для загрузки данных в БД");
                    }
                }
            }
           
            logger.Print(LogType.Debug, $"Загрузка данных завершена");
            logger.Print(LogType.Debug, $"Начинаю сканирование на новые сделки раз в 10 минут");

            while (true)
            {
                page = 0;
                Task.Delay(TimeSpan.FromSeconds(10))
                    .Wait();
                
                try
                {
                    var lastDeal = dataBaseManager.GetLastDealById();
                    var deals = new Stack<Deal>();

                    using var dataLoader = CommonFactory.CreateDataLoader();
                    while (true)
                    {
                        var requestBody = CommonFactory.CreateSimpleRequestBody(1, page++);
                        var response = await dataLoader.Load(requestBody);
                        var deal = parser.ParseData(response.ResponseString)[0];
                        if (deal.Equals(lastDeal))
                            break;
                        deals.Push(deal);
                        if (deals.Count > 10)
                            break;
                    }
                    var count = deals.Count;
                    if (count > 0)
                    {
                        await dataBaseManager.AddDealsAsync(deals.ToArray());
                        logger.Print(LogType.Success, $"Добавлено {count} новых сделок");
                    }
                }
                catch (Exception e)
                {
                    logger.Print(LogType.Error, $"Ошибка при сканировании на новые сделки: {e.Message}");
                    break;
                }
            }

            logger.Print(LogType.Debug, $"Конец работы программы");

        }
    }
}
