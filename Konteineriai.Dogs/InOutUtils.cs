using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Konteineriai.Dogs
{
    static class InOutUtils
    {
        public static DogsContainer ReadDogs(string fileName)
        {
            DogsContainer Dogs = new DogsContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);
                Gender gender;
                Enum.TryParse(Values[4], out gender);// tries to convert value to enum
                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            } 
            return Dogs;
        }
        public static DogsRegister ReadDogsRegister(string fileName)
        {
            DogsRegister Dogs = new DogsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);
                Gender gender;
                Enum.TryParse(Values[4], out gender);// tries to convert value to enum
                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }
            return Dogs;
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
        public static void PrintDogs(string label, DogsContainer dogs)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-70} |", label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < dogs.Count; i++)
            {
                Dog dog = dogs.Get(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.birthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }
        public static void PrintBreeds(List<string> Breeds)
        {
            for (int i = 0; i < Breeds.Count;i++)
            {
                Console.WriteLine(Breeds[i]);
            }
        }
        public static void PrintExpOrUnvaccinatedDogs(DogsContainer FilteredByVacc)
        {
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-18:yyyy-MM-dd} | {4,-8} |", "Reg.Nr", "Vardas", "Veislė", "Pask. Skiepo data", "Lytis");
            Console.WriteLine(new string('-', 90));
            for (int i = 0; i < FilteredByVacc.Count; i++)
            {
                Dog dog = FilteredByVacc.Get(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-18:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.LastVaccinationDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 90));
        }
        public static void PrintDogsToCSVFile(string fileName, DogsContainer dogs)
        {
            string[] lines = new string[dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < dogs.Count; i++)
            {
                Dog dog = dogs.Get(i);
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", dog.ID, dog.Name, dog.Breed, dog.birthDate, dog.Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
