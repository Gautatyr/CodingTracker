using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace CodingTracker.Models;

public class CodingSessions
{
    public int Id { get; set; } 
    private DateTime Date { get; set; } 
    public string ShortDate { get; set; } 
    public string TimeSpentCoding { get; set; }
}
