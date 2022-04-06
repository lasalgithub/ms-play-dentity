using System;

namespace Play.Inventory.Exceptions
{
    internal class InsufficientFundsException : Exception
    {
        public Guid ItemId;

        public decimal Cash;

        public InsufficientFundsException(Guid userId, decimal cash) : base($"Insufficient funds for '{userId}. Available balance: '{cash}'")
        {
            this.ItemId = userId;
        }
    }
}