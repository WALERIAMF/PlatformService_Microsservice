using System;

namespace PlataformService.Domain.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = new Guid();
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
