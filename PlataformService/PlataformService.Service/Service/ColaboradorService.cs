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
    public class ColaboradorService : IColaboradorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColaboradorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DesativarColaboradorAsync(Guid id)
        {
            try
            {
                #region remover
                var colaboradorOrigem = await _unitOfWork.ColaboradorRepository.FirstOrDefaultAsync(f => f.Id == id);

                if (colaboradorOrigem == null)
                    throw new CadastroDomainException($"Colaborador não encontrado {id}.");
                colaboradorOrigem.InativarRegistro();
                _unitOfWork.ColaboradorRepository.Update(colaboradorOrigem);

                await _unitOfWork.CommitAsync();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ColaboradorDto>> GetColaboradorAsync()
        {
            try
            {
                var colaboradorOrigem = await _unitOfWork.ColaboradorRepository.GetWhereAsync(a => a.Ativo != null || !a.Ativo);
                var orderColaboradorOrigem = colaboradorOrigem.OrderBy(n => n.Nome).ToList();
                var data = _mapper.Map<List<ColaboradorDto>>(orderColaboradorOrigem);

                return data;
            }

            catch (Exception ex)

            {
                throw ex;
            }
        }

        public async Task<ColaboradorDto> GetColaboradorByIdAsync(Guid id)
        {
            try
            {
                var colaboradorOrigem = await _unitOfWork.ColaboradorRepository.FirstOrDefaultAsync(f => f.Id == id);

                var data = _mapper.Map<ColaboradorDto>(colaboradorOrigem);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ColaboradorDto> GetColaboradorByNameAsync(string name)
        {
            try
            {
                var colaboradorOrigem = await _unitOfWork.ColaboradorRepository.FirstOrDefaultAsync(f => f.Nome.Contains(name));

                var data = _mapper.Map<ColaboradorDto>(colaboradorOrigem);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PostColaboradorAsync(ColaboradorPostRequest request)
        {
            try
            {
                var resultadoValidacao = new ColaboradorPostRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var colaboradorBanco = await _unitOfWork.ColaboradorRepository.FirstOrDefaultAsync(f => f.Nome.Equals(request.Nome));

                if (colaboradorBanco != null)
                    throw new CadastroDomainException("Colaborador já existe.");

                colaboradorBanco = new ColaboradorModel
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Ativo = request.Ativo

                };

                await _unitOfWork.ColaboradorRepository.AddAsync(colaboradorBanco);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PutColaboradorAsync(Guid id, ColaboradorPutRequest request)
        {
            try
            {
                var resultadoValidacao = new ColaboradorPutRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var colaboradorOrigem = _mapper.Map<ColaboradorModel>(request);

                var colaboradorBanco = await _unitOfWork.ColaboradorRepository.FirstOrDefaultAsync(f => f.Id == request.Id);

                if (colaboradorBanco == null)
                    throw new CadastroDomainException($"O colaborador não foi encontrada ${request.Id}.");

                var duplicate = await _unitOfWork.ColaboradorRepository.FirstOrDefaultAsync(f => f.Nome.Equals(request.Nome) && f.Id != request.Id);

                if (duplicate != null)
                    throw new CadastroDomainException("O colaborador com o nome informado já existe.");

                colaboradorBanco.Nome = colaboradorOrigem.Nome;
                colaboradorBanco.Email = colaboradorOrigem.Email;
                colaboradorBanco.Ativo = colaboradorOrigem.Ativo;
                colaboradorBanco.DataAtualizacao = colaboradorOrigem.DataAtualizacao;

                _unitOfWork.ColaboradorRepository.Update(colaboradorBanco);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
