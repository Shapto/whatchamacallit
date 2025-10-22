using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Konteineriai.Dogs
{
    class DogsRegister
    {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
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
            return AllDogs[index];
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
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
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(oldest.birthDate, Dogs[i].birthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }
       public List<string> FindBreeds()
       {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) //uses list method contains
                    Breeds.Add(breed);
            }
            return Breeds;
       }
        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
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
        public List<Dog> FilterByBreed(string selectedBreed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                int index = 0;
                if (dog.Breed.Equals(this.ChooseByIndex(index).Breed))//uses string method equals 
                {
                    Filtered.Add(dog);
                }
                index++;
            }
            return Filtered;
        }
        public DogsRegister FilterByBreeds(string selectedBreed)
        {
            DogsRegister Filtered = new DogsRegister();
            foreach (Dog dog in this.AllDogs)
            {
                int index = 0;
                if (dog.Breed.Equals(this.ChooseByIndex(index).Breed))//uses string method equals 
                {
                    Filtered.Add(dog);
                }
                index++;
            }
           return Filtered;
        }
        public DogsRegister FilterByVaccinationExpired()
        {
            DogsRegister FilteredByVacc = new DogsRegister();
            DateTime temp = DateTime.MinValue;
            foreach(Dog dog in this.AllDogs)
            {
                if (dog.LastVaccinationDate != dog.LastVaccinationDate.AddYears(1))
                {
                    FilteredByVacc.Add(dog);
                }
            }
            return FilteredByVacc;
        }
    }
}
