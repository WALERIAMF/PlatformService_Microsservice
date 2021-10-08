using System.Collections.Generic;

namespace PlataformService.Data.Entity
{
    public class UsuarioEntity : BaseEntity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<string> GruposPermissaoIdList { get; set; }
        public string Nome { get; set; }
    }
}
