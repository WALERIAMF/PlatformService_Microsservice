using PlataformService.Domain.Dto;
using System.Collections.Generic;

namespace PlataformService.Domain.Request
{
    public class GrupoPermissaoPostRequest
    {
        public string Nome { get; set; }
        public List<PermissaoDto> PermissoesList { get; set; }
    }
}
