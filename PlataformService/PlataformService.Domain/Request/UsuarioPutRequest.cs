using PlataformService.Domain.Dto;
using System;
using System.Collections.Generic;

namespace PlataformService.Domain.Request
{
    class UsuarioPutRequest
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<GrupoPermissaoDto> GruposPermissaoList { get; set; }
        public bool Ativo { get; set; }
    }
}
