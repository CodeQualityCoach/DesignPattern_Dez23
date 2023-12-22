namespace Person
{
    public interface IToFormatEntity
    {
        void Accept(IToFormatVisitor visitor);
    }
}