using PeopleManagement.Models;
using PeopleManagement.SortingControls;

namespace PeopleManagement.Pages;
public partial class MainForm : Form
{
    private BindingSource _bindingSource = new();
    private List<SortingControl> SortingControls = new List<SortingControl>
    {
        new NoSorter(),
        new NameSorter(),
        new AgeSorter(),
    };

    public MainForm()
    {
        InitializeComponent();

        _bindingSource.DataSource = Program.People;
        dgvPers.DataSource = _bindingSource;
        cbSort.DataSource = SortingControls;
        cbSort.DisplayMember = "Name";

        Loading();

        cbSort.SelectedIndexChanged += (sender, e) =>
        {
            Sorted();
        };
        btnNew.Click += OnClickNew;
        btnEdit.Click += OnClickEdit;
        btnDelete.Click += OnClickDelete;
    }
   
    public void Loading()
    {
        dgvPers.AutoGenerateColumns = false;
        dgvPers.RowHeadersVisible = false;
        dgvPers.AllowUserToResizeColumns = false;
        dgvPers.AllowUserToResizeRows = false;
        dgvPers.AllowUserToAddRows = false;

        dgvPers.AutoResizeColumns();
        dgvPers.ColumnHeadersHeight = 23;
        dgvPers.DefaultCellStyle.Padding = new Padding(3,0,3,0);
        dgvPers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
        dgvPers.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);

        dgvPers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvPers.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvPers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    }
    public void Sorted()
    {
        if (cbSort.SelectedItem is SortingControl selectedSorter)
        {
            List<Person> peopleList = (List<Person>)_bindingSource.DataSource;
            selectedSorter.Sort(peopleList);
        }
        _bindingSource.ResetBindings(false);
    }
    private void OnClickNew(object? sender, EventArgs e)
    {
        var newPerson = new AddForm(_bindingSource);
        newPerson.FormClosed += (sender, e) => 
        {
            Sorted();
        };
        newPerson.ShowDialog();
    }
    private void OnClickDelete(object? sender, EventArgs e)
    {
        if (_bindingSource.Current == null) return;
        if (_bindingSource.Current is Person delPer)
        {
            var result = Program.People.Remove(delPer);
            if (result == true) _bindingSource.ResetBindings(false);
        }
    }
    private void OnClickEdit(object? sender, EventArgs e)
    {
        if (_bindingSource.Current is Person person)
        {
            var editForm = new EditForm(person);
            editForm.FormClosed += (sender, e) =>
            {
                Sorted();
            };
            editForm.ShowDialog();
        }
    }
}
