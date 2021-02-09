using System;
using System.Linq;
using System.Threading.Tasks;
using AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas;
using AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AbpFileUploadToAzureStorage.Blazor.Pages
{
  public partial class Index
  {
    [Inject] protected IPizzaAppService PizzaAppService { get; set; }
    public string StorageFileName { get; set; }
    public SavedPizzaPictureDto SavedPizzaPictureDto { get; set; } = new SavedPizzaPictureDto();
    protected string PictureUrl;
    protected string PictureFromStorageUrl;
    protected string PizzaPictureStorageUrl;

    protected async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
      var file = e.GetMultipleFiles(1).FirstOrDefault();
      var byteArray = new byte[file.Size];
      await file.OpenReadStream().ReadAsync(byteArray);

      SavedPizzaPictureDto = await PizzaAppService.SavePizzaPicture(new SavePizzaPictureDto { Content = byteArray, FileName = file.Name }); ;

      var format = "image/png";
      var imageFile = (e.GetMultipleFiles(1)).FirstOrDefault();
      var resizedImageFile = await imageFile.RequestImageFileAsync(format, 100, 100);
      var buffer = new byte[resizedImageFile.Size];
      await resizedImageFile.OpenReadStream().ReadAsync(buffer);
      PictureUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
    }

    protected async Task GetPizzaFromStorage()
    {
      var pizzaPictureDto = await PizzaAppService.GetPizzaPicture(new GetPizzaPictureDto { StorageFileName = SavedPizzaPictureDto.StorageFileName });
      PictureFromStorageUrl = pizzaPictureDto.PictureUrl;
    }

    protected async Task GetStorageUrl()
    {
      PizzaPictureStorageUrl = await PizzaAppService.GetPizzaPictureStorageUrl(SavedPizzaPictureDto.StorageFileName);
    }

    protected async Task DeletePicture()
    {
      var result = await PizzaAppService.DeletePizzaPicture(new DeletePizzaPictureDto { StorageFileName = SavedPizzaPictureDto.StorageFileName });
      PictureFromStorageUrl = null;
      PizzaPictureStorageUrl = null;
    }

  }
}
