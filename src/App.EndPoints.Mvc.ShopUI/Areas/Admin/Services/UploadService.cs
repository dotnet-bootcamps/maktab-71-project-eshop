using App.Domain.Core.BaseData.Contarcts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Services
{
    public class UploadService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IFileTypeAppService _fileTypeAppService;

        public UploadService(IWebHostEnvironment environment, IFileTypeAppService fileTypeAppService)
        {
            _environment = environment;
            _fileTypeAppService = fileTypeAppService;
        }

        public async Task<List<string>> AddFile(ICollection<IFormFile> files)
        {
            List<string> filesList = new List<string>();
            var uploads = Path.Combine(_environment.WebRootPath, "Upload");
            var rondom = "";
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    rondom = Guid.NewGuid() + file.FileName;
                    using (var fileStream = new FileStream(Path.Combine(uploads,rondom), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                await _fileTypeAppService.Set(rondom, 1);
                filesList.Add(rondom);
            }
            return filesList;
            
        }
    }
}
