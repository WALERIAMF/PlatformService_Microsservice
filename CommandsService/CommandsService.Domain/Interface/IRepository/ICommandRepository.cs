using CommandsService.Domain.Models;
using System.Collections.Generic;

namespace CommandsService.Domain.Interface.IRepository
{
    public interface ICommandRepository
    {
        bool SaveChanges();

        // Platforms
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform plat);
        bool PlaformExits(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);

        // Commands
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);
    }
}