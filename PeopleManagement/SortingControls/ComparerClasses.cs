using PeopleManagement.Models;

namespace PeopleManagement.SortingControls;
public class NoComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x == null || y == null) return 0;
        return x.No.CompareTo(y.No);
    }
}
public class NameComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x == null || y == null) return 0;
        return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }
}
public class AgeComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x == null || y == null) return 0;
        return x.Age.CompareTo(y.Age);
    }
}
