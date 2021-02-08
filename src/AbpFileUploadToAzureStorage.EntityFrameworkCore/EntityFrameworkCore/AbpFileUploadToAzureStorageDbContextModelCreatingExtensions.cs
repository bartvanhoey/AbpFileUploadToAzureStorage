using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpFileUploadToAzureStorage.EntityFrameworkCore
{
    public static class AbpFileUploadToAzureStorageDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpFileUploadToAzureStorage(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpFileUploadToAzureStorageConsts.DbTablePrefix + "YourEntities", AbpFileUploadToAzureStorageConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}