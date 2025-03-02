using Microsoft.Data.Sqlite;
using PeopleManagement.Models;
using PeopleManagement.Services;
using PeopleManagement.SortingControls;
using System.Data;
using System.Net.Mail;

namespace PeopleManagement.Pages;
public partial class MainForm : Form
{
    private List<SortingControl> SortingControls = new List<SortingControl>
    {
        new NoSorter(),
        new NameSorter(),
        new AgeSorter(),
    };
    private BindingSource _bs = new();

    private PeopleServices _pps;
    private readonly string _connection = "Data source=Data/app.db";
    private readonly string _table = "People"; 

    public MainForm()
    {
        InitializeComponent();
        _pps = new PeopleServices(_connection);

        LoadDataAsync().Wait();
        LoadingStates();

        cbSort.SelectedIndexChanged += (sender, e) => Sorted();
        btnNew.Click += OnClickNewAsync;
        btnEdit.Click += OnClickEdit;
        btnDelete.Click += OnClickDelete;
    }

    #region Start-up
    private async Task LoadDataAsync()
    {
        try
        {
            if(!await _pps.IsTableExistAsync(_table))
            {
                await _pps.CreateTableAsync(_table);
            }

            await _pps.GetPeopleAsync(_table);

            _bs.DataSource = Program.People;
            dgvPers.DataSource = _bs;
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show($"Invalid Operation Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (OverflowException ex)
        {
            MessageBox.Show($"Overflow Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Failed to load data: {e.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void LoadingStates()
    {
        cbSort.DataSource = SortingControls;
        cbSort.DisplayMember = "Name";
        cbSort.DropDownStyle = ComboBoxStyle.DropDownList;

        dgvPers.RowHeadersVisible = false;
        dgvPers.AllowUserToResizeColumns = false;
        dgvPers.AllowUserToResizeRows = false;
        dgvPers.AllowUserToAddRows = false;
        dgvPers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPers.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        dgvPers.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        dgvPers.AutoResizeColumns();
        dgvPers.ColumnHeadersHeight = 23;
        dgvPers.DefaultCellStyle.Padding = new Padding(1,0,0,0);
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
            List<Person> peopleList = (List<Person>)_bs.DataSource;
            selectedSorter.Sort(peopleList);
        }
        _bs.ResetBindings(false);
    }
    #endregion

    #region Events
    private void OnClickNewAsync(object? sender, EventArgs e)
    {
        var newPerson = new AddForm(_connection, _table);
        newPerson.FormClosed += (sender, e) =>
        {
            Sorted();
            LoadDataAsync().Wait();
            _bs.ResetBindings(false);
        };
        newPerson.ShowDialog();
    }
    private async void OnClickDelete(object? sender, EventArgs e)
    {
        if (_bs.Current == null) return;
        if (_bs.Current is Person person)
        {
            await _pps.DeletePersonAsync(_table, person.PersonId);
        }
        //LoadDataAsync().Wait();
        _bs.ResetBindings(false);

        //delete table
        //await using var conn = new SqliteConnection(_connection);
        //await conn.OpenAsync();
        //await using var cmd = new SqliteCommand($"DROP TABLE {_table}", conn);
        //await cmd.ExecuteNonQueryAsync();
    }
    private void OnClickEdit(object? sender, EventArgs e)
    {
        if (_bs.Current == null) return;
        if (_bs.Current is Person person)
        {
            var editForm = new EditForm(_connection, _table, person);
            editForm.FormClosed += (sender, e) =>
            {
                Sorted();
                LoadDataAsync().Wait();
                _bs.ResetBindings(false);
            };
            editForm.ShowDialog();
        }
    }
    #endregion
}
