namespace PeopleManagement.Services;
using Microsoft.Data.Sqlite;
using PeopleManagement.Data;

public class PeopleServices
{
    private readonly string _connection;
    public PeopleServices(string connection)
    {
        _connection = connection;
    }
    public async Task<bool> IsTableExistAsync(string tbName)
    {
        try
        {
            await using var conn = new SqliteConnection(_connection);
            await conn.OpenAsync();
            await using (var cmdCheckTable = new SqliteCommand(
                    "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName;", conn))
            {
                cmdCheckTable.Parameters.AddWithValue("@tableName", tbName);
                var result = await cmdCheckTable.ExecuteScalarAsync();
                return result != null;
            }
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }
    public async Task CreateTableAsync(string tbName)
    {
        try
        {
            string query = 
            $@"CREATE TABLE {tbName} (
                PersonId INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Age INTEGER NOT NULL,
                Other TEXT
            );";
            await DatabaseHelper.CreateTableAsync(_connection, query);
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public async Task InsertValueAsync(string tbName, string name, int age, string? other)
    {
        try
        {
            string query =
                $@"INSERT INTO {tbName} (Name, Age, Other)
                    VALUES (@Name, @Age, @Other);";
            await DatabaseHelper.InsertPersonAsync(_connection,query,name,age,other);
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public async Task GetPeopleAsync(string tbName)
    {
        string query = $@"
            SELECT PersonId, Name, Age, Other
            FROM {tbName};
        ";
        await DatabaseHelper.GetPeopleAsync(_connection, query);
    }
    public async Task DeletePersonAsync(string tbName, int PersonId)
    {
        string query =
            $@"DELETE FROM {tbName}
                WHERE PersonId = @PersonId";
        await DatabaseHelper.DeletePersonAsync(_connection,query,PersonId);
    }
    public async Task UpdatePersonAsync(string tbName, int personId, string name, int age, string other)
    {
        string query =
            $@"UPDATE {tbName}
                SET Name = @Name,
                    Age = @Age,
                    Other = @Other
                WHERE PersonId = @PersonId";
        await DatabaseHelper.UpdatePersonAsync(_connection,query,personId, name, age, other);
    }
}
