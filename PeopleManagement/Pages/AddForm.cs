namespace PeopleManagement.Pages;
using PeopleManagement.Models;

public partial class AddForm : Form
{
    private Person _person = new();
    private BindingSource _bindingSource;
    public AddForm(BindingSource source)
    {
        InitializeComponent();
        _bindingSource = source;
        btnCancel.Click += (sender, e) => this.Close();
        btnAdd.Click += BtnAddClicked;
    }
    public void BtnAddClicked (object? sender, EventArgs e)
    {
        try{
            _person.No = int.Parse(tbNo.Text);
            _person.Name = tbName.Text.Trim();
            _person.Age = int.Parse(tbAge.Text);

            _bindingSource.Add(_person);
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
