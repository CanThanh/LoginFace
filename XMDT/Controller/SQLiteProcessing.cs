using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static EAGetMail.SStorage;
using System.Drawing;
using XMDT.Model;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.IO;

namespace XMDT.Controller
{
    internal class SQLiteProcessing
    {
        string absolutePath = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + @"\File\db\facebook.sqlite";
        SQLiteConnection _con = new SQLiteConnection();
        public void createConection()
        {
            _con.ConnectionString = string.Format("DataSource={0}", absolutePath);
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
                " Name TEXT)"; 
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS ACCOUNTS (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, UId TEXT," +
                " Info TEXT)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS INTERACTS (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                " UId TEXT, TimeInteract TEXT, Action TEXT, Config TEXT)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
            closeConnection();
        }

        #region File
        public List<string> getAllFile()
        {
            var result = new List<string>();
            try
            {
                createConection();
                string sql = "SELECT Name FROM FILES";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new List<string>();
            }
            finally
            {
                closeConnection();
            }
            return result;
        }

        public bool InsertOrUpdateFile(string name)
        {
            var result = true;
            try
            {
                createConection();
                string sql = "SELECT COUNT(*) FROM FILES WHERE Name = @name";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                command.Parameters.AddWithValue("@name", name);
                var count = Convert.ToInt32(command.ExecuteScalar());
                if(count == 0)
                {
                    sql = "INSERT INTO FILES(Name) VALUES(@name)";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                closeConnection();
            }
            return result;
        }

        public bool DeleteFile(string name)
        {
            var result = true;
            try
            {
                createConection();
                string sql = "DELTE FROM FILES WHERE name = @name";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
        #endregion File

        #region Account
        public List<AccountInfo> getAllAccount()
        {
            var result = new List<AccountInfo>();
            try
            {
                createConection();
                string sql = "SELECT Info FROM ACCOUNTS";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var accountInfo = JsonConvert.DeserializeObject<AccountInfo>(reader.GetString(0));
                    if (accountInfo != null && !string.IsNullOrEmpty(accountInfo.Id))
                    {
                        result.Add(accountInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new List<AccountInfo>();
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
        public bool InsertOrUpdateLstAccount(List<AccountInfo> lstAccountInfo)
        {
            var result = true;
            try
            {
                createConection();
                SQLiteCommand command = new SQLiteCommand(_con);
                using (var transaction = _con.BeginTransaction())
                {
                    foreach (var accountInfo in lstAccountInfo)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "SELECT COUNT(*) FROM ACCOUNTS WHERE UId = @uid";
                        command.Parameters.AddWithValue("@uid", accountInfo.Id);
                        var count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 0)
                        {
                            command.CommandText = "INSERT INTO ACCOUNTS(UId, Info) VALUES(@uid, @info)";
                            command.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(accountInfo));
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            command.CommandText = "UPDATE ACCOUNTS SET INFO = @info WHERE Uid = @uid";
                            command.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(accountInfo));
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
            public bool InsertOrUpdateAccount(AccountInfo accountInfo)
        {
            var result = true;
            try
            {
                createConection();
                SQLiteCommand command = new SQLiteCommand(_con);
                command.Parameters.Clear();
                command.CommandText = "SELECT COUNT(*) FROM ACCOUNTS WHERE UId = @uid";
                command.Parameters.AddWithValue("@uid", accountInfo.Id);
                var count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    command.CommandText = "INSERT INTO ACCOUNTS(UId, Info) VALUES(@uid, @info)";
                    command.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(accountInfo));
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText = "UPDATE ACCOUNTS SET INFO = @info WHERE Uid = @uid";
                    command.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(accountInfo));
                    command.ExecuteNonQuery();
                }                   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
        public bool DeleteAccount(string uid)
        {
            var result = true;
            try
            {
                createConection();
                string sql = "DELTE FROM ACCOUNTS WHERE Uid = @uid";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                command.Parameters.AddWithValue("@uid", uid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
        #endregion
    }
}
