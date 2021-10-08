using System.Collections.Generic;

namespace PlataformService.Data.Entity
{
    public class GrupoPermissaoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public List<string> PermissoesIdList { get; set; }
    }
}
