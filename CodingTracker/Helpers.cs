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

        while (!DateTime.TryParseExact(sessionDate, "d-M-yy", System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n|---> Invalid Input ! Please use the 'dd-MM-yy' format and try again ! <---|\n");
            sessionDate = Console.ReadLine();
        }

        return sessionDate;
    }

    public static string InputSessionTime()
    {
        Console.WriteLine("\nPlease write the time you started the session in the 'hh:mm' format\n");

        if(!DateTime.TryParseExact(Console.ReadLine(), "H:m", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var sessionStart))
        {
            Console.WriteLine("\n|---> Invalid Input ! Please write the the you started the session in the 'hh-mm' format ! <---|\n");
            return InputSessionTime();
        }

        Console.WriteLine("\nPlease write the time you ended the session in the 'hh-mm' format\n");

        if (!DateTime.TryParseExact(Console.ReadLine(), "H:m", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var sessionEnd))
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

        TimeSpan hoursSpentCoding = TimeSpan.FromMinutes(sessionDuration);
        string timeSpentCoding = $"{hoursSpentCoding.Hours}h{hoursSpentCoding.Minutes}mn";

        return timeSpentCoding;
    }

    public static void DisplaySessions(List<CodingSessions> codingSessions, string message = "", bool skipReadLine = false)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");

        foreach (CodingSessions session in codingSessions)
        {
            Console.WriteLine($"|  {session.Id}  |  {session.Date:dd-MM-yy}  |  {session.TimeSpentCoding}   ");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(message);
        if (skipEnter == true) return;
        Console.ReadLine();
    }

    public static int GetNumberInput(string message = "")
    {
        Console.WriteLine(message);

        string numberInput = Console.ReadLine();

        while (!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
        {
            Console.WriteLine("\n|---> Invalid number <---|\n");
            numberInput = Console.ReadLine();
        }

        int finalInput = Convert.ToInt32(numberInput);

        return finalInput;
    }
}
