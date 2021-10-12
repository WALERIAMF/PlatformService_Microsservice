using AutoMapper;
using MassTransit;
using Newtonsoft.Json;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Enum;
using PlataformService.Domain.Exceptions;
using PlataformService.Domain.Interface.IService;
using PlataformService.Domain.Interface.UnitOfWork;
using PlataformService.Domain.Model;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformService.Service.Service
{
    public class PlatformService : IPlatformService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IPublishEndpoint _publishEndpoint;

        public PlatformService(IUnitOfWork unitOfWork, IMapper mapper/*, IPublishEndpoint publishEndpoint*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_publishEndpoint = publishEndpoint;
        }

      
        public async Task<List<PlatformDto>> GetPlatform()
        {
            try
            {

                var platformOrigem = await _unitOfWork.PlatformRepository.GetWhere(g => g.Ativo != null || !g.Ativo);

                var orderedPlatformOrigem = platformOrigem.OrderBy(o => o.Name).ToList();

                var data = _mapper.Map<List<PlatformDto>>(orderedPlatformOrigem);

                return data;
            }
            catch (Exception ex)
            {
                //await _publishEndpoint.Publish<IRegisterLogCommand>(new
                //{
                //    Source = "PlatformService",
                //    Name = "GetPlatform",
                //    TimeStamp = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(new { Message = ex.Message }),
                //    Type = nameof(TypeMessage.Erro)
                //});

                throw ex;
            }
        }

        public async Task<PlatformDto> GetPlatformById(Guid id)
        {
            try
            {
                var platformOrigem = await _unitOfWork.PlatformRepository.FirstOrDefault(f => f.Id == id);

                var data = _mapper.Map<PlatformDto>(platformOrigem);

                return data;
            }

            catch (Exception ex)
            {
                //await _publishEndpoint.Publish<IRegisterLogCommand>(new
                //{
                //    Source = "PlatformService",
                //    Name = "GetPlatformById",
                //    TimeStamp = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(new { Message = ex.Message }),
                //    Type = nameof(TypeMessage.Erro)
                //});

                throw ex;
            }
        }

        public async Task PostPlatform(PlatformPostRequest request)
        {
            try
            {
                var platformBanco = await _unitOfWork.PlatformRepository.FirstOrDefault(f => f.Name.Equals(request.Name));

                if (platformBanco != null)
                    throw new CadastroDomainException("Plataforma já existe.");

                platformBanco = new PlatformModel
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Publisher = request.Publisher,
                    Cost = request.Cost
                };

                await _unitOfWork.PlatformRepository.Add(platformBanco);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //await _publishEndpoint.Publish<IRegisterLogCommand>(new
                //{
                //    Source = "PlatformService",
                //    Name = "PostPlatform",
                //    TimeStamp = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(new { Message = ex.Message }),
                //    Type = nameof(TypeMessage.Erro)
                //});
                throw ex;
            }

        }

        public async Task PutPlatform(PlatformPutRequest request)
        {
            try
            {
                var platformOrigem = _mapper.Map<PlatformModel>(request);

                var platformBanco = await _unitOfWork.PlatformRepository.FirstOrDefault(f => f.Id == request.Id);

                if (platformBanco == null)
                    throw new CadastroDomainException($"A plataforma não foi encontrada ${request.Id}.");

                var duplicate = await _unitOfWork.PlatformRepository.FirstOrDefault(f => f.Name.Equals(request.Name) && f.Id != request.Id);

                if (duplicate != null)
                    throw new CadastroDomainException("A plataforma com o nome informado já existe.");

                platformBanco.Name = platformOrigem.Name;
                platformBanco.Publisher = platformOrigem.Publisher;
                platformBanco.Cost = platformOrigem.Cost;
                platformBanco.DataAtualizacao = platformOrigem.DataAtualizacao;

                _unitOfWork.PlatformRepository.Update(platformBanco);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //await _publishEndpoint.Publish<IRegisterLogCommand>(new
                //{
                //    Source = "PlatformService",
                //    Name = "PutPlatform",
                //    TimeStamp = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(new { Message = ex.Message }),
                //    Type = nameof(TypeMessage.Erro)
                //});
                throw ex;
            }
        }

        public async Task DeletePlatform(Guid id)
        {
            try
            {
                #region remover
                var platformOrigem = await _unitOfWork.PlatformRepository.FirstOrDefault(f => f.Id == id);

                if (platformOrigem == null)
                    throw new CadastroDomainException($"Plataforma não encontrada {id}.");

                _unitOfWork.PlatformRepository.Remove(platformOrigem);

                await _unitOfWork.CommitAsync();
                #endregion

            }
            catch (Exception ex)
            {
                //await _publishEndpoint.Publish<IRegisterLogCommand>(new
                //{
                //    Source = "PlatformService",
                //    Name = "DeletePlatform",
                //    TimeStamp = DateTime.Now,
                //    Data = JsonConvert.SerializeObject(new { Message = ex.Message }),
                //    Type = nameof(TypeMessage.Erro)
                //});

                throw ex;
            }
        }
    }
}
