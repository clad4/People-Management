using PeopleManagement.Models;
using PeopleManagement.SortingControls;
using System.Data;

namespace PeopleManagement;

internal static class Program
{
    public static List<Person> People { get; set; } = new();
    public static int No { get; set; }
    [STAThread]
    static void Main()
    {
        //Initailize();

        ApplicationConfiguration.Initialize();
        Application.Run(new Pages.MainForm());
    }

}