using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Admin.DB
{
    public class AdminContextFactory : IDesignTimeDbContextFactory<AdminContext>
    {
        private const string DesignSettingsFile = "";
        public AdminContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminContext>();
            optionsBuilder.UseSqlServer(GetConfiguration(DesignSettingsFile).GetConnectionString("AdminDatabase").TrustedConnectionString());
            return new AdminContext(optionsBuilder.Options);
        }

        private static IConfiguration GetConfiguration(string configFile)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(configFile, true, true);
            return builder.Build();
        }

    }
}