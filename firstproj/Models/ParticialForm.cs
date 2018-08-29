using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstproj.Models
{
    public class ParticialForm
    {
        public string formName = "";
        public List<Field> fields = new List<Field>();

        public ParticialForm(string newFormName, List<Field> fields)
        {
            this.formName = newFormName;
            this.fields = fields;
        }



    }


}