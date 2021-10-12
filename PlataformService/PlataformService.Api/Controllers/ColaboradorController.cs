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
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _service;
        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _service = colaboradorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSistemasOrigem()
        {
            var data = await _service.GetColaborador();

            return Ok(new ResponseData<List<ColaboradorDto>>
            {
                Count = data.Count,
                Data = data
            });
        }

        [HttpGet("colaborador/{id}", Name = "GetColaboradorformById")]
        public async Task<IActionResult> GetSistemaOrigemById(Guid id)
        {
            var data = await _service.GetColaboradorById(id);

            return Ok(new ResponseData<ColaboradorDto>
            {
                Count = data != null ? 1 : 0,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(ColaboradorPostRequest request)
        {
            await _service.PostColaborador(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(ColaboradorPutRequest request)
        {

            await _service.PutColaborador(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DesativarColaborador(id);
            return Ok();
        }
    }
}

