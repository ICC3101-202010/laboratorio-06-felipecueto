using System;
using System.Collections.Generic;

namespace L6
{
    [Serializable()]
    public class Division
    {
        protected string divisioname;
        protected Person employee1;
        protected Person employee2;
        protected Person employee3;

        public Division(string disvisioname, Person employee1)
        {
            this.employee1 = employee1;
            this.divisioname = disvisioname;
        }

        public Division(string disvisioname, Person employee1, Person employee2, Person employee3)
        {
            this.employee1 = employee1;
            this.employee2 = employee2;
            this.employee3 = employee3;
            this.divisioname = disvisioname;

        }

        public string Divisioname { get => divisioname; set => divisioname = value; }
        public Person Employee1 { get => employee1; set => employee1 = value; }
        public Person Employee2 { get => employee2; set => employee2 = value; }
        public Person Employee3 { get => employee3; set => employee3 = value; }
    }
}
