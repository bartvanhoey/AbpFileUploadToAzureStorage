using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpFileUploadToAzureStorage.Data;
using Volo.Abp.DependencyInjection;

namespace AbpFileUploadToAzureStorage.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpFileUploadToAzureStorageDbSchemaMigrator
        : IAbpFileUploadToAzureStorageDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpFileUploadToAzureStorageDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpFileUploadToAzureStorageMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpFileUploadToAzureStorageMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}