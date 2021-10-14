using PlataformService.Domain.Dto;
using System;
using System.Collections.Generic;

namespace PlataformService.Domain.Model
{
    public class UsuarioModel : BaseModel
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<GrupoPermissaoDto> GruposPermissaoList { get; set; }

        public static implicit operator UsuarioModel(UsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
