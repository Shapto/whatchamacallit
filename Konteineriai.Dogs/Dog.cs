using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab5.Exercises.Register
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
        public Dog(Dog other)
        {
            this.ID = other.ID;
            this.Name = other.Name;
            this.Breed = other.Breed;
            this.birthDate = other.birthDate;
            this.Gender = other.Gender;
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
        public int CompareTo(Dog other)
        {
            int gender = this.Gender.CompareTo(other.Gender);
            if (gender != 1)
            {
                return gender;
            }
            return this.Breed.CompareTo(other.Breed);
        }
    }
}
