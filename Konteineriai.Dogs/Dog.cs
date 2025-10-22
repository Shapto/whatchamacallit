using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konteineriai.Dogs
{
    class Dog
    {
        private const int VaccinationDuration = 1;
        public int ID {get; set;}
        public string Name {get; set;}
        public string Breed {get; set;}
        public DateTime birthDate {get; set;}
        public Gender Gender {get; set;}
        public DateTime LastVaccinationDate { get; set; }
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.birthDate = birthDate;
            this.Gender = gender;
        }
        public override bool Equals(object other)
        {
            return this.ID == ((Dog)other).ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
        public bool RequiresVaccination
        {
            get 
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
            }
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.birthDate.Year;
                if (this.birthDate.Date > today.AddYears(-age))
                    age--;
                return age;
            }
        }
    }
}
