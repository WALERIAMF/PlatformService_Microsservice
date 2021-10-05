using System;

namespace PlataformService.Domain.Dto
{
    public class PlatformDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public double? Cost { get; set; }
    }
}