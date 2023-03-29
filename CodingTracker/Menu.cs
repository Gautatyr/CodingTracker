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
                DisplaySessions(GetSessionsHistory(), "\nPress Enter to go back to the menu");
                break;
            case "2":
                InsertSession();
                DisplaySessions(GetSessionsHistory(), "\nSession successfully added ! Press Enter to go back to the main menu");
                break;
            case "3":
                DisplaySessions(GetSessionsHistory(), "\nType in the id of the session you want to Delete\n", true);
                int id = GetNumberInput();
                while (DeleteSession(id) == 0)
                {
                    Console.WriteLine($"\n|---> Record with Id {id} doesn't exist. Please retry. <---|\n");
                    id = GetNumberInput("\nType in the id of the session you want to Delete\n");
                }
                DisplaySessions(GetSessionsHistory(), $"\nThe session with id:{id} has been deleted ! Press Enter to return to the main menu.\n");
                break;
            case "4":
                DisplaySessions(GetSessionsHistory(), "\nType in the id of the session you want to Update\n", true);
                id = GetNumberInput();
                while (UpdateSession(id) == 0)
                {
                    Console.WriteLine($"\n|---> Record with Id {id} doesn't exist. Please retry. <---|\n");
                    id = GetNumberInput("\nType in the id of the session you want to Update\n");
                }
                DisplaySessions(GetSessionsHistory(), $"\nThe session with id:{id} has been updated ! Press Enter to return to the main menu.\n");
                break;
            default:
                Console.Clear();
                Console.WriteLine("\n|---> Invalid Input ! Please type a number from 0 to 4 ! <---|\n");
                displayMenu();
                break;
        }
    }
}
