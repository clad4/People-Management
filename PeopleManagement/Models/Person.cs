using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models;

public class Person
{
    public int No { get; set; }
    public int PersonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string? Other {get; set;}
}
