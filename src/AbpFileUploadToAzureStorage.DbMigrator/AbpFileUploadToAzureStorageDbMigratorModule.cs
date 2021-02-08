using AbpFileUploadToAzureStorage.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpFileUploadToAzureStorage.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpFileUploadToAzureStorageEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpFileUploadToAzureStorageApplicationContractsModule)
        )]
    public class AbpFileUploadToAzureStorageDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
