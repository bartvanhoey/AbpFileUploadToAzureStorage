namespace AbpFileUploadToAzureStorage.Application.Contracts.AzureStorage.Pizzas.Dtos
{
  public class SavePizzaPictureDto
  {
    public string FileName { get; set; }
    public byte[] Content { get; set; }
  }
}