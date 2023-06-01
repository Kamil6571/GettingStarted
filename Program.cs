using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Opret fil");
                Console.WriteLine("2. Vis URL-adressen til brugerens mappe");
                Console.WriteLine("3. Afslut");
                Console.Write("Vælg en mulighed: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        OpretFil();
                        break;
                    case "2":
                        VisBrugermappe();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg. Vælg igen.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void OpretFil()
        {
            Console.Write("Indtast filnavn: ");
            string fileName = Console.ReadLine();

            Console.Write("Indtast filens indhold: ");
            string fileContent = Console.ReadLine();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(path, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(fileContent);
                }

                Console.WriteLine("Fil oprettet succesfuldt på følgende placering: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fejl under oprettelse af fil: " + ex.Message);
            }
        }

        static void VisBrugermappe()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Brugerens mappe: " + path);
        }
    }
}
