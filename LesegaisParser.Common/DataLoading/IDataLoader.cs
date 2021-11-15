using System;
using System.Threading.Tasks;
using LesegaisParser.Common.Model;

namespace LesegaisParser.Common.DataLoading
{
    public interface IDataLoader : IDisposable
    {
        Task<ResponseData> Load(RequestBody requestBody);
    }
}