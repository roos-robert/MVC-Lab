using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NextBirthday.Models
{
    [MetadataType(typeof(Birthday_Metadata))]
    public partial class Birthday
    {
        [ScaffoldColumn(false)]
        public int Age
        {
            get
            {
                return this.NextBirthdayDate.Year - this.Birthdate.Year;
            }
        }

        [ScaffoldColumn(false)]
        public int DaysUntilNextBirthday
        {
            get
            {
                return (this.NextBirthdayDate - DateTime.Today).Days;
            }
        }

        [ScaffoldColumn(false)]
        public DateTime NextBirthdayDate
        {
            get
            {
                var nextBirthday = new DateTime(DateTime.Today.Year,
                    this.Birthdate.Month, this.Birthdate.Day);
                if (nextBirthday < DateTime.Today)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                return nextBirthday;
            }
        }

        public class Birthday_Metadata
        {
            [Required(ErrorMessage = "A birthdate must be entered.")]
            [DisplayName("Birthdate")]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            [Required(ErrorMessage = "A name must be entered.")]
            [DisplayName("Your name")]
            public string Name { get; set; }
        }
    }
}