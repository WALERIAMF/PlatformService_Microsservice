using CommandsService.Data.Context;
using CommandsService.Domain.Interface.IRepository;
using CommandsService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandsService.Data.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext _context;

        public CommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(Guid platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);
        }

        public bool ExternalPlatformExists(Guid externalPlatformId)
        {
            return _context.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(Guid platformId, Guid commandId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(Guid platformId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlaformExits(Guid platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}