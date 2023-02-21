using ExcelDataReader;
using Link.Services.Interfaces;
using Linlk.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Services.Services
{
    public class PersonService : IPersonService
    {
        
               
        public async Task filterForm(IFormFile file, List<PersonModel> correctId, List<PersonModel> disCorrectId)
        {
            var person = new PersonModel();
            var fileName = "./Users.xlsx";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        person.Tz = reader.GetValue(1).ToString();
                        person.YearOfBirth = (int)reader.GetValue(2);
                        person.FullName = reader.GetValue(0).ToString();
                        if (IsCorrect(person))
                            correctId.Add(person);
                        else disCorrectId.Add(person);
                    }
                }
            }

        }

        public bool IsCorrect(PersonModel person)
        {
            //לא מצאתי את הפונקציה הטובה עשיתי סתם לבינתיים
            return person.Tz.Length == 9;
        }

       
    }
}
