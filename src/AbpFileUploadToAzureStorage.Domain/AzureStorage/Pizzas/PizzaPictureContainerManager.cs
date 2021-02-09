using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Services;

namespace AbpFileUploadToAzureStorage.Domain.AzureStorage.Pizzas
{
  public class PizzaPictureContainerManager : DomainService
  {
    private readonly IBlobContainer<PizzaPictureContainer> _pizzaPictureContainer;
    private readonly AzureStorageAccountOptions _azureStorageAccountOptions;

    public PizzaPictureContainerManager(IBlobContainer<PizzaPictureContainer> pizzaPictureContainer, IOptions<AzureStorageAccountOptions> azureStorageAccountOptions)
    {
      _pizzaPictureContainer = pizzaPictureContainer;
      _azureStorageAccountOptions = azureStorageAccountOptions.Value;
    }

    public async Task<string> SaveAsync(string fileName, byte[] byteArray, bool overrideExisting = false)
    {
      var extension = Path.GetExtension(fileName);

      ValidateExtension(extension);

      var storageFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{Guid.NewGuid()}{extension}";
      await _pizzaPictureContainer.SaveAsync(storageFileName, byteArray, overrideExisting);

      return storageFileName;
    }

    public async Task<Stream> GetAsync(string fileName)
    {
      return await _pizzaPictureContainer.GetAsync(fileName);
    }

    public async Task<bool> DeleteAsync(string fileName)
    {
      var result =  await _pizzaPictureContainer.DeleteAsync(fileName);
      return result;
    }

    public string GetStorageUrl(string fileName)
    {
      return $"{_azureStorageAccountOptions.AccountUrl}pizza-picture-container/host/{fileName}";
    }

    private void ValidateExtension(string extension)
    {
      var allowedPictureExtensions = new[] { ".jpg", ".png", ".bmp", ".svg" };
      if (!allowedPictureExtensions.Contains(extension)) throw new BadImageFormatException();
    }
  }
}