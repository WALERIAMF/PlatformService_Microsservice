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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DesativarUsuarioAsync(Guid id)
        {
            try
            {
                var usuarioOrigem = await _unitOfWork.UsuarioRepository.FirstOrDefault(f => f.Id == id);

                if (usuarioOrigem == null)
                    throw new CadastroDomainException($"Usuário não encontrado {id}.");

                usuarioOrigem.InativarRegistro();
                _unitOfWork.UsuarioRepository.Update(usuarioOrigem);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioDto>> GetUsuarioAsync()
        {
            var usuarioOrigem = await _unitOfWork.UsuarioRepository.GetWhere(a => a.Ativo != null || !a.Ativo);
            var orderUsuarioOrigem = usuarioOrigem.OrderBy(n => n.Nome).ToList();
            var data = _mapper.Map<List<UsuarioDto>>(orderUsuarioOrigem);

            return data;
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(Guid id)
        {
            try
            {
                var usuarioOrigem = await _unitOfWork.UsuarioRepository.FirstOrDefault(f => f.Id == id);

                var data = _mapper.Map<UsuarioDto>(usuarioOrigem);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PostUsuarioAsync(UsuarioPostRequest request)
        {
            try
            {
                var resultadoValidacao = new UsuarioPostRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var usuarioBanco = await _unitOfWork.UsuarioRepository.FirstOrDefault(f => f.Nome.Equals(request.Nome));

                if (usuarioBanco != null)
                    throw new CadastroDomainException("Usuário já existe.");

                usuarioBanco = new UsuarioModel
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Login = request.Login,
                    Ativo = request.Ativo,
                };

                await _unitOfWork.UsuarioRepository.Add(usuarioBanco);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PutUsuarioAsync(UsuarioPutRequest request)
        {
            try
            {
                var resultadoValidacao = new UsuarioPutRequestValidator().Validate(request);
                if (!resultadoValidacao.IsValid)
                    throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));

                var usuarioOrigem = _mapper.Map<UsuarioModel>(request);

                var usuarioBanco = await _unitOfWork.UsuarioRepository.FirstOrDefault(f => f.Id == request.Id);

                if (usuarioBanco == null)
                    throw new CadastroDomainException($"Usuário não encontrado ${request.Id}.");

                var duplicate = await _unitOfWork.UsuarioRepository.FirstOrDefault(f => f.Nome.Equals(request.Nome) && f.Id != request.Id);

                if (duplicate != null)
                    throw new CadastroDomainException("Usuário com o nome informado já existe.");

                usuarioBanco.Nome = usuarioOrigem.Nome;
                usuarioBanco.Login = usuarioOrigem.Login;
                usuarioBanco.Senha = usuarioOrigem.Senha;
                usuarioBanco.Ativo = usuarioOrigem.Ativo;
                usuarioBanco.DataAtualizacao = usuarioOrigem.DataAtualizacao;

                _unitOfWork.UsuarioRepository.Update(usuarioBanco);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}