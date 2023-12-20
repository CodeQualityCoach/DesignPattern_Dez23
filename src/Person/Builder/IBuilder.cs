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
}