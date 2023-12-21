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

            //var builder1 = new OfficeBuilder();
            //var builder2 = new TeamBuilder();

            //var director = new TeamDirector(builder1, builder2);
            //director.AddAssistant(Person.Create("Raja", "Ley", DateTime.Now.AddDays(-100)));

            //var team = builder1.Build();
            //var office = builder2.Build();

            var b = new TeamBuilder();
            b.AddFuncMember(Factory);

            var p = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000), GuidFactory);
           // var p = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000), i => Guid.NewGuid());
        }

        private static IPerson Factory(string firstName, string lastName)
        {
            return Person.Create(firstName, lastName, DateTime.Now.AddDays(-1000), i => Guid.NewGuid());
        }

        private static Guid GuidFactory(int arg)
        {
            return Guid.NewGuid();
        }
    }
}
