namespace LesegaisParser.Common.Model
{
    public class ResponseData
    {
        public bool IsSuccess { get; }
        public int StatusCode { get; }
        public string ResponseString { get; }

        public ResponseData(bool isSuccess, int code, string responseString)
        {
            IsSuccess = isSuccess;
            StatusCode = code;
            ResponseString = responseString;
        }
    }
}