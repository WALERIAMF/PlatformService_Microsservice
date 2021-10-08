using System;
using System.Collections.Generic;

namespace PlataformService.Domain.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<string> GruposPermissaoIdList { get; set; }
    }
}
