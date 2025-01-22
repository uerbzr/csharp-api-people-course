using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Get(int id);
        Task<bool> Delete(int id);
        Task<Person> Add(Person person);
    }
}
