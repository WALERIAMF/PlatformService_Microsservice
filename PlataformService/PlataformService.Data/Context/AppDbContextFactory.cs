using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PlataformService.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PlataformService.Api"))
                               .AddJsonFile("appsettings.Development.json")
                               .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("PlatformsConn");
            dbContextBuilder.UseSqlServer(connectionString); 

            return new AppDbContext(dbContextBuilder.Options);
        }
    }
}
