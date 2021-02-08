using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpFileUploadToAzureStorage.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpFileUploadToAzureStorageEntityFrameworkCoreModule)
        )]
    public class AbpFileUploadToAzureStorageEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpFileUploadToAzureStorageMigrationsDbContext>();
        }
    }
}
