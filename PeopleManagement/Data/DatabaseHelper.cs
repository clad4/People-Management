namespace PeopleManagement.Data;

using Microsoft.Data.Sqlite;
using PeopleManagement.Models;

public static class DatabaseHelper
{
    public static async Task CreateTableAsync(string connection, string query)
    {
        try
        {
            await using var conn = new SqliteConnection(connection);
            await conn.OpenAsync();
            await using (var cmdCreateTable = new SqliteCommand(query, conn))
            {
                await cmdCreateTable.ExecuteNonQueryAsync();
            }
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static async Task GetPeopleAsync(string connection, string query)
    {
        try
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
                        Program.People.Add(new Person
                        {
                            No = ++no,
                            PersonId = reader.GetInt32(reader.GetOrdinal("PersonId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Age = reader.GetInt32(reader.GetOrdinal("Age")),
                            Other = reader.IsDBNull(reader.GetOrdinal("Other")) ?
                                null : reader.GetString(reader.GetOrdinal("Other"))
                        });
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static async Task InsertPersonAsync(string connection, string query, string name, int age, string? other)
    {
        try
        {
            await using var conn = new SqliteConnection(connection);
            await conn.OpenAsync();
            await using (var cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                if (other ==null) cmd.Parameters.AddWithValue("@Other", DBNull.Value);
                else cmd.Parameters.AddWithValue("@Other", other);

                await cmd.ExecuteNonQueryAsync();
            };
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static async Task DeletePersonAsync(string connection, string query, int PersonId)
    {
        try
        {
            await using var conn = new SqliteConnection(connection);
            await conn.OpenAsync();

            await using (var cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonId", PersonId);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static async Task UpdatePersonAsync(string connection, string query,
                                            int PersonId, string name, int age, string other)
    {
        try
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
        catch (SqliteException ex)
        {
            MessageBox.Show($"SQLite Error: {ex.Message}",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
