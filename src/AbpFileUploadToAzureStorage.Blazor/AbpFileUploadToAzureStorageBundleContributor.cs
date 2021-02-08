using Volo.Abp.Bundling;

namespace AbpFileUploadToAzureStorage.Blazor
{
    public class AbpFileUploadToAzureStorageBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}