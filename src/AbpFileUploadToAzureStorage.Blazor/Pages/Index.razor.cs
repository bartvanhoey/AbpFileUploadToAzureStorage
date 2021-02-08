using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace AbpFileUploadToAzureStorage.Blazor.Pages
{
  public partial class Index
  {


    protected IList<string> imageDataUrls = new List<string>();

    protected async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
      var maxAllowedFiles = 3;
      var format = "image/png";

      foreach (var imageFile in e.GetMultipleFiles(maxAllowedFiles))
      {
        var resizedImageFile = await imageFile.RequestImageFileAsync(format,
            100, 100);
        var buffer = new byte[resizedImageFile.Size];
        await resizedImageFile.OpenReadStream().ReadAsync(buffer);
        var imageDataUrl =
            $"data:{format};base64,{Convert.ToBase64String(buffer)}";
        imageDataUrls.Add(imageDataUrl);
      }
    }
  }
}
