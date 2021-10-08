using PlataformService.Domain.Model;
using System;

namespace PlataformService.Domain.Dto
{
    public class PermissaoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public GrupoPermissaoModel GrupoPermissaoModel { get; set; }
    }
}
