using System;

namespace Person
{
    public interface IUuidFactory
    {
        Guid CreateUuid();
    }

    class UuidFactory : IUuidFactory
    {
        public Guid CreateUuid()
        {
            return Guid.NewGuid();
        }
    }
}