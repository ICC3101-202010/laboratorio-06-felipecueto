using System;
namespace L6
{
    [Serializable()]
    public class Area:Division
    {

        public Area(string disvisioname, Person employee): base (disvisioname,employee)
        {
            this.employee1 = employee;
            this.divisioname = disvisioname;
        }

    }
}
