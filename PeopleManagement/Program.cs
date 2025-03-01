using PeopleManagement.Models;
using PeopleManagement.SortingControls;

namespace PeopleManagement;

internal static class Program
{
    public static List<Person> People { get; set; } = new();
    //private static void Initailize()
    //{
    //    for (int k = 1; k <= 10; k++)
    //    {
    //        People.Add(new Person
    //        {
    //            No = k,
    //            Name = $"Name {k}",
    //            Age = (k * 22) % 7,
    //        });
    //    }
    //}

    [STAThread]
    static void Main()
    {
        //Initailize();

        ApplicationConfiguration.Initialize();
        Application.Run(new Pages.MainForm());
    }
    
}