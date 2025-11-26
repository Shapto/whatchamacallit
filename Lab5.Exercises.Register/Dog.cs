using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab5.Exercises.Register
{
    class Dog : Animal
    {
        private const int VaccinationDuration = 1;
        public bool Aggresive { get; set; }
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender, bool aggressive) : base(id, name, breed, birthDate, gender)
        {
            this.Aggresive = aggressive;
        }
        public override bool RequiresVaccination
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
    }
}
