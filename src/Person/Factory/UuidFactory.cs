using System;

namespace Person
{
    class UuidFactory : IUuidFactory
    {
        public Guid CreateUuid()
        {
            return Guid.NewGuid();
        }
    }
}