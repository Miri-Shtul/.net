using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace User.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> UpdateUser(User u)
    }
}
