namespace App.EndPoints.Mvc.ShopUI.Services
{
    public interface IUploadFileService
    {
         Task<List<string>> Upload(List<IFormFile> FormFile);
        Task<List<string>> Download(int ProductId);

    }
}
