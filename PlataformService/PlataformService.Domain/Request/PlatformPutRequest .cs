using System;

namespace PlataformService.Domain.Request
{
    public class PlatformPutRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public double? Cost { get; set; }
        public bool Ativo { get; set; }
    }
}
