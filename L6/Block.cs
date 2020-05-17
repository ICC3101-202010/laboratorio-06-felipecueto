using System;
namespace L6
{
    [Serializable()]
    internal class Block:Division
    {
        public Block(string disvisioname, Person employee1, Person employee2, Person employee3):base(disvisioname,employee1, employee2,employee3)
        {
            this.employee1 = employee1;
            this.employee2 = employee2;
            this.employee3 = employee3;
            this.divisioname = disvisioname;
        }
    }
}