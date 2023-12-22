namespace Person
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var p = new Person() { FirstName = "Thomas" };
            p.Spouse = new Person() { FirstName = "Raja" };
            p.Spouse.Children.Add(new Person() { FirstName = "Anonymous" });

            IOpsVisitor visitor = new JsonSerializer();

            p.Accept(visitor);
        }
    }
}