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
        private AnimalContainer AllDogs;
        public AnimalRegister()
        {
            AllDogs = new AnimalContainer();
        }
        public AnimalRegister(List<Animal> Dogs)
        {
            AllDogs = new AnimalContainer();
            foreach (Animal dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public bool Contains(Animal dog)
        {
            return AllDogs.Contains(dog);
        }
        public void Add(Animal dog)
        {
            AllDogs.Add(dog);
        }
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public Animal ChooseByIndex(int index)
        {
            return AllDogs.Get(index);
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Animal dog = AllDogs.Get(i);
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        //public Dog FindOldestDog()
        //{
        //    {
        //        Dog oldest = this.ChooseByIndex(0); // means least value
        //        for (int i = 1; i < DogsCount(); i++)
        //        {
        //            if (DateTime.Compare(this.ChooseByIndex(i).birthDate, this.ChooseByIndex(i).birthDate) < 0)
        //            {
        //                oldest = this.ChooseByIndex(i);
        //            }
        //       }
        //        return oldest;
        //    }
        //}
        public Animal FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Animal dog = AllDogs.Get(i);
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) //uses list method contains
                    Breeds.Add(breed);
            }
            return Breeds;
       }
        private Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Animal dog = AllDogs.Get(i);
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                int index = 0;
                Animal dog = AllDogs.Get(i);
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                int index = 0;
                Animal dog = AllDogs.Get(i);
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Animal dog = AllDogs.Get(i);
                if (dog.LastVaccinationDate != dog.LastVaccinationDate.AddYears(1))
                {
                    FilteredByVacc.Add(dog);
                }
            }
            return FilteredByVacc;
        }
    }
}
