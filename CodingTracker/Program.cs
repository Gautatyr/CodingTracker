using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using CodingTracker;
using static CodingTracker.DataAccess;
using static CodingTracker.Menu;

InitializeDatabase();

bool closeApp = false;

do
{
    displayMenu();
} while (closeApp == false);

