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
    public class PermissaoService : IPermissaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissaoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task DesativarPermissao(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PermissaoDto>> GetColaborador()
        {
            throw new NotImplementedException();
        }

        public Task<PermissaoDto> GetColaboradorById(string nome)
        {
            throw new NotImplementedException();
        }

        public Task PostColaborador(PermissaoPostRequest request)
        {
            throw new NotImplementedException();
        }

        public Task PutColaborador(PermissaoPutRequest request)
        {
            throw new NotImplementedException();
        }
    }
}