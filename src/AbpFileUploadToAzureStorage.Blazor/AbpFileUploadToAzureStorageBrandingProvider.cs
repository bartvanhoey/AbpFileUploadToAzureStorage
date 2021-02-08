using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpFileUploadToAzureStorage.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpFileUploadToAzureStorageBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpFileUploadToAzureStorage";
    }
}
