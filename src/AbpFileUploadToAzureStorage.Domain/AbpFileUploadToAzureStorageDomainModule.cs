using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AbpFileUploadToAzureStorage.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.BlobStoring.Azure;
using Volo.Abp.BlobStoring;
using AbpFileUploadToAzureStorage.Domain.AzureStorage;
using Microsoft.Extensions.Configuration;

namespace AbpFileUploadToAzureStorage
{
  [DependsOn(
      typeof(AbpFileUploadToAzureStorageDomainSharedModule),
      typeof(AbpAuditLoggingDomainModule),
      typeof(AbpBackgroundJobsDomainModule),
      typeof(AbpFeatureManagementDomainModule),
      typeof(AbpIdentityDomainModule),
      typeof(AbpPermissionManagementDomainIdentityModule),
      typeof(AbpIdentityServerDomainModule),
      typeof(AbpPermissionManagementDomainIdentityServerModule),
      typeof(AbpSettingManagementDomainModule),
      typeof(AbpTenantManagementDomainModule),
      typeof(AbpEmailingModule)
  )]
  [DependsOn(typeof(AbpBlobStoringAzureModule))]
  public class AbpFileUploadToAzureStorageDomainModule : AbpModule
  {


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
      var configuration = context.Services.GetConfiguration();

      Configure<AbpMultiTenancyOptions>(options =>
      {
        options.IsEnabled = MultiTenancyConsts.IsEnabled;
      });

      ConfigureAbpBlobStoringOptions(configuration);

      ConfigureAzureStorageAccountOptions(context, configuration);



#if DEBUG
      context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }

    private void ConfigureAbpBlobStoringOptions(IConfiguration configuration)
    {
      Configure<AbpBlobStoringOptions>(options =>
      {
        var azureStorageConnectionString = configuration["AzureStorageAccountSettings:ConnectionString"];
        options.Containers.Configure<PizzaPictureContainer>(container =>
        {
          container.UseAzure(azure =>
                {
                  azure.ConnectionString = azureStorageConnectionString;
                  azure.CreateContainerIfNotExists = true;
                });
        });
      });
    }

    private void ConfigureAzureStorageAccountOptions(ServiceConfigurationContext context, IConfiguration configuration)
    {
      Configure<AzureStorageAccountOptions>(options =>
      {
        var azureStorageConnectionString = configuration["AzureStorageAccountSettings:ConnectionString"];
        var azureStorageAccountUrl = configuration["AzureStorageAccountSettings:AccountUrl"];

        options.ConnectionString = azureStorageConnectionString;
        options.AccountUrl = azureStorageAccountUrl;
      });
    }

  }
}
