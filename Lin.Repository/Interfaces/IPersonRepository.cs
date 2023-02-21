using Link.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Repository.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person> GetByIdAsync(string id);
        public Task<Person> UpdateAsync(Person person);
    }
}
