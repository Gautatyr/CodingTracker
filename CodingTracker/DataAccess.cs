using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.Drawing.Text;
using CodingTracker.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace CodingTracker;

public static class DataAccess
{
    private static string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

    public static void InitializeDatabase()
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCommand = connection.CreateCommand();

            tableCommand.CommandText =
                $@"CREATE TABLE IF NOT EXISTS CodingSessions (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, TimeSpentCoding TEXT)";

            tableCommand.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static void InsertSession(string date, double minutesSpentCoding)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            TimeSpan hoursSpentCoding = TimeSpan.FromMinutes(minutesSpentCoding);
            string timeSpentCoding = hoursSpentCoding.Hours.ToString() + "h" + hoursSpentCoding.Minutes.ToString();

            connection.Open();

            SqliteCommand tableCommand = connection.CreateCommand();

            tableCommand.CommandText =
                $@"INSERT INTO CodingSessions(date, TimeSpentCoding) VALUES('{date}', '{timeSpentCoding}')";

            tableCommand.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static List<CodingSessions> GetSessionsHistory()
    {
        // Send back a list of CodingSessions
        List<CodingSessions> codingSessions = new List<CodingSessions>();

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCommand = connection.CreateCommand();

            tableCommand.CommandText = "SELECT * FROM CodingSessions";

            SqliteDataReader reader = tableCommand.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    codingSessions.Add(new CodingSessions
                    {
                        Id = reader.GetInt32(0),
                        Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", new CultureInfo("en-US")),
                        MinutesSpentCoding = reader.GetDouble(2)
                    });
                }
            }
            else
            {
                Console.WriteLine("No session found.");
            }
            connection.Close();
        }

        return codingSessions;
    }
}

