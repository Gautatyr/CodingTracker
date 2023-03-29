using CodingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker;

public static class Helpers
{
    public static string InputSessionDate()
    {
        Console.WriteLine("\nPlease write the date of the session in the 'dd-mm-yy' format.\n");
        string sessionDate = Console.ReadLine();

        return sessionDate;
    }

    public static double InputSessionTime()
    {
        Console.WriteLine("\nPlease write the time you started the session in the 'hh:mm' format\n");

        if(!DateTime.TryParseExact(Console.ReadLine(), "H:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var sessionStart))
        {
            Console.WriteLine("\n|---> Invalid Input ! Please write the the you started the session in the 'hh-mm' format ! <---|\n");
            return InputSessionTime();
        }

        Console.WriteLine("\nPlease write the time you ended the session in the 'hh-mm' format\n");

        if (!DateTime.TryParseExact(Console.ReadLine(), "H:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var sessionEnd))
        {
            Console.WriteLine("\n|---> Invalid Input ! Please write the the you started the session in the 'hh-mm' format ! <---|\n");
            return InputSessionTime();
        }

        double sessionDuration;

        // This is needed to avoid asking the user about the date of start and date of end
        // in case a session is longer than a day
        if (sessionEnd < sessionStart)
        {
            DateTime defaultTime = DateTime.Parse("01-01-01");
            DateTime defaultTimeTomorrow = DateTime.Parse("02-01-01");

            DateTime properStartTime = defaultTime.Date.Add(sessionStart.TimeOfDay);
            DateTime properEndTime = defaultTimeTomorrow.Date.Add(sessionEnd.TimeOfDay);

            sessionDuration = (properEndTime - properStartTime).TotalMinutes;
        }
        else
        {
            sessionDuration = (sessionEnd - sessionStart).TotalMinutes;
        }
        
        Console.Clear();
        Console.WriteLine("Session successfully added !");

        return sessionDuration;
    }

    public static void DisplaySessions(List<CodingSessions> codingSessions)
    {
        Console.WriteLine("-------------------------------------------------------");

        foreach (CodingSessions session in codingSessions)
        {
            Console.WriteLine($"{session.Id} | {session.Date.ToString("dd-MM-yy")} | {session.MinutesSpentCoding} |");
        }

        Console.WriteLine("-------------------------------------------------------");
    }
}
