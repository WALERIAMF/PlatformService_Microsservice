using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Interface.IService;
using PlataformService.Domain.Request;
using PlataformService.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _service = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarioAsync()
        {
            var data = await _service.GetUsuarioAsync();

            return Ok(new ResponseData<List<UsuarioDto>>
            {
                Count = data.Count,
                Data = data
            });
        }

        [HttpGet("usuario/{id}", Name = "GetUsuarioformById")]
        public async Task<IActionResult> GetUsuarioById(Guid id)
        {
            var data = await _service.GetUsuarioByIdAsync(id);

            return Ok(new ResponseData<UsuarioDto>
            {
                Count = data != null ? 1 : 0,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UsuarioPostRequest request)
        {
            await _service.PostUsuarioAsync(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync(UsuarioPutRequest request)
        {

            await _service.PutUsuarioAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DesativarUsuarioAsync(id);
            return Ok();
        }
    }
}

