namespace PeopleManagement.Pages;
using PeopleManagement.Models;
using PeopleManagement.Services;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class EditForm : Form
{
    private Person _person;
    private readonly string _connection;
    private readonly string _table;
    private PeopleServices _peopleServices;
    public EditForm(string connection, string table, Person person)
    {
        _connection = connection;
        _table = table;
        _person = person;
        _peopleServices = new PeopleServices(_connection);

        InitializeComponent();
        Loading();
        tbNo.ReadOnly = true;

        btnCancel.Click += (sender, e) => this.Close();
        btnEdit.Click += OnClickEdited;
    }
    public void Loading()
    {
        tbNo.Text = _person.No.ToString();
        tbName.Text = _person.Name.ToString();
        tbAge.Text = _person.Age.ToString();
    }
    public void OnClickEdited (object? sender, EventArgs e)
    {
        try
        {
            _person.Name = tbName.Text.Trim();
            _person.Age = int.Parse(tbAge.Text);
            _person.Other = tbOther.Text.Trim();

            _peopleServices.UpdatePersonAsync(_table,_person.PersonId,
                                            _person.Name, _person.Age,_person.Other)
                                            .Wait();
            this.Close();
        }
        catch (FormatException)
        {
            MessageBox.Show("Please enter valid numeric values for No. and Age.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
