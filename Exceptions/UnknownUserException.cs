using System;

namespace Play.Inventory.Exceptions
{
    internal class UnknownUserException : Exception
    {
        public Guid ItemId;

        public UnknownUserException(Guid userId) : base($"Unknown user '{userId}")
        {
            this.ItemId = userId;
        }
    }
}