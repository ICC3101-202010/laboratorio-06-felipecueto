using System;
using System.Collections.Generic;
using System.IO;
namespace L6
{
    [Serializable()]
    public class Company
    {
        private string name;
        private string rut;
        public Company(string name, string rut)
        {
            this.name = name;
            this.rut = rut;
        }

        public string Rut { get => rut; set => rut = value; }
        public string Name { get => name; set => name = value; }
    }
}
