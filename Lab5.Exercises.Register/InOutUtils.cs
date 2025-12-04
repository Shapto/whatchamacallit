using Konteineriai.Dogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Xml.Linq;

namespace Lab5.Exercises.Register
{
    static class InOutUtils
    {
        public static AnimalRegister ReadDogsRegister(string fileName)
        {
            AnimalRegister Animals = new AnimalRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] values = line.Split(';');
                string type = values[0];
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);
                Gender gender;
                Enum.TryParse(values[5], out gender);// tries to convert value to enum
                switch (type)
                {
                    case "DOG":
                        bool aggressive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggressive);
                        if (!Animals.Contains(dog))
                        {
                            Animals.Add(dog);
                        }
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        if (!Animals.Contains(cat))
                        {
                            Animals.Add(cat);
                        }
                        break;
                    case "GUINEAPIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        if (!Animals.Contains(guineaPig))
                        {
                            Animals.Add(guineaPig);
                        }
                        break;
                    default:
                        break;//unknown type

                }
            }
            return Animals;
        }
        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
        public static void PrintAnimals(string label, AnimalRegister animals)
        {
            Console.WriteLine(new string('-', 91));
            Console.WriteLine("| {0,-87} |", label);
            Console.WriteLine(new string('-', 91));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-18:yyyy-MM-dd} | {4,-8} | {5,-8} |", "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis", "Agress.?");
            Console.WriteLine(new string('-', 91));
            for (int i = 0; i < animals.Count(); i++)
            {
                Animal animal = animals.ChooseByIndex(i);
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine(new string('-', 91));
        }
        public static void PrintBreeds(List<string> Breeds)
        {
            for (int i = 0; i < Breeds.Count;i++)
            {
                Console.WriteLine(Breeds[i]);
            }
        }
        public static void PrintExpOrUnvaccinatedDogs(AnimalRegister FilteredByVacc)
        {
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-18:yyyy-MM-dd} | {4,-8} |", "Reg.Nr", "Vardas", "Veislė", "Pask. Skiepo data", "Lytis");
            Console.WriteLine(new string('-', 90));
            for (int i = 0; i < FilteredByVacc.Count(); i++)
            {
                Animal animal = FilteredByVacc.ChooseByIndex(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-18:yyyy-MM-dd} | {4,-8} |", animal.ID, animal.Name, animal.Breed, animal.LastVaccinationDate, animal.Gender);
            }
            Console.WriteLine(new string('-', 90));
        }
        public static void PrintAnimalsToCSVFile(string fileName, AnimalRegister animals)
        {
            string[] lines = new string[animals.Count() + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < animals.Count(); i++)
            {
                Animal animal = animals.ChooseByIndex(i);
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", animal.ID, animal.Name, animal.Breed, animal.birthDate, animal.Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
