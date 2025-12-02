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
            AnimalRegister allDogs = InOutUtils.ReadDogsRegister(@"Dogs.csv");
            //AnimalContainer allDogs = InOutUtils.ReadAnimals(@"Dogs.csv");
            //AnimalContainer mainDogs = new AnimalContainer(allDogs);
            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintAnimals("dogs", allDogs);
            //allDogs.Sort(new AnimalsComparatorByName());
            //InOutUtils.PrintAnimals("dogs", allDogs);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allDogs.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine("Surikiuota informacija: ");
            //InOutUtils.PrintAnimals("dogs", allDogs);
            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count());
            Console.WriteLine("Patinų: {0}", allDogs.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", allDogs.CountByGender(Gender.Female));
            Animal oldest = allDogs.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            AnimalContainer FilteredByVacc = allDogs.FilterByVaccinationExpired();
            Console.WriteLine("Šunys su nebegaliuojančiais skiepais:");
            InOutUtils.PrintExpOrUnvaccinatedDogs(FilteredByVacc);
            Console.WriteLine("Šunų veislės: ");
            List<string> Breeds = allDogs.FindBreeds();
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalContainer filtered = allDogs.FilterByBreeds(selectedBreed);
            //InOutUtils.PrintAnimals("filtered", filtered);
            //string fileName = selectedBreed + ".csv";
            //InOutUtils.PrintAnimalsToCSVFile(fileName, filtered);
        }
    }
}
