using Link.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Repository.Interfaces
{
    public interface IContext
    {
        DbSet<Person> Persons { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
