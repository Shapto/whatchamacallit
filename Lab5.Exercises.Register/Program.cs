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
            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintAnimals("animals", allAnimals);
            allAnimals.Sort(new AnimalsComparatorByName());
            Console.WriteLine("Surikiuota informacija: ");
            InOutUtils.PrintAnimals("animals", allAnimals);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allAnimals.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count());
            Console.WriteLine("Iš viso agresyvių šunų: {0}", allAnimals.CountAggresiveDogs());
            Console.WriteLine("Patinų: {0}", allAnimals.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", allAnimals.CountByGender(Gender.Female));
            Animal oldest = allAnimals.FindOldestAnimal();
            Console.WriteLine("Seniausias gyvūnas:");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            AnimalRegister FilteredByVacc = allAnimals.FilterByVaccinationExpired();
            Console.WriteLine("Gyvūnai su nebegaliuojančiais skiepais:");
            InOutUtils.PrintExpOrUnvaccinatedDogs(FilteredByVacc);
            Console.WriteLine("Gyvūnų veislės: ");
            List<string> Breeds = allAnimals.FindBreeds();
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine("Kokios veislės gyvūną atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalRegister filtered = allAnimals.FilterByBreeds(selectedBreed);
            InOutUtils.PrintAnimals("filtered", filtered);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintAnimalsToCSVFile(fileName, filtered);
            allAnimals.Sort(new AnimalsComparatorByNameAndID());
            InOutUtils.PrintAnimals("name ir id", allAnimals);
            allAnimals.Sort(new AnimalsComparatorByBirthdateAndID());
            InOutUtils.PrintAnimals("birthdate ir id", allAnimals);
        }
    }
}
