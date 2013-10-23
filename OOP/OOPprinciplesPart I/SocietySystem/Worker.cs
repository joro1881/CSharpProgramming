using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySystem
{
    public class Worker : Human
    {
        public float WeekSalary { get; set; }
        public float WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, float salary, float workhours)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workhours;
        }

        public double MoneyPerHour()
        {
            return WeekSalary / (double)((WorkHoursPerDay * 5));
        }


    }
}
