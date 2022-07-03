using System.Net.Http.Headers;

namespace App.EndPoints.Mvc.ShopUI.Services
{
    public class UploadFileService : IUploadFileService
    {

        public async Task<List<string>> Upload(List<IFormFile> FormFile)
        {
            var files = new List<string>();
            foreach (var formFile in FormFile)
            {
                if (formFile.Length > 0)
                {
                    var filename = Path.Combine("Upload",Guid.NewGuid().ToString() +
                        ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"'));
                    files.Add(filename);
                    using (var stream = System.IO.File.Create(filename))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return files;
        }

        public Task<List<string>> Download(int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
