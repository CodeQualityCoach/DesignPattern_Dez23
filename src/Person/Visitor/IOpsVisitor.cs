namespace Person
{
    public interface IOpsVisitor
    {
        void DoVisit(Person p);
        void DoVisit(Pet p);
    }
}