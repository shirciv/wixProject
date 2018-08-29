using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace firstproj.Models
{
    public class DBService
    {

        public string tableName = "";
        

        public List<SQLiteDataReader> get()
        {
            List<SQLiteDataReader> rowsInfo = new List<SQLiteDataReader>();
            SQLiteConnection m_dbConnection = 
                new SQLiteConnection("Data Source=C:\\Users\\shirciv\\Desktop\\forms project\\database\\" + tableName+ ".db ;Version=3;");
     
            m_dbConnection.Open();
            string sql = "select * from" + tableName;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                for (int i=0; i<reader.FieldCount; i++)
                {
                    
                }
            }
            return rowsInfo;
        }

        public List<SQLiteDataReader> get(int id)
        {
            return null;
        }

        public void insert(string info)
        {

        }

    }
}