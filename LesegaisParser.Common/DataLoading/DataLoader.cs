using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LesegaisParser.Common.Model;
using Newtonsoft.Json;

namespace LesegaisParser.Common.DataLoading
{
    internal class DataLoader : IDataLoader
    {
        private const string Path = "https://www.lesegais.ru/open-area/graphql";
        private readonly HttpClient _httpClient;

        internal DataLoader()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseData> Load(RequestBody requestBody)
        {
            var json = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var httpResponse = await _httpClient.PostAsync(Path, httpContent);
                return new ResponseData(httpResponse.IsSuccessStatusCode,
                    (int)httpResponse.StatusCode,
                    await httpResponse.Content.ReadAsStringAsync());
            }
            catch(Exception e)
            {
                return new ResponseData(false, -1, e.Message);
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}