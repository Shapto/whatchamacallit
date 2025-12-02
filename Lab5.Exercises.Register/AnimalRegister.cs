using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalRegister
    {
        private AnimalContainer AllAnimals;
        public AnimalRegister()
        {
            AllAnimals = new AnimalContainer();
        }
        public AnimalRegister(List<Animal> Dogs)
        {
            AllAnimals = new AnimalContainer();
            foreach (Animal dog in Dogs)
            {
                this.AllAnimals.Add(dog);
            }
        }
        public bool Contains(Animal dog)
        {
            return AllAnimals.Contains(dog);
        }
        public void Add(Animal dog)
        {
            AllAnimals.Add(dog);
        }
        public int Count()
        {
            return this.AllAnimals.Count;
        }

        public Animal ChooseByIndex(int index)
        {
            return AllAnimals.Get(index);
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal dog = AllAnimals.Get(i);
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal animal = this.AllAnimals.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
        public Animal FindOldestDog()
        {
            return this.FindOldestDog(this.AllAnimals);
        }
        public Animal FindOldestDog(string breed)
        {
            AnimalContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Animal FindOldestDog(AnimalContainer Dogs)
        {
            Animal oldest = Dogs.Get(0);
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(oldest.birthDate, Dogs.Get(i).birthDate) > 0)
                {
                    oldest = Dogs.Get(i);
                }
            }
            return oldest;
        }
       public List<string> FindBreeds()
       {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal dog = AllAnimals.Get(i);
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) //uses list method contains
                    Breeds.Add(breed);
            }
            return Breeds;
       }
        private Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal dog = AllAnimals.Get(i);
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal dog = this.FindDogByID(vaccination.DogID);
                if (dog != null && vaccination > dog.LastVaccinationDate)
                {
                    dog.LastVaccinationDate = vaccination.Date;
                }
            }
        }
        public AnimalContainer FilterByBreed(string selectedBreed)
        {
            AnimalContainer Filtered = new AnimalContainer();
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                int index = 0;
                Animal dog = AllAnimals.Get(i);
                if (dog.Breed.Equals(this.ChooseByIndex(index).Breed))//uses string method equals 
                {
                    Filtered.Add(dog);
                }
                index++;
            }
            return Filtered;
        }
        public AnimalContainer FilterByBreeds(string selectedBreed)
        {
            AnimalContainer Filtered = new AnimalContainer();
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                int index = 0;
                Animal dog = AllAnimals.Get(i);
                if (dog.Breed.Equals(this.ChooseByIndex(index).Breed))//uses string method equals 
                {
                    Filtered.Add(dog);
                }
                index++;
            }
           return Filtered;
        }
        public AnimalContainer FilterByVaccinationExpired()
        {
            AnimalContainer FilteredByVacc = new AnimalContainer();
            DateTime temp = DateTime.MinValue;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal dog = AllAnimals.Get(i);
                if (dog.LastVaccinationDate != dog.LastVaccinationDate.AddYears(1))
                {
                    FilteredByVacc.Add(dog);
                }
            }
            return FilteredByVacc;
        }
        public void Sort()
        {
            Sort(new AnimalsComparator());
        }
        public void Sort(AnimalsComparator comparator)
        {
            AllAnimals.Sort(comparator);
        }
    }
}
