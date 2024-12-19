using System;

namespace Тумаков
{
    public class BankTransaction
    {
        public DateTime TransactionDate { get; }
        public decimal Amount { get; }

        public BankTransaction(decimal amount)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
        }
    }
}
