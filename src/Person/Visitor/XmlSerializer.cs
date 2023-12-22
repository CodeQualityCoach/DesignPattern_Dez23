namespace Person
{
    public class XmlSerializer : IOpsVisitor
    {
        public void DoVisit(Person p)
        {
            // Zurückliefern der Daten als JSON-Zeichenkette...
            var res = p.LastName;
        }

        public void DoVisit(Pet p)
        {
            
        }
    }
}