using System;

namespace Person
{
    /********************************************************
     * Aufgabe:
     * 
     * Factory Method implementieren
     * Business Rule: Geburtsdatum hinzufügen. Darf nicht in der Zukunft liegen
     ********************************************************/


    public class Person : IEntity, IPerson, IPersister, IToFormatEntity
    {
        public static IPerson Create(string firstname, string lastname, DateTime birthday, Func<int, Guid> factory)
        {
            if (birthday > DateTime.Now) throw new ArgumentException("Geburtstag muss in der Vergangenheit liegen");
            if (firstname is null || firstname.Length < 2) throw new ArgumentException("Bissel Kurz für einen Vornamen");
            if (lastname is null || lastname.Length < 2) throw new ArgumentException("Bissel Kurz für einen Nachnamen");

            return new Person(factory(12), firstname, lastname, birthday);
        }
        
        private Person(Guid uuid, string firstName, string lastName, DateTime birthday)
        {
            Uuid = uuid;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Guid Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; }

        public void Load(string path)
        {
            // Lesen der Daten aus der Datei...
        }

        public void Save(string path)
        {
            // Speichern der Daten in die Datei...
        }

        // statt der ToFormat Methoden wird hier ein IToFormatVisitor akzeptiert
        public void Accept(IToFormatVisitor visitor)
        {
            visitor.Visit(this); // this is the double dispatch
        }
    }
}
