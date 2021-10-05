namespace PlataformService.Domain.Model
{
    public class PlatformModel : BaseModel
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public double? Cost { get; set; }
    }
}