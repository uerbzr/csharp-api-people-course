using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<Person> Add(Person entity)
        {
            await _db.People.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;

        }

        public async Task<bool> Delete(int id)
        {
            var target = await _db.People.FindAsync(id);
            _db.People.Remove(target);
            await _db.SaveChangesAsync();
            return true;


        }      

        public async Task<Person> Get(int id)
        {
            return await _db.People.FindAsync(id);
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _db.People.ToListAsync();
        }
    }
}
