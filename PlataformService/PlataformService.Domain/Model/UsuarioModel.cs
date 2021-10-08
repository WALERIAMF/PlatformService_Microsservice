using System.Collections.Generic;

namespace PlataformService.Domain.Model
{
    public class UsuarioModel : BaseModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<string> GruposPermissaoIdList { get; set; }
        public string Nome { get; set; }
    }
}
