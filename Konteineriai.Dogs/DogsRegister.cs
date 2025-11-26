using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class DogsRegister
    {
        private DogsContainer AllDogs;
        public DogsRegister()
        {
            AllDogs = new DogsContainer();
        }
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new DogsContainer();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public Dog ChooseByIndex(int index)
        {
            return AllDogs.Get(index);
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
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
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }
        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(DogsContainer Dogs)
        {
            Dog oldest = Dogs.Get(0);
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
                Dog dog = AllDogs.Get(i);
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) //uses list method contains
                    Breeds.Add(breed);
            }
            return Breeds;
       }
        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
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
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null && vaccination > dog.LastVaccinationDate)
                {
                    dog.LastVaccinationDate = vaccination.Date;
                }
            }
        }
        public DogsContainer FilterByBreed(string selectedBreed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                int index = 0;
                Dog dog = AllDogs.Get(i);
                if (dog.Breed.Equals(this.ChooseByIndex(index).Breed))//uses string method equals 
                {
                    Filtered.Add(dog);
                }
                index++;
            }
            return Filtered;
        }
        public DogsContainer FilterByBreeds(string selectedBreed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                int index = 0;
                Dog dog = AllDogs.Get(i);
                if (dog.Breed.Equals(this.ChooseByIndex(index).Breed))//uses string method equals 
                {
                    Filtered.Add(dog);
                }
                index++;
            }
           return Filtered;
        }
        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer FilteredByVacc = new DogsContainer();
            DateTime temp = DateTime.MinValue;
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
                if (dog.LastVaccinationDate != dog.LastVaccinationDate.AddYears(1))
                {
                    FilteredByVacc.Add(dog);
                }
            }
            return FilteredByVacc;
        }
    }
}
