using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpFileUploadToAzureStorage
{
    [Dependency(ReplaceServices = true)]
    public class AbpFileUploadToAzureStorageBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpFileUploadToAzureStorage";
    }
}
