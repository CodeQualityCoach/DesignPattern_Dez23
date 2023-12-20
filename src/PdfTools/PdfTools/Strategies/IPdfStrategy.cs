namespace PdfTools.Strategies
{
    public interface IStrategy
    {
        void Start(string[] args);
    }

    interface IPdfStrategy : IStrategy
    {
    }

    interface IMarkdownStrategy : IStrategy
    {
    }

    class ConvertMarkdownStrategy : IMarkdownStrategy
    {
        public void Start(string[] args)
        {
            
        }
    }
}
