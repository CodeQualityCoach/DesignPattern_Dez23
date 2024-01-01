using System.Runtime.InteropServices;

namespace Person.Builder
{
    internal interface IBuilder
    {
        void AddMember(IPerson member);
        void AssignBoss(IPerson boss);
        void AllowHomeOffice();
        void WorksAtCustomerSite();
    }

    internal interface IChainingBuilder
    {
        IChainingBuilder AddMember(IPerson member);
        IChainingBuilder AssignBoss(IPerson boss);
        IChainingBuilder AllowHomeOffice();
        IChainingBuilder WorksAtCustomerSite();
    }

    internal interface IAwesomeBuilder
    {
        IAwesomeBuilderWithBoss AssignBoss(IPerson boss);
    }

    internal interface IAwesomeBuilderWithBoss
    {
        IAwesomeBuilderWithBossAndMember AddMember(IPerson member);
    }

    internal interface IAwesomeBuilderWithBossAndMember
    {
        IAwesomeBuilderWithBossAndMember AddMember(IPerson member);
        IAwesomeBuilderDefined AllowHomeOffice();
        IAwesomeBuilderDefined WorksAtCustomerSite();
    }

    internal interface IAwesomeBuilderDefined
    {
        Team Build();
    }
}