using PeopleManagement.Models;
using PeopleManagement.SortingControls;

namespace PeopleManagement;

internal static class Program
{
    public static List<Person> People { get; set; } = new();
    private static void Initailize()
    {
        for (int k = 1; k <= 10; k++)
        {
            People.Add(new Person
            {
                No = k,
                Name = $"Name {k}",
                Age = (k * 22) % 7,
            });
        }
    }

    [STAThread]
    static void Main()
    {
        Initailize();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Pages.MainForm());
    }
    
}