using System;
namespace L6
{
    [Serializable()]
    public class Department:Division
    {
        public Department(string divisioname, Person employee): base(divisioname, employee)
        {
            this.employee1 = employee;
            this.divisioname = divisioname;
        }

    }
}
