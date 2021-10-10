using System;

namespace PlataformService.Domain.Request
{
    public class ColaboradorPutRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
