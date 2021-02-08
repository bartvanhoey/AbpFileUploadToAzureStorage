using System;
using System.Collections.Generic;
using System.Text;
using AbpFileUploadToAzureStorage.Localization;
using Volo.Abp.Application.Services;

namespace AbpFileUploadToAzureStorage
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpFileUploadToAzureStorageAppService : ApplicationService
    {
        protected AbpFileUploadToAzureStorageAppService()
        {
            LocalizationResource = typeof(AbpFileUploadToAzureStorageResource);
        }
    }
}
