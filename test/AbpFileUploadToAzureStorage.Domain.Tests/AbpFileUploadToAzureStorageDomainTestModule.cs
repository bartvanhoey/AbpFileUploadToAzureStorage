using AbpFileUploadToAzureStorage.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpFileUploadToAzureStorage
{
    [DependsOn(
        typeof(AbpFileUploadToAzureStorageEntityFrameworkCoreTestModule)
        )]
    public class AbpFileUploadToAzureStorageDomainTestModule : AbpModule
    {

    }
}