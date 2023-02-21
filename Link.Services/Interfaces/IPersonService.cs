using Linlk.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Services.Interfaces
{
    public interface IPersonService
    {
        public void filterForm(IFormFile file, List<PersonModel> disCorrectId, List<PersonModel> correctId);
    }
}
