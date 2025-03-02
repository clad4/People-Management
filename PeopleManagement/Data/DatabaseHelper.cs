namespace PeopleManagement.Data;

using Microsoft.Data.Sqlite;
using PeopleManagement.Models;

public static class DatabaseHelper
{
    public static async Task CreateTableHelper(string db, string tbName, string query)
    {
        await using var conn = new SqliteConnection($"Data source={db}");
        await conn.OpenAsync();

        string checkQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName;";

        await using (var cmd = new SqliteCommand(checkQuery, conn))
        {
            cmd.Parameters.AddWithValue("@tableName", tbName);
            var result = await cmd.ExecuteScalarAsync();

            if (result == null)
            {
                await using var createTable = new SqliteCommand(query, conn);
                await createTable.ExecuteNonQueryAsync();
            }
        }
    }
    public static async Task GetPeopleAsync(string connection, string query)
    {
        Program.People.Clear();
        int no = Program.No;
        await using var conn = new SqliteConnection(connection);
        await conn.OpenAsync();

        using (var cmd = new SqliteCommand(query, conn))
        {
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var other = reader.GetOrdinal("PersonId");
                    string? value = reader.IsDBNull(other) ? null : reader.GetString(other); 
                    
                    Program.People.Add(new Person
                    {
                        No = ++no,
                        PersonId = reader.GetInt32(reader.GetOrdinal("PersonId")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Age = reader.GetInt32(reader.GetOrdinal("Age")),
                        Other = value
                    });
                }
            }
        } 
    }
    public static async Task DeletePersonAsync(string connection, string query, int PersonId)
    {
        await using var conn = new SqliteConnection(connection);
        await conn.OpenAsync();

        await using (var cmd = new SqliteCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@PersonId", PersonId);
            await cmd.ExecuteNonQueryAsync();
        }

    }
    public static async Task UpdatePersonAsync(string connection, string query,
                                            int PersonId, string name, int age, string other)
    {
        await using var conn = new SqliteConnection(connection);
        await conn.OpenAsync();

        await using (var cmd = new SqliteCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Name",  name);
            cmd.Parameters.AddWithValue("@Age",  age);
            cmd.Parameters.AddWithValue("@Other",  other);
            cmd.Parameters.AddWithValue("@PersonId", PersonId);
            await cmd.ExecuteNonQueryAsync();
        }

    }
}
