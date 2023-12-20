using System.Collections.Generic;
using System.Linq;

namespace Person.Builder
{
    class TeamBuilder : IBuilder
    {
        private readonly List<IPerson> _member = new List<IPerson>();
        private IPerson _boss;
        private bool _allowHomeOffice = false;
        private bool _customerSite = false;

        public void AddMember(IPerson member)
        {
            _member.Add(member);
        }

        public void AssignBoss(IPerson boss)
        {
            _boss = boss;
        }

        public void AllowHomeOffice()
        {
            _allowHomeOffice = true;
            _customerSite = false;
        }

        public void WorksAtCustomerSite()
        {
            _allowHomeOffice = false;
            _customerSite = true;
        }

        public Team Build()
        {
            if (_member.Count == 0) throw new TeamHasNoMemberException();
            if (_boss == null) _boss = _member.First(); // Primus inter Pares

            return new Team(_boss, _member.ToArray(), _customerSite, _allowHomeOffice);
        }
    }
}