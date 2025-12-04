using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByBirthdateAndID : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int comparison;
            comparison = a.birthDate.CompareTo(b.birthDate);
            if (comparison != 0)
            {
                return comparison;
            }
            return a.ID.CompareTo(b.ID);
        }
    }
}
