using System;
using System.Collections.Generic;
using System.Text;

namespace Konteineriai.Dogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintDogs(register);
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.CalculateAge());
            DogsRegister FilteredByVacc = register.FilterByVaccinationExpired();
            Console.WriteLine("Šunys su nebegaliuojančiais skiepais:");
            InOutUtils.PrintExpOrUnvaccinatedDogs(FilteredByVacc);
            Console.WriteLine("Šunų veislės: ");
            List<string> Breeds = register.FindBreeds();
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            DogsRegister filtered = register.FilterByBreeds(selectedBreed);
            InOutUtils.PrintDogs(filtered);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, filtered);
        }
    }
}
