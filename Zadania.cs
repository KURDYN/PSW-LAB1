using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    class Zadania
    {
        public static void zadanie1()
        {
            Random random = new Random();
            int los = random.Next(0, 1000);

            while (true)
            {
                Console.Write("Podaj liczbę całkowitą: ");
                if (int.TryParse(Console.ReadLine(), out int liczba))
                {
                    if (los == liczba)
                    {
                        Console.WriteLine("Odgadłeś liczbę: " + liczba);
                        break;
                    }
                    else if (los > liczba)
                    {
                        Console.WriteLine("Liczba jest za mała");
                    }
                    else
                    {
                        Console.WriteLine("Liczba jest za duża");
                    }
                }
                else
                {
                    Console.WriteLine("To nie jest poprawna liczba!");
                }
            }
        }

        public static void zadanie2()
        {
            HashSet<int> liczby = new HashSet<int> {};
            while (true)
            {
                Console.Write("Podaj liczbę całkowitą: ");
                if (int.TryParse(Console.ReadLine(), out int liczba))
                {
                    liczby.Add(liczba);
                    Console.WriteLine("Unikalnych elementów: " + liczby.Count+"\n");
                }
                else
                {
                    Console.WriteLine("To nie jest poprawna liczba!");
                }
            }
        }

        public static void zadanie3()
        {
            string sekwencja = "00100100000001010100";

            int licznik = 0;
            bool jedynki = false;
            if (sekwencja[0] == '1') jedynki = true;
            if (sekwencja[sekwencja.Length-1] == '0') licznik--;

            foreach (var bit in sekwencja)
            {
                if (jedynki) 
                {
                    if (bit == '0')
                    {
                        licznik++;
                        jedynki = false;
                    }
                }
                else 
                {
                    if (bit == '1')
                    {
                        jedynki = true;
                    }
                }
            }
            Console.WriteLine("Liczba dziur binarnych: "+licznik);
        }

        static HashSet<int> createSet(string setstring)
        {
            HashSet<int> resultSet;
            try
            {
                resultSet = new HashSet<int>(setstring.Split(' ').Select(int.Parse));
                Console.WriteLine("Zbiór poprawny.");
                return resultSet;
            }
            catch (FormatException)
            {
                Console.WriteLine("Zbiór niepoprawny! Podaj poprawne liczby całkowite.");
                return null;
            }
        }

        public static void zadanie4()
        {
            HashSet<int> zbiorA = null;
            HashSet<int> zbiorB = null;
            string zbiorString;

            Console.WriteLine("Podaj pierwszy zbiór liczb oddzielonych spacją: ");
            while (zbiorA == null)
            {
                zbiorString = Console.ReadLine();
                zbiorA = createSet(zbiorString);
            }

            Console.WriteLine("Podaj drugi zbiór liczb oddzielonych spacją: ");
            while (zbiorB == null)
            {
                zbiorString = Console.ReadLine();
                zbiorB = createSet(zbiorString);
            }

            HashSet<int> sumaAB = new HashSet<int>(zbiorA);
            sumaAB.UnionWith(zbiorB);
            Console.WriteLine($"A suma B: {string.Join(" ", sumaAB)} ");

            HashSet<int> roznicaAB = new HashSet<int>(zbiorA);
            roznicaAB.ExceptWith(zbiorB);
            Console.WriteLine($"A różnica B: {string.Join(" ", roznicaAB)} ");

            HashSet<int> wspolneAB = new HashSet<int>(zbiorA);
            wspolneAB.IntersectWith(zbiorB);
            Console.WriteLine($"A wspólne B: {string.Join(" ", wspolneAB)} ");

            HashSet<int> roznicaSymAB = new HashSet<int>(zbiorA);
            roznicaSymAB.SymmetricExceptWith(zbiorB);
            Console.WriteLine($"A różnica sym. B: {string.Join(" ", roznicaSymAB)} ");

        }

        static Boolean isPrime(int liczba)
        {
            if (liczba < 2) return false;
            if (liczba == 2 || liczba == 3) return true;

            for (int i = 2; i * i <= liczba; i += 1)
            {
                if (liczba % i == 0) return false;
            }
            return true;
        }
        
        public static void zadanie5()
        {
            Console.Write("Podaj liczbę całkowitą: ");
            if (int.TryParse(Console.ReadLine(), out int liczba))
            {
                if (isPrime(liczba)) Console.Write("To jest liczba pierwsza.");
                else Console.Write("To nie jest liczba pierwsza.");
            }
            else
            {
                Console.WriteLine("To nie jest poprawna liczba!");
            }
        }

        public static void zadanie6()
        {
            int[] liczby = new int[4] {1, 2, 3, 4};
            int suma(params int[] liczby) => liczby.Sum();

            Console.WriteLine($"Suma: {suma(liczby)}.");
            Console.WriteLine($"Suma: {suma(1, 2, 3, 4)}.");
        }

    }
}
