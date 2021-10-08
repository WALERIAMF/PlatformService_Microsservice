using System;
using System.Collections.Generic;

namespace PlataformService.Domain.Dto
{
    public class GrupoPermissaoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<PermissaoDto> PermissoesList { get; set; }

    }
}
