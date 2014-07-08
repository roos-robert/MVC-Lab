using System;
using System.Collections.Generic;
namespace NextBirthday.Models.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Birthday> GetBirthdays();
        Birthday GetBirthdayById(int birthdayId);
        void InsertBirthday(Birthday birthday);
        void UpdateBirthday(Birthday birthday);
        void DeleteBirthday(int birthdayId);
        void Save();
    }
}
