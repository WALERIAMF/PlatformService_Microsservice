using System;

namespace PlataformService.Domain.Model
{
    public abstract class BaseModel
    {

        public Guid Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataInativacao { get; set; }
        public bool Ativo { get; set; }

        public BaseModel()
        {
            Id = new Guid();
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            Ativo = true;
        }
        public void InativarRegistro()
        {
            DataInativacao = DateTime.Now;
            Ativo = false;
        }
    }
}
