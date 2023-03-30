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
        Console.WriteLine("\nPlease write the date of the session in the 'dd-mm-yy' format, or type 0 to return to the main menu\n");

        string sessionDate = Console.ReadLine();

        while (!DateTime.TryParseExact(sessionDate, "d-M-yy", System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out _)
                && sessionDate != "0")
        {
            Console.WriteLine("\n|---> Invalid Input ! Please use the 'dd-MM-yy' format and try again or type 0 to get back to the main menu ! <---|\n");
            sessionDate = Console.ReadLine();
        }

        return sessionDate;
    }

    public static string InputSessionTime()
    {
        Console.WriteLine("\nPlease write the time you started the session in the 'hh:mm' format, or type 0 to go back to the main menu\n");

        string sessionStart = Console.ReadLine();
        DateTime sessionStartFormated;

        while (!DateTime.TryParseExact(sessionStart, "H:m", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out sessionStartFormated)
            && sessionStart != "0")
        {
            Console.Clear();
            Console.WriteLine("\n|---> Invalid Input ! <---|\n");
            Console.WriteLine("\nPlease write the time you started the session in the 'hh:mm' format, or type 0 to go back to the main menu\n");
            sessionStart = Console.ReadLine();
        }

        if (sessionStart == "0") return sessionStart;

        Console.WriteLine("\nPlease write the time you ended the session in the 'hh:mm' format, or type 0 to go back to the main menu\n");

        string sessionEnd = Console.ReadLine();
        DateTime sessionEndFormated;

        while (!DateTime.TryParseExact(sessionEnd, "H:m", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out sessionEndFormated)
            && sessionEnd != "0")
        {
            Console.Clear();
            Console.WriteLine("\n|---> Invalid Input ! <---|\n");
            Console.WriteLine("\nPlease write the time you ended the session in the 'hh:mm' format, or type 0 to go back to the main menu\n");
            sessionEnd = Console.ReadLine();
        }

        if (sessionEnd == "0") return sessionEnd;

        double sessionDuration;

        // This is needed to avoid asking the user about the date of start and date of end
        // in case a session is longer than a day
        if (sessionEndFormated < sessionStartFormated)
        {
            DateTime defaultTime = DateTime.Parse("01-01-01");
            DateTime defaultTimeTomorrow = DateTime.Parse("02-01-01");

            DateTime properStartTime = defaultTime.Date.Add(sessionStartFormated.TimeOfDay);
            DateTime properEndTime = defaultTimeTomorrow.Date.Add(sessionEndFormated.TimeOfDay);

            sessionDuration = (properEndTime - properStartTime).TotalMinutes;
        }
        else
        {
            sessionDuration = (sessionEndFormated - sessionStartFormated).TotalMinutes;
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
        if (skipReadLine == true) return;
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
