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

        public void NovoRegistro()
        {
            Id = new Guid();
            DataCriacao = DateTime.Now;
            DataAtualizacao = null;
            Ativo = true;
        }
        public void AtualizarRegistro()
        {
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
