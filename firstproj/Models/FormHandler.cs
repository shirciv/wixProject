using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;


namespace firstproj.Models
{
    public class FormHandler
    {
        DBService db = new DBService();

        public List<Form> Get()
        {
            List<Form> forms = new List<Form>();
            List<SQLiteDataReader> rows = db.get();
            //rows.ForEach(row => forms.Add(new Form(row["name"].ToString(), Convert.ToInt32(row["id"]), row["fields"].ToString()) ));    //handle fields!!!!!!!!!!!
            return forms;
        }

      /*  public List<Field> Get(int id)
        {
            List<Field> fields = new List<Field>();
 
        }
        */



    }
}