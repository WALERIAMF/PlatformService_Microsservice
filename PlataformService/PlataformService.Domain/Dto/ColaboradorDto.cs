using System;

namespace PlataformService.Domain.Dto
{
    public class ColaboradorDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
