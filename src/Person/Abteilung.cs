using System.Collections.Generic;

namespace Person
{
    public class Abteilung : IHrOperation
    {
        public List<Person> Member { get; set; } = new 
            List<Person>();

        public Person Boss { get; set; }

        public void IncreaseSalary(double percent)
        {
            Boss?.IncreaseSalary(percent*2);
            Member.ForEach(x=>x.IncreaseSalary(percent));
        }
    }
}