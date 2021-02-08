using Volo.Abp.Settings;

namespace AbpFileUploadToAzureStorage.Settings
{
    public class AbpFileUploadToAzureStorageSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpFileUploadToAzureStorageSettings.MySetting1));
        }
    }
}
