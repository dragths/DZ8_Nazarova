using System;
using System.Collections.Generic;
using System.IO;

namespace Тумаков
{
    public class BankChet : IDisposable
    {
        private static int accountNumberCounter = 0;
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;

        
        private Queue<BankTransaction> transactions;

        private bool disposed = false;

        public BankChet()
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = AccountType.Saving; 
            this.transactions = new Queue<BankTransaction>();
        }

        public BankChet(AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = accountType;
            this.transactions = new Queue<BankTransaction>();
        }

        public BankChet(decimal balance)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.accountType = AccountType.Saving; 
            this.transactions = new Queue<BankTransaction>();
        }

        public BankChet(decimal balance, AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.accountType = accountType;
            this.transactions = new Queue<BankTransaction>();
        }

        private static string GenerateAccountNumber()
        {
            accountNumberCounter++;
            return "ACC" + accountNumberCounter.ToString("D6");
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств для снятия.");
                return false;
            }
            balance -= amount;
            transactions.Enqueue(new BankTransaction(-amount)); 
            Console.WriteLine($"Снято: {amount}. Остаток: {balance}");
            return true;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            transactions.Enqueue(new BankTransaction(amount)); 
            Console.WriteLine($"Внесено: {amount}. Новый баланс: {balance}");
        }

        public void PrintBankChet()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип банковского счета: {accountType}");
        }

        public bool Perevod(BankChet bankChet, decimal amount)
        {
            if (amount > balance || amount <= 0)
            {
                return false;
            }
            else
            {
                bankChet.balance += amount;
                balance -= amount;
                transactions.Enqueue(new BankTransaction(-amount)); 
                return true;
            }
        }

        public void PrintTransactions()
        {
            Console.WriteLine($"История транзакций для счета {accountNumber}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
            }
        }

        private void SaveTransactionsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"Номер счета: {accountNumber}, Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
                }
            }
            Console.WriteLine("Транзакции успешно записаны в файл.");
        }

   
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
              
                    SaveTransactionsToFile("transactions.txt"); 
                }
                disposed = true;
            }
        }
    }
}