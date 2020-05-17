using System;
namespace L6
{
    [Serializable()]
    public class Person
    {
        private string name;
        private string lastName;
        private string position;
        private string rut;

        public Person(string name, string lastName, string position, string rut)
        {
            this.name = name;
            this.lastName = lastName;
            this.position = position;
            this.rut = rut;
        }

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Position { get => position; set => position = value; }
        public string Rut { get => rut; set => rut = value; }

    }
}
