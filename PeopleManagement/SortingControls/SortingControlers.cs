namespace PeopleManagement.SortingControls;
using PeopleManagement.Models;

interface SortingControl
{
    string Name { get; }
    IComparer<Person> Comparer { get; }
    void Sort(List<Person> people);
}
public class NoSorter : SortingControl
{
    public string Name => "No";
    public IComparer<Person> Comparer => new NoComparer();
    public void Sort(List<Person> people)
    {
        people.Sort(Comparer);
    }
}
public class NameSorter : SortingControl
{
    public string Name => "Name";
    public IComparer<Person> Comparer => new NameComparer();
    public void Sort(List<Person> people)
    {
        people.Sort(Comparer);
    }
}
public class AgeSorter : SortingControl
{
    public string Name => "Age";
    public IComparer<Person> Comparer => new AgeComparer();
    public void Sort(List<Person> people)
    {
        people.Sort(Comparer);
    }
}