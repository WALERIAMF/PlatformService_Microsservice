namespace PlataformService.Domain.Response
{
    public class ResponseData<T>
    {
        public string Message { get; set; }
        public int ReturnCode { get; set; }
        public long? Count { get; set; }
        public T Data { get; set; }

        public ResponseData()
        {
        }

        public ResponseData(string message)
        {
            Message = message;
        }

        public ResponseData(int returnCode, string message)
        {
            ReturnCode = returnCode;
            Message = message;
        }
    }
}
