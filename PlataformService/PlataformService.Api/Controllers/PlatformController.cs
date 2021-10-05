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
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _service;

        public PlatformController(IPlatformService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> GetSistemasOrigem()
        {
            var data = await _service.GetPlatform();

            return Ok(new ResponseData<List<PlatformDto>>
            {
                Count = data.Count,
                Data = data
            });
        }

        [HttpGet("platform/{id}", Name = "GetPlatformById")]
        public async Task<IActionResult> GetSistemaOrigemById(Guid id)
        {
            var data = await _service.GetPlatformById(id);

            return Ok(new ResponseData<PlatformDto>
            {
                Count = data != null ? 1 : 0,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlatformPostRequest request)
        {
            await _service.PostPlatform(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(PlatformPutRequest request)
        {

            await _service.PutPlatform(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeletePlatform(id);
            return Ok();
        }
    }
}