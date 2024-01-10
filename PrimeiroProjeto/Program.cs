using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class ScreenSound
{
    private static readonly Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>()
    {
        { "Linkin Park", new List<int> { 10, 8, 6 } },
        { "The Beatles", new List<int>() }
    };

static void Main(string[] args)
    {
        DisplayMenuOptions();
    }

    static void DisplayLogo()
    {
        Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");
        Console.WriteLine("Welcome to Screen Sound");
    }

    static void DisplayMenuOptions()
    {
        DisplayLogo();
        Console.WriteLine("\nPress 1 to register a band");
        Console.WriteLine("Press 2 to show all registered bands");
        Console.WriteLine("Press 3 to rate a band");
        Console.WriteLine("Press 4 to display the average rating of a band");
        Console.WriteLine("Press -1 to exit");

        Console.Write("\nEnter your option: ");
        if (!int.TryParse(Console.ReadLine(), out int chosenOption))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        switch (chosenOption)
        {
            case 1:
                RegisterBand();
                break;
            case 2:
                ShowRegisteredBands();
                break;
            case 3:
                RateBand();
                break;
            case 4:
                DisplayBandAverage();
                break;
            case -1:
                Console.WriteLine("Program Ended :)");
                return;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
        DisplayMenuOptions();
    }

    static void DisplayOptionTitle(string title)
    {
        string asterisks = new string('*', title.Length);
        Console.WriteLine(asterisks);
        Console.WriteLine(title);
        Console.WriteLine(asterisks + "\n");
    }

    static void RegisterBand()
    {
        Console.Clear();
        DisplayOptionTitle("Band Registration");
        Console.Write("Enter the name of the band you want to register: ");
        string bandName = Console.ReadLine()!;
        registeredBands.Add(bandName, new List<int>());
        Console.WriteLine($"The band {bandName} has been successfully registered!");
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void ShowRegisteredBands()
    {
        Console.Clear();
        DisplayOptionTitle("Displaying All Registered Bands");

        foreach (var band in registeredBands.Keys)
        {
            Console.WriteLine($"Band: {band}");
        }

        Console.WriteLine("\nPress any key to return to the main menu: ");
        Console.ReadKey();
        Console.Clear();
    }

    static void RateBand()
    {
        Console.Clear();
        DisplayOptionTitle("Rate a Band");
        Console.Write("Enter the name of the band you want to rate: ");
        string bandName = Console.ReadLine()!;

        if (registeredBands.ContainsKey(bandName))
        {
            Console.Write($"What rating does {bandName} deserve: ");
            if (!int.TryParse(Console.ReadLine(), out int rating))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            registeredBands[bandName].Add(rating);
            Console.WriteLine($"The rating {rating} has been successfully assigned to the band {bandName}.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nThe band {bandName} was not found!");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void DisplayBandAverage()
    {
        Console.Clear();
        DisplayOptionTitle("Band Average");
        Console.Write("Enter the name of the band whose average you want to know: ");
        string bandName = Console.ReadLine()!;

        if (registeredBands.ContainsKey(bandName))
        {
            double average = registeredBands[bandName].Average();
            Console.WriteLine($"The average rating of the band {bandName} is {average}.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nThe band {bandName} was not found!");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
