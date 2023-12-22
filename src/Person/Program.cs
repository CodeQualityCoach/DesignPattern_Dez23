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

            // wir sind im composite, und das sind IHrOperation(s)
            IHrOperation p1 = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000), GuidFactory);
            IHrOperation p2 = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000), Guid.NewGuid);
            IHrOperation p3 = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000), Guid.NewGuid);
            IHrOperation p4 = Person.Create("Thomas", "Ley", DateTime.Now.AddDays(-1000), Guid.NewGuid);

            var a = new HrOperationComposite() { Boss = p1 };
            a.Member.Add(p2);
            var a2 = new HrOperationComposite() { Boss = p2 };
            a2.Member.Add(p3);
            a2.Member.Add(p4);
            
            a.IncreaseSalary(0.05);

            // this is the awesome part about composite
            a.Member.Add(a2);
            a.Member.Add(a);

            a.IncreaseSalary(1);
        }

        private static IPerson Factory(string firstName, string lastName)
        {
            return Person.Create(firstName, lastName, DateTime.Now.AddDays(-1000), Guid.NewGuid);
        }

        private static Guid GuidFactory()
        {
            return Guid.NewGuid();
        }
    }

    public class HrOperationComposite : IHrOperation
    {
        public List<IHrOperation> Member { get; set; } = new
            List<IHrOperation>();

        // das ist nicht "original" composite
        public IHrOperation Boss { get; set; }

        public void IncreaseSalary(double percent)
        {
            Boss?.IncreaseSalary(percent * 2);
            Member.ForEach(x => x.IncreaseSalary(percent));
        }
    }
}
