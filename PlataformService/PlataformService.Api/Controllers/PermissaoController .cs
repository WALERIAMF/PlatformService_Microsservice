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
    public class PermissaoController : ControllerBase
    {
        private readonly IPermissaoService _service;
        public PermissaoController(IPermissaoService service)
        {
            _service = service;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetPermissao()
        //{
        //    var data = await _service.GetPermissaoAsync();

        //    return Ok(new ResponseData<List<PermissaoDto>>
        //    {
        //        Count = data.Count,
        //        Data = data
        //    });
        //}


        //[HttpGet("Permissao/{id}", Name = "GetPermissaoformById")]
        //public async Task<IActionResult> GetPermissaoById(Guid id)
        //{
        //    var data = await _service.GetPermissaoByIdAsync(id);

        //    return Ok(new ResponseData<PermissaoDto>
        //    {
        //        Count = data != null ? 1 : 0,
        //        Data = data
        //    });
        //}


        ////[HttpGet("Permissao/{nome}", Name = "GetPermissaoformByName")]
        ////public async Task<IActionResult> GetPermissaoByName(string name)
        ////{
        ////    var data = await _service.GetPermissaoByNomeAsync(name);

        ////    return Ok(new ResponseData<PermissaoDto>
        ////    {
        ////        Count = data != null ? 1 : 0,
        ////        Data = data
        ////    });
        ////}


        //[HttpPost]
        //public async Task<IActionResult> Post(PermissaoPostRequest request)
        //{
        //    await _service.PostPermissaoAsync(request);
        //    return Ok();
        //}


        //[HttpPut]
        //public async Task<IActionResult> Put(PermissaoPutRequest request)
        //{

        //    await _service.PutPermissaoAsync(request);
        //    return Ok();
        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    await _service.DesativarPermissaoAsync(id);
        //    return Ok();
        //}
    }
}

