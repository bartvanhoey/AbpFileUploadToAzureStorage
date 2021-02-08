using AbpFileUploadToAzureStorage.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpFileUploadToAzureStorage.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpFileUploadToAzureStorageController : AbpController
    {
        protected AbpFileUploadToAzureStorageController()
        {
            LocalizationResource = typeof(AbpFileUploadToAzureStorageResource);
        }
    }
}