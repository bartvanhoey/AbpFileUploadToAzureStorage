using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpFileUploadToAzureStorage.Data
{
    /* This is used if database provider does't define
     * IAbpFileUploadToAzureStorageDbSchemaMigrator implementation.
     */
    public class NullAbpFileUploadToAzureStorageDbSchemaMigrator : IAbpFileUploadToAzureStorageDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}