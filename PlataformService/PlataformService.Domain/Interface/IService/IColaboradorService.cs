using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IColaboradorService
    {
        Task PostColaborador(ColaboradorPostRequest request);
        Task PutColaborador(Guid id, ColaboradorPutRequest request);
        Task DesativarColaborador(Guid id);
        Task<List<ColaboradorDto>> GetColaborador();
        Task<ColaboradorDto> GetColaboradorById(Guid id);
    }
}
