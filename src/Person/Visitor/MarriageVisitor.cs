namespace Person
{
    public class MarriageVisitor : IOpsVisitor
    {
        public void DoVisit(Person p)
        {
            p.LastName = p.Spouse?.LastName ?? p.LastName;
        }

        public void DoVisit(Pet p)
        {
            
        }
    }
}