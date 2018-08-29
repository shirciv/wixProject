using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstproj.Models
{
    public class User
    {
        public List<string> inputs = new List<string>();
        public int formId;

        public User(int id, List<string> inputs)
        {
            this.formId = id;
            this.inputs = inputs;
        }
    }
}