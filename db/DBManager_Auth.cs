using System;
using System.Data.SQLite;

namespace IdeasAi.db
{
    public class DBManager_Auth
    {
        private readonly string dbFilePath;

        public DBManager_Auth(string dbFilePath)
        {
            this.dbFilePath = dbFilePath;
            CreateUserTableIfNotExists();
        }

        private void CreateUserTableIfNotExists()
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS User (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );
                ";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Login(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(1) FROM User WHERE Username = @Username AND Password = @Password;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int result = Convert.ToInt32(command.ExecuteScalar());
                    return result == 1;
                }
            }
        }
    }
}
