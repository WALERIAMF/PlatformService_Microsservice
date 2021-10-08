using PlataformService.Domain.Model;
using PlataformService.Domain.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IColaboradorService
    {
        Task PostPlatform(ColaboradorPostRequest request);
        Task PutPlatform(ColaboradorPutRequest request);
        Task DeletePlatform(Guid id);
        Task<List<ColaboradorDto>> GetPlatform();
        Task<ColaboradorDto> GetPlatformById(Guid id);
    }
}
