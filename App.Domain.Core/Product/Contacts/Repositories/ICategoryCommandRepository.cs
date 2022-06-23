using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface ICategoryCommandRepository
    {
        Task AddCategory(string name, int displayOrder,int  ParentCagetoryId ,DateTime creationDate, bool isDeleted);
        void UpdateCategory(int id, string name, int ParentCagetoryId ,  int displayOrder);
        void DeleteCategory(int id);
    }
}
