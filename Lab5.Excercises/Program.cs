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
            AnimalRegister register = InOutUtils.ReadDogsRegister(@"Dogs.csv");
            AnimalContainer allDogs = InOutUtils.ReadAnimals(@"Dogs.csv");
            AnimalContainer mainDogs = new AnimalContainer(allDogs);
            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintAnimals("dogs", mainDogs);
            allDogs.Sort();
            InOutUtils.PrintAnimals("dogs", allDogs);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine("Surikiuota informacija: ");
            InOutUtils.PrintAnimals("dogs", allDogs);
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            AnimalContainer FilteredByVacc = register.FilterByVaccinationExpired();
            Console.WriteLine("Šunys su nebegaliuojančiais skiepais:");
            InOutUtils.PrintExpOrUnvaccinatedDogs(FilteredByVacc);
            Console.WriteLine("Šunų veislės: ");
            List<string> Breeds = register.FindBreeds();
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalContainer filtered = register.FilterByBreeds(selectedBreed);
            InOutUtils.PrintAnimals("filtered", filtered);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintAnimalsToCSVFile(fileName, filtered);
        }
    }
}
