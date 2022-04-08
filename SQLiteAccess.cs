using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data;

namespace WpfApp3
{
    class SQLiteAccess
    {
        public static string dbFileDirectory = Environment.CurrentDirectory;
        private static readonly string dbFilePath = System.IO.Path.Combine(dbFileDirectory, "database.db");
        private static readonly string _connectionString = string.Format("Data Source = {0}", dbFilePath);

        public static List<Pope> Read()
        {
            List<Pope> dbPopesList = new();
            SqliteConnection dbConnection = new(_connectionString);

            dbConnection.Open();

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Close();
                return null;
            }

            string dbQuery = "SELECT * FROM Popes";
            SqliteCommand dbCommand = new(dbQuery, dbConnection);

            SqliteDataReader dbDataReader = dbCommand.ExecuteReader();

            while (dbDataReader.Read())
            {
                Pope pope = new
                (
                    Convert.ToInt32(dbDataReader["Id"]),
                    dbDataReader["Name"].ToString(),
                    dbDataReader["Description"].ToString(),
                    dbDataReader["ImagePath"].ToString()
                );

                dbPopesList.Add(pope);
            }

            dbConnection.Close();
            return dbPopesList;
        }

        public static bool Create(Pope item)
        {
            bool Success = false;
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Close();
                return false;
            }

            string dbQuery = string.Format("SELECT COUNT(Id) FROM Popes WHERE Name = '{0}'", item.Name);
            SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);

            long result = (long)dbCommand.ExecuteScalar();
            if (result == 0)
            {
                dbQuery = string.Format("INSERT INTO Popes VALUES(null, '{0}', '{1}', '{2}' )", item.Name, item.Description, item.ImagePath);
                dbCommand.CommandText = dbQuery;
                if (dbCommand.ExecuteNonQuery() == 1)
                {
                    Success = true;
                }
            }

            dbConnection.Close();
            return Success;
        }

        public static bool Delete(Pope item)
        {
            bool Success = false;
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Close();
                return false;
            }

            string dbQuery = string.Format("SELECT COUNT(Id) FROM Popes WHERE Name = '{0}'", item.Name);
            SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);

            long result = (long)dbCommand.ExecuteScalar();
            if (result == 1)
            {
                dbQuery = string.Format("DELETE FROM Popes WHERE Name = '{0}'", item.Name);
                dbCommand.CommandText = dbQuery;

                if (dbCommand.ExecuteNonQuery() == 1)
                {
                    Success = true;
                }
            }
            dbConnection.Close();
            return Success;
        }

        public static bool Update(Pope item)
        {
            bool Success = false;
            SqliteConnection dbConnection = new SqliteConnection(_connectionString);
            dbConnection.Open();

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Close();
                return false;
            }

            string dbQuery = string.Format("SELECT COUNT(Id) FROM Popes WHERE Name = '{0}'", item.Name);
            SqliteCommand dbCommand = new SqliteCommand(dbQuery, dbConnection);

            long result = (long)dbCommand.ExecuteScalar();
            if (result == 1)
            {
                dbQuery = string.Format("UPDATE Popes SET Name = '{0}', Description = '{1}', ImagePath = '{2}' WHERE Id = '{3}'", item.Name, item.Description, item.ImagePath, item.ID);
                dbCommand.CommandText = dbQuery;

                dbCommand.ExecuteNonQuery();
                Success = true;
            }
            dbConnection.Close();
            return Success;
        }
    }
}
