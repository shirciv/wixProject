using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace firstproj.Models
{
    public class FormsDbService
    {
        public string path = "Data Source=C:\\Users\\shirciv\\Desktop\\forms project\\database\\FormTypes.db ;Version=3;";
        //returns all the existing forms
        public List<Form> Get()
        {
            List<Form> forms = new List<Form>();
            SQLiteConnection m_dbConnection = new SQLiteConnection(path);
            m_dbConnection.Open();
            string sql = "select * from FormTypes";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                forms.Add(new Form(reader["name"].ToString(), Convert.ToInt32(reader["id"]), string2Fields(reader["fields"].ToString())));
            }
            m_dbConnection.Close();
            return forms;
        }

        //returns the fields of the given id form
        public List<Field> Get(int id)
        {
            List<Field> fields = new List<Field>();
            SQLiteConnection m_dbConnection = new SQLiteConnection(path);
            m_dbConnection.Open();
            string sql = "select fields from FormTypes where id=" + id + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            reader.Read();      //suppose to be only one row - because each id is unique
            fields = string2Fields(reader["fields"].ToString());

            m_dbConnection.Close();
            return fields;
        }




        public void insert(ParticialForm newform)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(path);
            m_dbConnection.Open();
            //string sql = "INSERT into FormTypes VALUES (3,'friendship',0,'api','api','sdsdsd')";
            string sql = "INSERT into FormTypes(name,numOfSub,fields) VALUES ('" + newform.formName + "',0,'" + Fields2string(newform.fields) + "');";
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

        public List<Field> string2Fields(string info)      //json string into list of fields
        {
            return new JavaScriptSerializer().Deserialize<List<Field>>(info);
        }

        public string Fields2string(List<Field> fields)
        {
            // var json = new JavaScriptSerializer().Serialize(obj);
            var json = JsonConvert.SerializeObject(fields);
            return json;
        }

        public void update(int id, Form form)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(path);
            m_dbConnection.Open();
            string sql = "UPDATE FormTypes SET numOfSub=numOfSub+1 WHERE id=" + id;
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