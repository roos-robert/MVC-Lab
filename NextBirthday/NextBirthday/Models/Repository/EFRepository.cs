using NextBirthday.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NextBirthday.Models.Repository
{
    public class EFRepository : IRepository
    {       
        #region Birthday CRUD

        private birthdatesEntities _entities = new birthdatesEntities();

        public void InsertBirthday(Birthday birthday)
        {
            _entities.Birthdays.Add(birthday);
        }

        public Birthday GetBirthdayById(int birthdayId)
        {
            // Returns null if nothing is found, else object.
            return _entities.Birthdays.Find(birthdayId);
        }

        public IEnumerable<Birthday> GetBirthdays()
        {
            return _entities.Birthdays.ToList();
        }

        public void UpdateBirthday(Birthday birthday)
        {
            _entities.Entry(birthday).State = EntityState.Modified;
        }

        public void DeleteBirthday(int birthdayId)
        {
            var birthday = _entities.Birthdays.Find(birthdayId);
            _entities.Birthdays.Remove(birthday);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        #endregion

        #region IDisposable

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}