using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker;

public static class Helpers
{
    public static string inputSessionDate()
    {
        Console.WriteLine("\nPlease write the date of the session in the 'dd-mm-yy' format.\n");
        string sessionDate = Console.ReadLine();

        return sessionDate;
    }

    public static double inputSessionTime()
    {
        Console.WriteLine("\nPlease write the time you started the session in the 'hh:mm' format\n");

        if(!DateTime.TryParseExact(Console.ReadLine(), "H:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var sessionStart))
        {
            Console.WriteLine("\n|---> Invalid Input ! Please write the the you started the session in the 'hh-mm' format ! <---|\n");
            return inputSessionTime();
        }
        

        Console.WriteLine("\nPlease write the time you ended the session in the 'hh-mm' format\n");

        if (!DateTime.TryParseExact(Console.ReadLine(), "H:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var sessionEnd))
        {
            Console.WriteLine("\n|---> Invalid Input ! Please write the the you started the session in the 'hh-mm' format ! <---|\n");
            return inputSessionTime();
        }

        double sessionDuration = (sessionEnd - sessionStart).TotalMinutes;

        Console.Clear();

        return sessionDuration;
    }
}
