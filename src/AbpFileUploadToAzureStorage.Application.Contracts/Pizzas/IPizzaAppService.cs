using System;
using System.Threading.Tasks;
using AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas
{
  public interface IPizzaAppService : IApplicationService
  {
    Task<SavedPizzaPictureDto> SavePizzaPicture(SavePizzaPictureDto input);
    Task<PizzaPictureDto> GetPizzaPicture(GetPizzaPictureDto input);
    Task<bool> DeletePizzaPicture(DeletePizzaPictureDto input);
    Task<string> GetPizzaPictureStorageUrl(string fileName);
  }
}