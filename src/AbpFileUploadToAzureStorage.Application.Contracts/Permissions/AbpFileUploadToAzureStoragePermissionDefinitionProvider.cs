using AbpFileUploadToAzureStorage.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFileUploadToAzureStorage.Permissions
{
    public class AbpFileUploadToAzureStoragePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpFileUploadToAzureStoragePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpFileUploadToAzureStoragePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpFileUploadToAzureStorageResource>(name);
        }
    }
}
