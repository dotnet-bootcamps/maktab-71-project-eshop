using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Validations
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UploadFileExtentionsAttribute : ValidationAttribute
    {
        private readonly IList<string> _allowedExtensions;
        public UploadFileExtentionsAttribute(string fileExtensions)
        {
            _allowedExtensions = fileExtensions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public string GetErrorMessage() => "لطفا فایل عکس آپلود کنید";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (isValidFile(file))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(GetErrorMessage());
            }

            var files = value as IList<IFormFile>;
            if (files == null)
            {
                return new ValidationResult(GetErrorMessage());
            }

            foreach (var postedFile in files)
            {
                if (!isValidFile(postedFile)) return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private bool isValidFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }

            var fileExtension = Path.GetExtension(file.FileName);
            return !string.IsNullOrWhiteSpace(fileExtension) &&
                   _allowedExtensions.Any(ext => fileExtension.Equals(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}
