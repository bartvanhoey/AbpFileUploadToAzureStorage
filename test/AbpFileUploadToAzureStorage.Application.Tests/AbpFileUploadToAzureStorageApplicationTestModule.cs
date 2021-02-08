using Volo.Abp.Modularity;

namespace AbpFileUploadToAzureStorage
{
    [DependsOn(
        typeof(AbpFileUploadToAzureStorageApplicationModule),
        typeof(AbpFileUploadToAzureStorageDomainTestModule)
        )]
    public class AbpFileUploadToAzureStorageApplicationTestModule : AbpModule
    {

    }
}