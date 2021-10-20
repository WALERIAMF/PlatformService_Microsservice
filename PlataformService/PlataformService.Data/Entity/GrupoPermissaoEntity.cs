using PlataformService.Domain.Model;
using System.Collections.Generic;

namespace PlataformService.Data.Entity
{
    public class GrupoPermissaoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public IList<PermissaoModel> PermissoesIdList { get; set; }
    }
}
