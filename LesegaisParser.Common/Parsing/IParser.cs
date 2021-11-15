using LesegaisParser.Common.Model;

namespace LesegaisParser.Common.Parsing
{
    public interface IParser
    {
        Deal[] ParseData(string data);
    }
}