using AutoMapper;
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
    public class PermissaoService : IPermissaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissaoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DesativarPermissaoAsync(Guid id)
        {
            try
            {
                var permissaoOrigem = await _unitOfWork.PermissaoRepository.FirstOrDefaultAsync(f => f.Id == id);

                if (permissaoOrigem == null)
                    throw new CadastroDomainException($"Permissao não encontrado {id}.");

                permissaoOrigem.InativarRegistro();
                _unitOfWork.PermissaoRepository.Update(permissaoOrigem);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PermissaoDto>> GetPermissaoAsync()
        {
            var permissaoOrigem = await _unitOfWork.PermissaoRepository.GetWhereAsync(a => a.Ativo != null || !a.Ativo);
            var orderPermissaoOrigem = permissaoOrigem.OrderBy(n => n.Nome).ToList();
            var data = _mapper.Map<List<PermissaoDto>>(orderPermissaoOrigem);

            return data;
        }

        public async Task<PermissaoDto> GetPermissaoByIdAsync(Guid id)
        {
            try
            {
                var permissaoOrigem = await _unitOfWork.PermissaoRepository.FirstOrDefaultAsync(f => f.Id == id);

                var data = _mapper.Map<PermissaoDto>(permissaoOrigem);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PermissaoDto> GetPermissaoByNameAsync(string name)
        {
            try
            {
                var permissaoOrigem = await _unitOfWork.PermissaoRepository.FirstOrDefaultAsync(f => f.Nome.Contains(name));

                var data = _mapper.Map<PermissaoDto>(permissaoOrigem);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PostPermissaoAsync(PermissaoPostRequest request)
        {
            try
            {
                var resultadoValidacao = new PermissaoPostRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var permissaoBanco = await _unitOfWork.PermissaoRepository.FirstOrDefaultAsync(f => f.Nome.Equals(request.Nome));

                if (permissaoBanco != null)
                    throw new CadastroDomainException("Permissão já existe.");

                permissaoBanco = new PermissaoModel
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    Ativo = request.Ativo,
                    GrupoPermissaoModel = request.GrupoPermissaoModel

                };

                await _unitOfWork.PermissaoRepository.AddAsync(permissaoBanco);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PutPermissaoAsync(PermissaoPutRequest request)
        {
            try
            {
                var resultadoValidacao = new PermissaoPutRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var permissaoOrigem = _mapper.Map<PermissaoModel>(request);

                var permissaoBanco = await _unitOfWork.PermissaoRepository.FirstOrDefaultAsync(f => f.Id == request.Id);

                if (permissaoBanco == null)
                    throw new CadastroDomainException($"A permissão não foi encontrada ${request.Id}.");

                var duplicate = await _unitOfWork.PermissaoRepository.FirstOrDefaultAsync(f => f.Nome.Equals(request.Nome) && f.Id != request.Id);

                if (duplicate != null)
                    throw new CadastroDomainException("A permissão com o nome informado já existe.");

                permissaoBanco.Nome = permissaoOrigem.Nome;
                permissaoBanco.Descricao = permissaoOrigem.Descricao;
                permissaoBanco.Ativo = permissaoOrigem.Ativo;
                permissaoBanco.DataAtualizacao = permissaoOrigem.DataAtualizacao;

                _unitOfWork.PermissaoRepository.Update(permissaoBanco);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
