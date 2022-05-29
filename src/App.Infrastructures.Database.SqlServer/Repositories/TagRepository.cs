using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    internal class TagRepository
    {
        public static AppDbContext _eshop = new();
        public static void Create(Tag tag)
        {
            _eshop.Tags.Add(tag);
            _eshop.SaveChanges();
        }
        public static void Edit(Tag tag)
        {
            var _tag = _eshop.Tags.First(p => p.Id == tag.Id);
            _tag.Name = tag.Name;
            _tag.CreationDate = tag.CreationDate;
            _eshop.SaveChanges();
        }
        public static void Delete(int id)
        {
            var _tag = _eshop.Tags.First(p => p.Id == id);
            _eshop.Tags.Remove(_tag);
            _eshop.SaveChanges();
        }
        public static List<Tag> GetAll()
        {
            return _eshop.Tags.Include(b => b.ProductTags).ToList();
        }
        public static Tag GetById(int id)
        {
            return _eshop.Tags.First(p => p.Id == id);
        }
    }
}
