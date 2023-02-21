using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Repository.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string FullName { get; set; }
        public int YearOfBirth { get; set; }
    }
}
