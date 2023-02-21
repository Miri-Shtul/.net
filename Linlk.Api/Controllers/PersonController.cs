using Link.Services.Interfaces;
using Linlk.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Linlk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        static string _address = "http://api-sq.azurewebsites.net";
        private string result;
        List<PersonModel> correctId = new List<PersonModel>();
        List<PersonModel> disCorrectId = new List<PersonModel>();
        ResultLists resultList;

        [HttpPost]
        public async Task<ResultLists> postFileCorrect(IFormFile file)
        {
            await _personService.filterForm(file, resultList.disCorrectId, resultList.correctId);
            //שני הרשימות מעודכנות כאן לפי תקינות התעודת זהות
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();

            string responseAsString = await response.Content.ReadAsStringAsync();
            resultList.correctId = JsonConvert.DeserializeObject<List<PersonModel>>(responseAsString);
            return resultList;
        }


    }
}
