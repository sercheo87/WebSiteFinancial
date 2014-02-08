using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.User
{
    public class Entity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Names { get; set; }
        public string EMail { get; set; }
        public string Type { get; set; }
    }
}
