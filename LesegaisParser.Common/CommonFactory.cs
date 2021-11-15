using LesegaisParser.Common.DataBase;
using LesegaisParser.Common.DataLoading;
using LesegaisParser.Common.Logger;
using LesegaisParser.Common.Model;
using LesegaisParser.Common.Parsing;

namespace LesegaisParser.Common
{
    public static class CommonFactory
    {
        public static IDataLoader CreateDataLoader() => new DataLoader();
        public static ILogger CreateLogger() => new ConsoleLog();
        public static IParser CreateParser() => new Parser();
        
        public static RequestBody CreateSimpleRequestBody(int size, int page) => new RequestBody(size, page);

        public static RequestBody CreateRequestBodyWithDateDeskSorting(int size, int page) => new RequestBody(size, page, SortProperty.DealDate, SortDirection.Ask);

        public static IDataBaseManager CreateDataBaseManager(ILogger logger) => new DataBaseManager(logger);
    }
}