using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace L6
{
    [Serializable()]
    public class Company
    {
        private string name;
        private string rut;
        private List<Division> divisions;
        public Company(string name, string rut, List<Division> divisions)
        {
            this.name = name;
            this.rut = rut;
            this.divisions = divisions;
        }
        public string Rut { get => rut; set => rut = value; }
        public string Name { get => name; set => name = value; }
        public List<Division> Divisions { get => divisions; set => divisions = value; }

    }
    
}
