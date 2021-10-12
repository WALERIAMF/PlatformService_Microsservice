namespace PlataformService.Domain.Response
{
    public class ResponseData<T>
    {
        public T Data { get; set; }
        public int? Count { get; set; }
        public string Message { get; set; }
        public string Hash { get; set; }

        public ResponseData() { }
        public ResponseData(string message) => Message = message;

        public ResponseData(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public ResponseData(T data, string message, int count)
        {
            Data = data;
            Message = message;
            Count = count;
        }
    }
}
