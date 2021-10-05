using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IPlatformService 
    {
        Task PostPlatform(PlatformPostRequest request);
        Task PutPlatform(PlatformPutRequest request);
        Task DeletePlatform(Guid id);
        Task<List<PlatformDto>> GetPlatform();
        Task<PlatformDto> GetPlatformById(Guid id);
    }
}
