using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace firstproj.Models
{
    public class UsersDbService
    {
        private string path = "Data Source=C:\\Users\\shirciv\\Desktop\\forms project\\database\\FormTypes.db ;Version=3;";


        //returns all the users info for the given id form
        public List<User> Get(int id)
        {
            List<User> users = new List<User>();
            SQLiteConnection m_dbConnection = new SQLiteConnection(path);
            m_dbConnection.Open();
            string sql = "select fields from Users where formId="+id+";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User(id,json2inputlist(reader["fields"].ToString())));
            }
            m_dbConnection.Close();
            return users;
        }

        public List<string> json2inputlist (string json)
        {
            return new JavaScriptSerializer().Deserialize<List<string>>(json);
        }

        public string inputList2json (List<string> inputs)
        {
            var json = JsonConvert.SerializeObject(inputs);
            return json;
        }

        public void insert(User newUser)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(path);
            m_dbConnection.Open();
            string sql = "INSERT into Users (formId,fields) VALUES (" + newUser.formId + ",'" + inputList2json(newUser.inputs) + "');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            m_dbConnection.Close();
        }




    }
}