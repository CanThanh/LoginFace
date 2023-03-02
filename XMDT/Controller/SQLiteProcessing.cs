using System;
using System.Data.SQLite;

namespace XMDT.Controller
{
    internal class SQLiteProcessing
    {
        string _strConnect = "Data Source=db_facebook.sqlite;";
        SQLiteConnection _con = new SQLiteConnection();
        public void createConection()
        {
            _con.ConnectionString = _strConnect;
            _con.Open();
        }

        public void closeConnection()
        {
            _con.Close();
        }

        public void createTable()
        {
            createConection();
            string sql = "CREATE TABLE IF NOT EXISTS FILES (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                " Name TEXT, CreatedDate TEXT, Active INT)"; 
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS ACCOUNTS (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                " Info TEXT)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS INTERACTS (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                " UId TEXT, TimeInteract TEXT, Action TEXT, Config TEXT)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void insertDataTest()
        {
            createConection();
            string sql = "INSERT INTO FILES(Name, CreatedDate, Active) VALUES('BTH','" + DateTime.Now.ToString() + "', 1)";
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
