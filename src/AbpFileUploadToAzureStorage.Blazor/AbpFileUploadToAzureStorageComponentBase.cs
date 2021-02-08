using AbpFileUploadToAzureStorage.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpFileUploadToAzureStorage.Blazor
{
    public abstract class AbpFileUploadToAzureStorageComponentBase : AbpComponentBase
    {
        protected AbpFileUploadToAzureStorageComponentBase()
        {
            LocalizationResource = typeof(AbpFileUploadToAzureStorageResource);
        }
    }
}
