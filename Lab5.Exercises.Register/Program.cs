using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            AnimalRegister allAnimals = InOutUtils.ReadDogsRegister(@"Animals.csv");
            //AnimalContainer allDogs = InOutUtils.ReadAnimals(@"Dogs.csv");
            //AnimalContainer mainDogs = new AnimalContainer(allDogs);
            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintAnimals("animals", allAnimals);
            //allDogs.Sort(new AnimalsComparatorByName());
            //InOutUtils.PrintAnimals("dogs", allDogs);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allAnimals.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine("Surikiuota informacija: ");
            //InOutUtils.PrintAnimals("dogs", allDogs);
            Console.WriteLine("Iš viso šunų: {0}", allAnimals.Count());
            Console.WriteLine("Patinų: {0}", allAnimals.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", allAnimals.CountByGender(Gender.Female));
            Animal oldest = allAnimals.FindOldestAnimal();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            AnimalContainer FilteredByVacc = allAnimals.FilterByVaccinationExpired();
            Console.WriteLine("Šunys su nebegaliuojančiais skiepais:");
            InOutUtils.PrintExpOrUnvaccinatedDogs(FilteredByVacc);
            Console.WriteLine("Šunų veislės: ");
            List<string> Breeds = allAnimals.FindBreeds();
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalContainer filtered = allAnimals.FilterByBreeds(selectedBreed);
            //InOutUtils.PrintAnimals("filtered", filtered);
            //string fileName = selectedBreed + ".csv";
            //InOutUtils.PrintAnimalsToCSVFile(fileName, filtered);
        }
    }
}
