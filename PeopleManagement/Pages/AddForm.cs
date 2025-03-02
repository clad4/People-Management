namespace PeopleManagement.Pages;
using PeopleManagement.Models;
using PeopleManagement.Services;

public partial class AddForm : Form
{
    private Person _person = new();
    private readonly string _connection;
    private readonly string _table;
    private PeopleServices _peopleServices;
    private int _no = Program.People.Count();
    public AddForm(string connection, string table)
    {
        _connection = connection;
        _table = table;
        _peopleServices = new PeopleServices(_connection);
        InitializeComponent();

        tbNo.ReadOnly = true;
        tbNo.Text = (_no + 1).ToString();

        btnCancel.Click += (sender, e) => this.Close();
        btnAdd.Click += BtnAddClicked;
    }
    public void BtnAddClicked(object? sender, EventArgs e)
    {
        try
        {
            _person.Name = tbName.Text.Trim();
            _person.Age = int.Parse(tbAge.Text);
            _person.Other = tbOther.Text.Trim();

            _peopleServices.InsertValueAsync(_table, _person.Name, _person.Age, _person.Other).Wait();
            this.Close();
        }
        catch (FormatException)
        {
            MessageBox.Show("Please enter valid numeric values for No. and Age.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
