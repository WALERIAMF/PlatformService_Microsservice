using AutoMapper;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Interface.IService;
using PlataformService.Domain.Interface.UnitOfWork;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Service.Service
{
    public class GrupoPermissaoService : IGrupoPermissaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrupoPermissaoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task DesativarPermissao(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GrupoPermissaoDto>> GetColaborador()
        {
            throw new NotImplementedException();
        }

        public Task<GrupoPermissaoDto> GetColaboradorById(string nome)
        {
            throw new NotImplementedException();
        }

        public Task PostColaborador(GrupoPermissaoPostRequest request)
        {
            throw new NotImplementedException();
        }

        public Task PutColaborador(GrupoPermissaoPutRequest request)
        {
            throw new NotImplementedException();
        }
    }
}