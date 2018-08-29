using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstproj.Models
{
    public class Form
    {
        public int id  = 0;
        public string formName = "";
        public int numOfSub = 0;
        public List<Field> fields = new List<Field>();

        public Form(string newFormName, int newID ,List<Field> fields)
        {
            this.id = newID;
            this.formName = newFormName;
            this.fields = fields;
        }



    }


}