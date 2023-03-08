using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static EAGetMail.SStorage;
using System.Drawing;
using XMDT.Model;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.IO;
using static XMDT.Model.FaceInfo;
using System.Security.Cryptography;

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
                " Name TEXT, CreatedDate TEXT, Active INTEGER)"; 
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS ACCOUNTS (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, UId TEXT," +
                " Info TEXT, IdFile INTEGER)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS INTERACTS (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                " UId TEXT, TimeInteract TEXT, Action TEXT, Config TEXT)";
            command.CommandText = sql;
            command.ExecuteNonQuery();
            closeConnection();
        }

        #region File
        public List<ComboboxItem> getAllFile()
        {
            var result = new List<ComboboxItem>();
            try
            {
                createConection();
                string sql = "SELECT Id, Name FROM FILES WHERE Active = 1";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var value = reader.GetInt32(0).ToString();
                    var text = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem()
                    {
                        Value = value,
                        Text = text,
                    };
                    result.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new List<ComboboxItem>();
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
                    command.CommandText = "INSERT INTO FILES (Name, CreatedDate, Active) VALUES (@name, @createdate, @active)";
                    command.Parameters.AddWithValue("@createdate", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@active", 1);
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

        public bool DeleteFile(string idFile)
        {
            var result = true;
            try
            {
                createConection();
                //string sql = "DELTE FROM FILES WHERE name = @name";
                string sql = "UPDATE FROM FILES Set Active = 0 WHERE Id = @idFile";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                command.Parameters.AddWithValue("@idFile", idFile);
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
        public List<AccountInfo> getAllAccount(string idfile)
        {
            var result = new List<AccountInfo>();
            try
            {
                createConection();
                string sql = "SELECT Info FROM ACCOUNTS WHERE IdFile = @idfile";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                command.Parameters.AddWithValue("@idfile", idfile);
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
        public bool InsertOrUpdateLstAccount(List<AccountInfo> lstAccountInfo, string idFile)
        {
            var result = true;
            try
            {
                createConection();
                SQLiteCommand command = new SQLiteCommand(_con);
                //command.CommandText = "SELECT Id FROM FILES WHERE Name = @fileName";
                //command.Parameters.AddWithValue("@fileName", fileName);
                //var idFile = Convert.ToInt32(command.ExecuteScalar());
                using (var transaction = _con.BeginTransaction())
                {
                    foreach (var accountInfo in lstAccountInfo)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "SELECT COUNT(*) FROM ACCOUNTS WHERE UId = @uid AND IdFile = @idfile";
                        command.Parameters.AddWithValue("@uid", accountInfo.Id);
                        command.Parameters.AddWithValue("@idfile", idFile);
                        var count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 0)
                        {
                            command.CommandText = "INSERT INTO ACCOUNTS(UId, Info, IdFile) VALUES(@uid, @info, @idfile)";
                            command.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(accountInfo));
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            command.CommandText = "UPDATE ACCOUNTS SET INFO = @info WHERE Uid = @uid AND IdFile = @idfile";
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
            public bool InsertOrUpdateAccount(AccountInfo accountInfo, string idFile)
        {
            var result = true;
            try
            {
                createConection();
                SQLiteCommand command = new SQLiteCommand(_con);
                //command.CommandText = "SELECT Id FROM FILES WHERE Name = @fileName";
                //command.Parameters.AddWithValue("@fileName", fileName);
                //var idFile = Convert.ToInt32(command.ExecuteScalar());
                command.Parameters.Clear();
                command.CommandText = "SELECT COUNT(*) FROM ACCOUNTS WHERE UId = @uid AND IdFile = @idfile";
                command.Parameters.AddWithValue("@uid", accountInfo.Id);
                command.Parameters.AddWithValue("@idfile", idFile);
                var count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    command.CommandText = "INSERT INTO ACCOUNTS(UId, Info, IdFile) VALUES(@uid, @info, @idfile)";
                    command.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(accountInfo));
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText = "UPDATE ACCOUNTS SET INFO = @info WHERE Uid = @uid AND IdFile = @idfile";
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
        public bool DeleteAccount(string uid, string idFile)
        {
            var result = true;
            try
            {
                createConection();
                string sql = "DELETE FROM ACCOUNTS WHERE Uid = @uid AND IdFile = @idfile";
                SQLiteCommand command = new SQLiteCommand(sql, _con);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@idfile", idFile);
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
        public bool DeleteListAccount(List<string> lstUserId, string idFile)
        {
            var result = true;
            try
            {
                createConection();
                using (var transaction = _con.BeginTransaction())
                {
                    SQLiteCommand command = new SQLiteCommand(_con);
                    foreach (var item in lstUserId)
                    {
                        command.Parameters.Clear();
                        command.CommandText =  "DELETE FROM ACCOUNTS WHERE Uid = @uid AND IdFile = @idfile";
                        command.Parameters.AddWithValue("@uid", item);
                        command.Parameters.AddWithValue("@idfile", idFile);
                        command.ExecuteNonQuery();
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
        #endregion
    }
}
