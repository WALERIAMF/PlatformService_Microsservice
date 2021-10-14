using PlataformService.Domain.Dto;
using System;
using System.Collections.Generic;

namespace PlataformService.Domain.Request
{
    public class GrupoPermissaoPutRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<PermissaoDto> PermissoesList { get; set; }
    }
}
