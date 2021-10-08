using PlataformService.Domain.Model;

namespace PlataformService.Domain.Request
{
    public class PermissaoPostRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public GrupoPermissaoModel GrupoPermissaoModel { get; set; }
    }
}
