using Lab5.Exercises.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konteineriai.Dogs
{
    public class GuineaPig : Animal
    {
        public GuineaPig(int id, string name, string breed, DateTime birthDate, Gender gender) : base(id, name, breed, birthDate, gender)
        {

        }
        public override bool RequiresVaccination
        {
            get
            {
                return false;
            }
        }
        public override string ToString()
        {
            return string.Format("| {0,8} | {1,-15} | {2,-15} | {3,-18:yyyy-MM-dd} | {4,-8} | {5,-8} |", ID, Name, Breed, birthDate, Gender, "-");
        }
    }
}
