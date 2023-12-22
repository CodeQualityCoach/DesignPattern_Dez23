namespace Person
{
    public class JsonSerializer : IOpsVisitor
    {
        public void DoVisit(Person p)
        {
            // Zurückliefern der Daten als JSON-Zeichenkette...
            var res = p.FirstName;
        }

        public void DoVisit(Pet p)
        {
            
        }
    }
}