using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.Drawing.Text;

namespace CodingTracker;

public static class DataAccess
{
    public static void InitializeDatabase()
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCommand = connection.CreateCommand();

            tableCommand.CommandText =
                $@"CREATE TABLE IF NOT EXISTS CodingSessions (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, MinutesSpentCoding INTEGER)";

            tableCommand.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static void InsertSession(string date, double minutesSpentCoding)
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCommand = connection.CreateCommand();

            tableCommand.CommandText =
                $@"INSERT INTO CodingSessions(date, minutesSpentCoding) VALUES('{date}', {minutesSpentCoding})";

            tableCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}


