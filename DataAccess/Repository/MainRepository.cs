using Dapper;
using Infrastructure.Entities;
using System;
using System.Data.SQLite;
using System.Linq;

namespace DataAccess.Repository
{

    public class MainRepository : IMainRepository
    {
        private readonly string DatabasePath = @"DataSource=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/LiveJourney.db;foreign keys=true;";

        public MainRepository()
        {
            this.CreateDatabase();
        }

        private void CreateDatabase()
        {
            this.CreateUserTable();
            this.InsertAdminUser();
        }

        private static string CREATE_USER_TABLE =
            @"
                CREATE TABLE IF NOT EXISTS [UserTable] 
           (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
           Username TEXT NOT NULL,
            Password TEXT NOT NULL,
            AdminType INTEGER);
            ";

        private static string INSERT_ADMIN_USER = @"INSERT INTO UserTable (Username,Password,AdminType) VALUES(@Username,@Password,@AdminType);";

        private static string GET_USER = @"SELECT * FROM UserTable WHERE Username = :Username;";

        private void CreateUserTable()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(CREATE_USER_TABLE, sqliteConnection))
                    {
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void InsertAdminUser()
        {
            if (this.GetUser("Admin") != null)
            {
                return;
            }

            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(INSERT_ADMIN_USER, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@Username", "Admin");
                        mCmd.Parameters.AddWithValue("@Password", "admin");
                        mCmd.Parameters.AddWithValue("@AdminType", 1);
                        mCmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserModel GetUser(string username)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<UserModel>(GET_USER, new
                    {
                        Username = username
                    }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new UserModel();
            }
        }
    }
}
