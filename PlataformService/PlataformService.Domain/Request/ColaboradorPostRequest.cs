using System;

namespace PlataformService.Domain.Request
{
    public class ColaboradorPostRequest
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
