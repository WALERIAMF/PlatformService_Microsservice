using System.Collections.Generic;

namespace PlataformService.Domain.Model
{
    public class GrupoPermissaoModel : BaseModel
    {
        public string Nome { get; set; }
        public List<string> PermissoesIdList { get; set; }
    }
}
