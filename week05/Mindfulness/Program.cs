using System;
using System.Collections.Generic;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Listing Activity");
                Console.WriteLine("3. Reflecting Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select an option (1-4): ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        break;
                    case "2":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;
                    case "3":
                        ReflectingActivity reflecting = new ReflectingActivity();
                        reflecting.Run();
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
