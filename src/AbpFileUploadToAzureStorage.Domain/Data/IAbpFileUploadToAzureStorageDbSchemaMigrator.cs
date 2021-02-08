using System.Threading.Tasks;

namespace AbpFileUploadToAzureStorage.Data
{
    public interface IAbpFileUploadToAzureStorageDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
