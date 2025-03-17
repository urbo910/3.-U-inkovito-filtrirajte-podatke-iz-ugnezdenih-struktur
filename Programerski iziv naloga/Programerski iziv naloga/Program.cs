using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FilterOsebe
{
    class Program
    {
        static void Main()
        {
            List<Oseba> osebe = new List<Oseba>
            {
                new Oseba("Janez", 25, 1500),
                new Oseba("Ana", 30, 2500),
                new Oseba("Marko", 22, 1800),
                new Oseba("Maja", 35, 2200),
                new Oseba("Luka", 28, 2000),
                new Oseba("Petra", 32, 2700),
                new Oseba("Andrej", 40, 3000),
                new Oseba("Nina", 26, 1900),
                new Oseba("Gregor", 45, 3500),
                new Oseba("Tina", 27, 2100),
                new Oseba("Matej", 29, 2300),
                new Oseba("Sara", 31, 2600),
                new Oseba("Boris", 33, 2800),
                new Oseba("Eva", 24, 1700),
                new Oseba("Žan", 38, 2900),
                new Oseba("Klara", 25, 2000),
                new Oseba("Alen", 34, 3100),
                new Oseba("Matic", 23, 1600),
                new Oseba("Katja", 36, 2400),
                new Oseba("Rok", 39, 3200),
                new Oseba("Lara", 37, 2300),
                new Oseba("Vid", 41, 3300),
                new Oseba("Jure", 42, 3400),
                new Oseba("Ela", 28, 2200),
                new Oseba("David", 26, 2000),
                new Oseba("Anže", 30, 2500),
                new Oseba("Jan", 35, 2700),
                new Oseba("Lea", 29, 2100),
                new Oseba("Urban", 32, 2900),
                new Oseba("Gaja", 40, 3100),
                new Oseba("Nejc", 22, 1500),
                new Oseba("Miha", 27, 1800),
                new Oseba("Veronika", 33, 2600),
                new Oseba("Sašo", 31, 2300),
                new Oseba("Nika", 28, 2200),
                new Oseba("Denis", 25, 2000),
                new Oseba("Barbara", 38, 2800),
                new Oseba("Sebastjan", 30, 2500),
                new Oseba("Simona", 34, 2700),
                new Oseba("Tadej", 36, 2900),
                new Oseba("Jana", 23, 1600),
                new Oseba("Dominik", 45, 3500),
                new Oseba("Sabina", 24, 1700),
                new Oseba("Filip", 26, 1900),
                new Oseba("Tamara", 37, 2600),
                new Oseba("Mark", 29, 2200),
                new Oseba("Hana", 41, 3200),
                new Oseba("Bor", 39, 3000),
                new Oseba("Luka", 35, 2800),
                new Oseba("Mojca", 42, 3400),
                new Oseba("Zala", 27, 2000),
                new Oseba("Uroš", 31, 2600),
                new Oseba("Petra", 32, 2700),
                new Oseba("Oskar", 28, 2100),
                new Oseba("Anja", 30, 2500),
                new Oseba("Gorazd", 40, 3100),
                new Oseba("Milan", 45, 3500),
                new Oseba("Iza", 22, 1500),
                new Oseba("Tjaša", 34, 2700)
            };

            // Change the criteria to a list of tuples to accommodate multiple conditions
            List<(string kriterij, string tip, object vrednost)> criteria = new List<(string, string, object)>();

            while (true)
            {
                Console.Write("Vnesite iskalni kriterij (primer: starost > 20; ime == Marko; plača < 3000) \nali pritisnite Enter za zaključek: ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                input = Regex.Replace(input, @"\s*(>=|<=|==|>|<|=)\s*", " $1 ");
                // Remove extra spaces
                input = Regex.Replace(input, @"\s+", " ");

                // Split the input by "in"
                string[] criteriaArray = input.Split(new[] { "in", "IN", "In", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var criterion in criteriaArray)
                {
                    string[] parts = criterion.Trim().Split(' ', 3);

                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Napaka: Vnesite v formatu 'ime tip vrednost'.");
                        continue;
                    }

                    string kriterij = parts[0].Trim();
                    string tip = parts[1].Trim();
                    string vrednost = parts[2].Trim();

                    if (kriterij == "starost" && int.TryParse(vrednost, out int starostVrednost))
                    {
                        criteria.Add((kriterij, tip, starostVrednost));
                    }
                    else if ((kriterij == "placa" || kriterij == "plača") && decimal.TryParse(vrednost, out decimal placaVrednost))
                    {
                        criteria.Add(("placa", tip, placaVrednost));
                    }
                    else if (kriterij == "ime")
                    {
                        criteria.Add((kriterij, "==", vrednost));
                    }
                    else
                    {
                        Console.WriteLine("Napaka: napačna vrednost.");
                    }
                }
            }

            // Pass the criteria as a list to the FilterRecords method
            Filter.FilterRecords(osebe, criteria);
        }
    }
}
