using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _eshop;

        public TagRepository(AppDbContext appDbContext)
        {
            this._eshop = appDbContext;
        }

        public void Create(Tag tag)
        {
            _eshop.Tags.Add(tag);
            _eshop.SaveChanges();
        }
        public void Update(Tag tag)
        {
            var _tag = _eshop.Tags.First(p => p.Id == tag.Id);
            _tag.Name = tag.Name;
            _tag.CreationDate = tag.CreationDate;
            _eshop.SaveChanges();
        }
        public void Remove(int id)
        {
            var _tag = _eshop.Tags.First(p => p.Id == id);
            _eshop.Tags.Remove(_tag);
            _eshop.SaveChanges();
        }
        public List<Tag> GetAll()
        {
            return _eshop.Tags.Include(b => b.ProductTags).ToList();
        }
        public Tag GetById(int id)
        {
            return _eshop.Tags.First(p => p.Id == id);
        }
    }
}
