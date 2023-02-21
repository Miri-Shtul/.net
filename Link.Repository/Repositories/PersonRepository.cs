using ExcelDataReader;
using Link.Repository.Entities;
using Link.Repository.Interfaces;
using Linlk.Api;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IContext _context;
        public PersonRepository(IContext context)
        {
            _context = context;
        }

        //סתם עשיתי וויד לבדוק למה לשנות את זה
        public void filterForm(IFormFile file)
        {
            List<PersonModel> correctId = new List<PersonModel>();
            List<PersonModel> disCorrectId = new List<PersonModel>();
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
