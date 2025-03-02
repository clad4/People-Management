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
    public async Task CreateTableAsync(string tbName)
    {
        string query = 
        $@"CREATE TABLE {tbName} (
            PersonId INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Age INTEGER NOT NULL,
            Other TEXT
        );";
        await using var conn = new SqliteConnection(_connection);
        await conn.OpenAsync();
        await using (var cmdCreateTable = new SqliteCommand(query, conn))
        {
            await cmdCreateTable.ExecuteNonQueryAsync();
        }
        //await DatabaseHelper.CreateTableHelper(_db, tbName, query);
    }
    public async Task InsertSampleValueAsync(string tbName)
    {
        string query =
            $@"INSERT INTO {tbName} (Name, Age)
                VALUES (@Name, @Age);";
        await using var conn = new SqliteConnection(_connection);
        await conn.OpenAsync();
        await using (var insertSample = new SqliteCommand(query, conn))
        {
            insertSample.Parameters.AddWithValue("@Name", "First");
            insertSample.Parameters.AddWithValue("@Age", 21);
            await insertSample.ExecuteNonQueryAsync();
        };
        //await DatabaseHelper.InsertValueHelper(_db,query);
    }
    public async Task InsertValueAsync(string tbName, string name, int age)
    {
        string query =
            $@"INSERT INTO {tbName} (Name, Age)
                VALUES (@Name, @Age);";
        await using var conn = new SqliteConnection(_connection);
        await conn.OpenAsync();
        await using (var insertSample = new SqliteCommand(query, conn))
        {
            insertSample.Parameters.AddWithValue("@Name", name);
            insertSample.Parameters.AddWithValue("@Age", age);
            await insertSample.ExecuteNonQueryAsync();
        };
        //await DatabaseHelper.InsertValueHelper(_db,query);
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
