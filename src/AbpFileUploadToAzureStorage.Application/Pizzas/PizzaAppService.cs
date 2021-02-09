using System.Threading.Tasks;
using AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas;
using AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas.Dtos;
using AbpFileUploadToAzureStorage.Domain.AzureStorage.Pizzas;
using Volo.Abp.Application.Services;

namespace AbpFileUploadToAzureStorage.Application.AzureStorage.Pizzas
{

  public class PizzaAppService : ApplicationService, IPizzaAppService
  {
    private readonly PizzaPictureContainerManager _pizzaPictureContainerManager;

    public PizzaAppService(PizzaPictureContainerManager pizzaPictureContainerManager)
    {
      _pizzaPictureContainerManager = pizzaPictureContainerManager;
    }

    public async Task<bool> DeletePizzaPicture(DeletePizzaPictureDto input)
    {
      return await _pizzaPictureContainerManager.DeleteAsync(input.StorageFileName);
    }

    public async Task<PizzaPictureDto> GetPizzaPicture(GetPizzaPictureDto input)
    {
      var stream = await _pizzaPictureContainerManager.GetAsync(input.StorageFileName);
      stream.Position = 0;
      var format = "image/png";
      var buffer = new byte[stream.Length];
      await stream.ReadAsync(buffer);
      var pictureUrl = $"data:{format};base64,{System.Convert.ToBase64String(buffer)}";
      return new PizzaPictureDto { PictureUrl = pictureUrl };
    }

    public async Task<SavedPizzaPictureDto> SavePizzaPicture(SavePizzaPictureDto input)
    {
      var storageFileName = await _pizzaPictureContainerManager.SaveAsync(input.FileName, input.Content, true);
      return new SavedPizzaPictureDto { StorageFileName = storageFileName };
    }

    public Task<string> GetPizzaPictureStorageUrl(string fileName)
    {
      var url = _pizzaPictureContainerManager.GetStorageUrl(fileName);
      return Task.FromResult(url);
    }

  }
}