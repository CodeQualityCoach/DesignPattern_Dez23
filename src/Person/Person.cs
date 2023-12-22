using System.Collections.Generic;

namespace Person
{
    /********************************************************
     * Aufgabe:
     * 
     * In welche Schnittstellen könnte man die Klasse "Person"
     * schneiden. Überlegt euch Schnittstellen im Sinne des
     * Interface Segregation Principle (ISP)
     ********************************************************/


    public class Person : IEntity, IPerson, IElement
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person Spouse { get; set; }
        public List<Person> Children { get; set; } = new List<Person>();

        public List<Pet> Pets { get; set; } = new List<Pet>();

        public void Accept(IOpsVisitor visitor)
        {
            visitor.DoVisit(this);

            this.Spouse?.Accept(visitor);

            foreach (var child in Children)
            {
                child.Accept(visitor);
            }

            foreach (var pet in Pets)
            {
                pet.Accept(visitor);
            }
        }
    }

    public interface IElement
    {
        void Accept(IOpsVisitor visitor);
    }

    public class Pet : IEntity, IElement 
    {
        public string Nickname { get; set; }

        public void Accept(IOpsVisitor visitor)
        {
            visitor.DoVisit(this);
        }

        public int Id { get; set; }
    }
}
