using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpFileUploadToAzureStorage.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpFileUploadToAzureStorageMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpFileUploadToAzureStorageMigrationsDbContext>
    {
        public AbpFileUploadToAzureStorageMigrationsDbContext CreateDbContext(string[] args)
        {
            AbpFileUploadToAzureStorageEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpFileUploadToAzureStorageMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new AbpFileUploadToAzureStorageMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpFileUploadToAzureStorage.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
