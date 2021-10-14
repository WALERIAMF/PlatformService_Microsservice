using System.Collections.Generic;

namespace PlataformService.Domain.Request
{
    public class UsuarioPostRequest
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public List<string> GruposPermissaoIdList { get; set; }
    }
}
