using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IColaboradorService
    {
        Task PostColaboradorAsync(ColaboradorPostRequest request);
        Task PutColaboradorAsync(Guid id, ColaboradorPutRequest request);
        Task DesativarColaboradorAsync(Guid id);
        Task<List<ColaboradorDto>> GetColaboradorAsync();
        Task<ColaboradorDto> GetColaboradorByIdAsync(Guid id);
    }
}
