using Microsoft.AspNetCore.Mvc;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Interface.IService;
using PlataformService.Domain.Request;
using PlataformService.Domain.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoPermissaoController : ControllerBase
    {
        private readonly IGrupoPermissaoService _service;
        public GrupoPermissaoController(IGrupoPermissaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGrupoPermissao()
        {
            var data = await _service.GetGrupoPermissaoAsync();

            return Ok(new ResponseData<List<GrupoPermissaoDto>>
            {
                Count = data.Count,
                Data = data
            });
        }

        [HttpGet("grupoPermissao/{id}", Name = "GetGrupoPermissaoformById")]
        public async Task<IActionResult> GetGrupoPermissaoById(Guid id)
        {
            var data = await _service.GetGrupoPermissaoByIdAsync(id);

            return Ok(new ResponseData<GrupoPermissaoDto>
            {
                Count = data != null ? 1 : 0,
                Data = data
            });
        }

        [HttpGet("grupoPermissao/{nome}", Name = "GetGrupoPermissaoformByName")]
        public async Task<IActionResult> GetGrupoPermissaoByName(string name)
        {
            var data = await _service.GetGrupoPermissaoByNameAsync(name);

            return Ok(new ResponseData<GrupoPermissaoDto>
            {
                Count = data != null ? 1 : 0,
                Data = data
            });
        }


        [HttpPost]
        public async Task<IActionResult> Post(GrupoPermissaoPostRequest request)
        {
            await _service.PostGrupoPermissaoAsync(request);
            return Ok();
        }


        [HttpPut("grupoPermissao/{id}", Name = "PutGrupoPermissaoAsync")]
        public async Task<IActionResult> Put(GrupoPermissaoPutRequest request)
        {

            await _service.PutGrupoPermissaoAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DesativarGrupoPermissaoAsync(id);
            return Ok();
        }
    }
}

