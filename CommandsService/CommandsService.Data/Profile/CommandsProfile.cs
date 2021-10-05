
using CommandsService.Application.Dto;
using CommandsService.Domain.Models;

namespace CommandsService.Data.Profile
{
    public class CommandsProfile : AutoMapper.Profile
    {
        public CommandsProfile()
        {

            CreateMap<Platform, PlatformreadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();


        }
    }
}