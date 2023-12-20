using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var v = Person.Create("THomas", "Ley", DateTime.Now.AddDays(-1000));

            var w = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(2));

        }
    }
}
