using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _appDbContext;

        public TagRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Create(Tag model)
        {
            _appDbContext.Tags.Add(model);
            _appDbContext.SaveChanges();
            return model.Id;
        }
        public void Update(Tag tag)
        {
            var record = _appDbContext.Tags.First(p => p.Id == tag.Id);
            record.Name = tag.Name;
            record.CreationDate = tag.CreationDate;
            _appDbContext.SaveChanges();
        }
        public bool Remove(int id)
        {
            var record = _appDbContext.Tags.FirstOrDefault(p => p.Id == id);
            _appDbContext.Tags.Remove(record);
            _appDbContext.SaveChanges();
            return true;
        }
        public List<Tag> GetAll()
        {
            var record = _appDbContext.Tags.ToList();
            return record;
        }
        public Tag GetById(int id)
        {
            var record = _appDbContext.Tags.FirstOrDefault(p => p.Id == id);
            return record;
        }
    }
}
