namespace PlataformService.Data.Entity
{
    public class PlatformEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public double? Cost { get; set; }
    }
}