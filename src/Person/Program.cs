using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Builder;

namespace Person
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var v = Person.Create("THomas", "Ley", DateTime.Now.AddDays(-1000));

            //var w = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(2));

            var builder = new OfficeBuilder();
            //var builder = new TeamBuilder();

            builder.AllowHomeOffice();
            builder.AddMember(Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000)));
            builder.AddMember(Person.Create("Raja", "Ley", DateTime.Now.AddDays(-1000)));
            builder.AssignBoss(Person.Create("Torsten", "Weber", DateTime.Now.AddDays(-1000)));

            var team = builder.Build();
        }
    }
}
