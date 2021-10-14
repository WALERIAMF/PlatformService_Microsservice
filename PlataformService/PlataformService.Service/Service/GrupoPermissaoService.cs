using AutoMapper;
using MassTransit;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Exceptions;
using PlataformService.Domain.Interface.IService;
using PlataformService.Domain.Interface.UnitOfWork;
using PlataformService.Domain.Model;
using PlataformService.Domain.Request;
using PlataformService.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PlataformService.Service.Service
{
    public class GrupoPermissaoService : IGrupoPermissaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public GrupoPermissaoService(IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task DesativarGrupoPermissaoAsync(Guid id)
        {
            try
            {
                #region remover
                var grupoPermissaoOrigem = await _unitOfWork.GrupoPermissaoRepository.FirstOrDefault(f => f.Id == id);

                if (grupoPermissaoOrigem == null)
                    throw new CadastroDomainException($"Colaborador não encontrado {id}.");
                grupoPermissaoOrigem.InativarRegistro();
                _unitOfWork.GrupoPermissaoRepository.Update(grupoPermissaoOrigem);

                await _unitOfWork.CommitAsync();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GrupoPermissaoDto>> GetGrupoPermissaoAsync()
        {
            try
            {
                var grupoPermissaoOrigem = await _unitOfWork.GrupoPermissaoRepository.GetWhere(a => a.Ativo != null || !a.Ativo);
                var orderGrupoPermissaoOrigem = grupoPermissaoOrigem.OrderBy(n => n.Nome).ToList();
                var data = _mapper.Map<List<GrupoPermissaoDto>>(orderGrupoPermissaoOrigem);

                return data;
            }

            catch (Exception ex)

            {
                throw ex;
            }
        }

        public async Task<GrupoPermissaoDto> GetGrupoPermissaoByIdAsync(Guid id)
        {
            try
            {
                var cliente = await _unitOfWork.GrupoPermissaoRepository.FirstOrDefault(f => f.Id == id);
                var data = _mapper.Map<GrupoPermissaoDto>(cliente);

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PostGrupoPermissaoAsync(GrupoPermissaoPostRequest request)
        {
            try
            {
                var resultadoValidacao = new GrupoPermissaoPostRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var grupoPermissaoBanco = await _unitOfWork.GrupoPermissaoRepository.FirstOrDefault(f => f.Nome.Equals(request.Nome));

                if (grupoPermissaoBanco != null)
                    throw new CadastroDomainException("Grupo Permissao já existe.");

                grupoPermissaoBanco = new GrupoPermissaoModel
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    PermissoesList = request.PermissoesList
                };

                await _unitOfWork.GrupoPermissaoRepository.Add(grupoPermissaoBanco);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PutGrupoPermissaoAsync(GrupoPermissaoPutRequest request)
        {
            try
            {
                var grupoPermissaoValidacao = new GrupoPermissaoPutRequestValidator().Validate(request);
                if (!grupoPermissaoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", grupoPermissaoValidacao.Errors.Select(s => s)));

                var grupoPermissaoOrigem = _mapper.Map<GrupoPermissaoModel>(request);

                var grupoPermissaoBanco = await _unitOfWork.GrupoPermissaoRepository.FirstOrDefault(f => f.Id == request.Id);

                if (grupoPermissaoBanco == null)
                    throw new CadastroDomainException($"O Grupo Permissao não foi encontrada ${request.Id}.");

                var duplicate = await _unitOfWork.GrupoPermissaoRepository.FirstOrDefault(f => f.Nome.Equals(request.Nome) && f.Id != request.Id);

                if (duplicate != null)
                    throw new CadastroDomainException("O Grupo Permissao com o nome informado já existe.");

                grupoPermissaoBanco.Nome = grupoPermissaoOrigem.Nome;
                grupoPermissaoBanco.PermissoesList = grupoPermissaoOrigem.PermissoesList;


                _unitOfWork.GrupoPermissaoRepository.Update(grupoPermissaoBanco);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}