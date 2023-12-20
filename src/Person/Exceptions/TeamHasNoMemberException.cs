using System;

namespace Person.Builder
{
    internal class TeamHasNoMemberException : DomainException
    {
    }

    internal class DomainException : Exception
    {
    }
}