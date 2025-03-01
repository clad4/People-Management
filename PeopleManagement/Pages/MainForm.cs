using Microsoft.Data.Sqlite;
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
    private string _connection = "Data source=app.db";


    public MainForm()
    {
        InitializeComponent();
        InitializeDatabase().Wait();

        _bindingSource.DataSource = Program.People;
        dgvPers.DataSource = _bindingSource;
        cbSort.DataSource = SortingControls;
        cbSort.DisplayMember = "Name";

        Loading();

        cbSort.SelectedIndexChanged += (sender, e) => Sorted();
        btnNew.Click += OnClickNew;
        btnEdit.Click += OnClickEdit;
        btnDelete.Click += OnClickDelete;
    }

    #region Start-up
    private async Task InitializeDatabase()
    {
        try
        {
            await using (var conn = new SqliteConnection(_connection))
        {
            await conn.OpenAsync();

            //First check if the table exists
            await using (var cmdCheckTable = new SqliteCommand(
                "SELECT name FROM sqlite_master WHERE type='table' AND name='People';", conn))
            {
                var result = await cmdCheckTable.ExecuteScalarAsync();

                // If table doesn't exist, create it
                if (result == null)
                {
                    await using (var cmdCreateTable = new SqliteCommand(
                        @"CREATE TABLE People (
                        No INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Age INTEGER NOT NULL
                    );", conn))
                    {
                        await cmdCreateTable.ExecuteNonQueryAsync();
                    }

                    await using (var insertSample = new SqliteCommand(
                        @"INSERT INTO People (Name, Age) VALUES
                            ('First', 1),
                            ('Second', 2);", conn))
                    {
                        await insertSample.ExecuteNonQueryAsync();
                    };
                }
            }

            //Get people from the table if it exists
            await using (var cmd = new SqliteCommand(
                "SELECT No, Name, Age FROM People;", conn))
            {

                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Program.People.Add(new Person
                        {
                            No = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2)
                        });
                    }
                }
            };
            
        }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK);
        }
    }
    private void Loading()
    {
        dgvPers.RowHeadersVisible = false;
        dgvPers.AllowUserToResizeColumns = false;
        dgvPers.AllowUserToResizeRows = false;
        dgvPers.AllowUserToAddRows = false;
        dgvPers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvPers.AutoResizeColumns();
        dgvPers.ColumnHeadersHeight = 23;
        dgvPers.DefaultCellStyle.Padding = new Padding(3,0,3,0);
        dgvPers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
        dgvPers.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);

        dgvPers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvPers.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvPers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    }
    private void Sorted()
    {
        if (cbSort.SelectedItem is SortingControl selectedSorter)
        {
            List<Person> peopleList = (List<Person>)_bindingSource.DataSource;
            selectedSorter.Sort(peopleList);
        }
        _bindingSource.ResetBindings(false);
    }
    #endregion

    #region Events
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
    #endregion
}
