namespace Person
{
    public class ToXmlVisitor : IToFormatVisitor
    {
        public void Visit(Person person)
        {
            // --> Code aus der ehem. Person klasse
            // Zurückliefern der Daten als XML-Zeichenkette...
            var xmlString = "...";
        }

        public void Visit(Abteilung abteilung)
        {
            // todo, too lazy
        }
    }
}