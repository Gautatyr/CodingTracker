using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodingTracker.DataAccess;
using static CodingTracker.Helpers;

namespace CodingTracker;

public static class Menu
{
    public static void displayMenu()
    {
        Console.Clear();
        Console.WriteLine("\nMAIN MENU\n");
        Console.WriteLine("- Type 0 to Close the Application.");
        Console.WriteLine("- Type 1 to View your coding sessions history.");
        Console.WriteLine("- Type 2 to Add a coding session.");
        Console.WriteLine("- Type 3 to Delete a session history.");
        Console.WriteLine("- Type 4 to Update a session history.");

        string input = Console.ReadLine(); 

        switch (input)
        {
            case "0":
                Console.WriteLine("\nGoodbye !");
                Environment.Exit(0);
                break;
            case "1":
                Console.Clear();
                DisplaySessions(GetSessionsHistory());
                Console.WriteLine("\nPress Enter to go back to the menu");
                Console.ReadLine();
                break;
            case "2":
                InsertSession(InputSessionDate(), InputSessionTime()); 
                break;
/*            case "3":
                DeleteSession();
                break;*/
/*            case "4":
                UpdateSession();
                break;*/
            default:
                Console.Clear();
                Console.WriteLine("\n|---> Invalid Input ! Please type a number from 0 to 4 ! <---|\n");
                displayMenu();
                break;
        }
    }
}
