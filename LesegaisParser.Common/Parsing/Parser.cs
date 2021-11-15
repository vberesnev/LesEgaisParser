using LesegaisParser.Common.Model;
using Newtonsoft.Json;

namespace LesegaisParser.Common.Parsing
{
    class Parser : IParser
    {
        internal Parser(){}

        public Deal[] ParseData(string data)
        {
            var response =  JsonConvert.DeserializeObject<ResponseWrapper>(data);
            return response?.Data?.Content?.Deals;
        }
    }
}
