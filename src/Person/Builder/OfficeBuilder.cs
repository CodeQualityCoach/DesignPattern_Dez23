namespace Person.Builder
{
    class OfficeBuilder : IBuilder
    {
        private int _memberDesks=0;
        private int _bossDesk=0;
        private bool _allowHomeOffice;
        private bool _customerSite;

        public void AddMember(IPerson member)
        {
            _memberDesks++;
        }

        public void AssignBoss(IPerson boss)
        {
            _bossDesk = 1;
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

        public OfficeSetup Build()
        {
            var desks = _memberDesks;
            if (_allowHomeOffice) { desks = desks /2; }
            if (_customerSite) { desks = 0;}

            return new OfficeSetup(desks, _bossDesk);
        }
    }
}