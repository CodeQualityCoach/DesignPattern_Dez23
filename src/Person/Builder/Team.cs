using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Builder
{
    internal class Team
    {
        private IState _state;

        public IPerson Boss { get; }
        public IPerson[] Member { get; }
        public bool WorksAtCustomerSite { get; }
        public bool AllowHomeOffice { get; }

        public Team(IPerson boss, IPerson[] member, bool worksAtCustomerSite, bool allowHomeOffice)
        {
            Boss = boss;
            Member = member;
            WorksAtCustomerSite = worksAtCustomerSite;
            AllowHomeOffice = allowHomeOffice;
        }

        public void Urlaub()
        {
            _state = new ImUrlaubState();
        }

        public void Mache(string task)
        {
            _state.ErledigeArbeit(task);
            // wer ändert jetzt den State?
            if (_state is FreiState)
                _state = new BusyState(task);
        }

        public void BeendeArbeit()
        {
            _state = new FreiState();
        }
    }

    internal interface IState
    {
        void ErledigeArbeit(string task);
    }

    class FreiState : IState
    {
        private readonly Team _team;

        public FreiState(Team team)
        {
            _team = team;
        }
        public void ErledigeArbeit(string task)
        {
            Console.WriteLine("Yes, I will do");
            //_team.State = new BusyState(task);
        }
    }

    class BusyState : IState
    {
        private readonly string _currentTask;

        public BusyState(string currentTask)
        {
            _currentTask = currentTask;
        }

        public void ErledigeArbeit(string task)
        {
            Console.WriteLine("Bin beschäftigt mit " + _currentTask);
        }
    }

    class ImUrlaubState : IState
    {
        public void ErledigeArbeit(string task)
        {
            Console.WriteLine("Bin im Urlaub");
        }
    }
}
