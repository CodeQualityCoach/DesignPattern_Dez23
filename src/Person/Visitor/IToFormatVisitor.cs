namespace Person
{
    public interface IToFormatVisitor
    {
        // here comes the Polymorphism. Im Original: VisitPerson, VisitAbteilung
        void Visit(Person person);
        void Visit(Abteilung abteilung);
        // Frage: Warum nicht das Interface? 
    }
}