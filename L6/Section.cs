using System;
namespace L6
{
    [Serializable()]
    public class Section:Division
    {
        public Section(string disvisioname, Person employee):base (disvisioname,employee)
        {
            this.employee1 = employee;
            this.divisioname = disvisioname;
        }

    }
}
