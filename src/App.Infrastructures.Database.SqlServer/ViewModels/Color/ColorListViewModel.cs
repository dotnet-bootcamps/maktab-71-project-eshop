using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.ViewModels.Color
{
    public class ColorListViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "کد رنگ")]
        public string Code { get; set; } = String.Empty;
        [Display(Name = "نام")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
