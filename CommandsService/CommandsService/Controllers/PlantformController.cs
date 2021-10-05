using AutoMapper;
using CommandsService.Application.Dto;
using CommandsService.Domain.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CommandsService.Controllers
{
    [Route("api/Control/[controller]")]
    [ApiController]
    public class PlantformController : ControllerBase
    {
        private readonly ICommandRepository _repository;
        private readonly IMapper _mapper;

        public PlantformController(ICommandRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformreadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from CommandsService");

            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformreadDto>>(platformItems));
        }


        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Platform Controller");
        }
    }
}
