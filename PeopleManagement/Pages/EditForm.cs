namespace PeopleManagement.Pages;
using PeopleManagement.Models;
using System.Windows.Forms;

public partial class EditForm : Form
{
    private Person _person;
    public EditForm(Person source)
    {
        InitializeComponent();
        _person = source;
        Loading();

        btnCancel.Click += (sender, e) => this.Close();
        btnEdit.Click += BtnEditClicked;
    }
    public void Loading()
    {
        tbNo.Text = _person.No.ToString();
        tbName.Text = _person.Name.ToString();
        tbAge.Text = _person.Age.ToString();
    }
    public void BtnEditClicked (object? sender, EventArgs e)
    {
        try
        {
            _person.No = int.Parse(tbNo.Text);
            _person.Name = tbName.Text.Trim();
            _person.Age = int.Parse(tbAge.Text);

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
