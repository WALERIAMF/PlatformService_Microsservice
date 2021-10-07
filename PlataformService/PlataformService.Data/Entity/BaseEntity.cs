using System;

namespace PlataformService.Data.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            Ativo = true;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}

