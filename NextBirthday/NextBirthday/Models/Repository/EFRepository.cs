using NextBirthday.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextBirthday.Models.Repository
{
    public class EFRepository
    {
        private birthdatesEntities _entities = new birthdatesEntities();

        public IEnumerable<Birthday> GetBirthdays()
        {
            return _entities.Birthdays.ToList();
        }

        public void InsertBirthday(Birthday birthday)
        {
            _entities.Birthdays.Add(birthday);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}