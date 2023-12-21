using System.Collections.Generic;
using System.Linq;

namespace Person.Builder
{
    internal class TeamDirector
    {
        private readonly List<IBuilder> _builder;

        public TeamDirector(IBuilder officeBuilder, IBuilder builder)
        {
            _builder =new List<IBuilder>( new[] { officeBuilder, builder });
        }

        public void CreateCustomerTeam(IPerson boss, IPerson[] member)
        {
            _builder.ForEach(x=>x.WorksAtCustomerSite());
            _builder.ForEach(x=>x.AssignBoss(boss));
            _builder.ForEach(x => member.ToList().ForEach(x.AddMember));
        }

        public void AddAssistant(IPerson person)
        {
            _builder.ForEach(x => x.AddMember(person));
        }
    }
}