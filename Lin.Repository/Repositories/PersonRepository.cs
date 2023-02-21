using Link.Repository.Entities;
using Link.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Repository.Repositories
{
    public class PersonRepository:IPersonRepository
    {
        private readonly IContext _context;
        public PersonRepository(IContext context)
        {
            _context = context;     
        }

        public async Task<Person> GetByIdAsync(string id)
        {
            return await _context.Persons.FirstOrDefault(p => p.Tz == id);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var p =await GetByIdAsync(person.Tz);
            p.FullName = person.FullName;
            p.YearOfBirth = person.YearOfBirth;
            await _context.SaveChangesAsync();
            return p;
        }
    }
}
