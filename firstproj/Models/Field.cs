using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace firstproj.Models
{
    public class Field
    {
        public string label = "";
        public string inputName = "";
        public string type = "";

        public bool isValid()
        {
            if (type != "text" && type != "color" && type != "date" && type != "email" && type != "tel" && type != "number")
                return false;
            else
                return true;
        }




    }
}