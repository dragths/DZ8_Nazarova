using System.Collections.Generic;
using System.IO;
using System;

namespace Тумаков
{
    public enum AccountType
    {
        Saving = 0, 
        Checking = 1 
    }

    internal class Program
    {
        static void task1()
        {
            /*9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
            методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
            конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
            для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
            банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
            счета.*/

            Console.WriteLine("Упражнение 9.1");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var accountTypeInput);
            AccountType accountType = (AccountType)accountTypeInput;

            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var initialBalance);
            BankChet myAccount = new BankChet(initialBalance, accountType);

            myAccount.PrintBankChet();

            Console.WriteLine("Теперь аккаунт откуда снимаются деньги");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var account2Input);
            AccountType account2Type = (AccountType)account2Input;

            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var account2Balance);
            BankChet account2 = new BankChet(account2Balance, account2Type);

            Console.WriteLine("Введите сумму для снятия");
            decimal.TryParse(Console.ReadLine(), out var amount);
            if (myAccount.Perevod(account2, amount))
            {
                Console.WriteLine("Перевод получился");
                myAccount.PrintBankChet();
                account2.PrintBankChet();
            }
            else
            {
                Console.WriteLine("Перевод не удался");
            }
        }
        static void task2()
        {
            /*Создать новый класс BankTransaction, который будет хранить информацию
            о всех банковских операциях. При изменении баланса счета создается новый объект класса
            BankTransaction, который содержит текущую дату и время, добавленную или снятую со
            счета сумму.*/
            Console.WriteLine("Упражнение 9.2");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var accountTypeInput);
            AccountType accountType = (AccountType)accountTypeInput;

            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var initialBalance);
            BankChet myAccount = new BankChet(initialBalance, accountType);

            myAccount.PrintBankChet();

            Console.WriteLine("Теперь аккаунт откуда снимаются деньги");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var account2Input);
            AccountType account2Type = (AccountType)account2Input;

            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var account2Balance);
            BankChet account2 = new BankChet(account2Balance, account2Type);

            Console.WriteLine("Введите сумму для перевода");
            decimal.TryParse(Console.ReadLine(), out var amount);
            if (myAccount.Perevod(account2, amount))
            {
                Console.WriteLine("Перевод прошел успешно");
                myAccount.PrintBankChet();
                account2.PrintBankChet();
            }
            else
            {
                Console.WriteLine("Перевод не удался");
            }

            
            Console.WriteLine("История транзакций для первого счета:");
            myAccount.PrintTransactions();
            Console.WriteLine("История транзакций для второго счета:");
            account2.PrintTransactions();
        }
        static void task3()
        {
            /*В классе банковский счет создать метод Dispose, который данные о
            проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
            GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
            завершения для указанного объекта.*/
            Console.WriteLine("Упражнение 9.3");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var accountTypeInput);
            AccountType accountType = (AccountType)accountTypeInput;

            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var initialBalance);
            using (BankChet myAccount = new BankChet(initialBalance, accountType))
            {
                myAccount.PrintBankChet();

                Console.WriteLine("Теперь аккаунт откуда снимаются деньги");
                Console.WriteLine("Выберите тип счета: ");
                Console.WriteLine("0 - Сберегательный");
                Console.WriteLine("1 - Расчетный");
                int.TryParse(Console.ReadLine(), out var account2Input);
                AccountType account2Type = (AccountType)account2Input;

                Console.Write("Введите начальный баланс: ");
                decimal.TryParse(Console.ReadLine(), out var account2Balance);
                using (BankChet account2 = new BankChet(account2Balance, account2Type))
                {
                    Console.WriteLine("Введите сумму для перевода:");
                    decimal.TryParse(Console.ReadLine(), out var amount);
                    if (myAccount.Perevod(account2, amount))
                    {
                        Console.WriteLine("Перевод прошел успешно");
                        myAccount.PrintBankChet();
                        account2.PrintBankChet();
                    }
                    else
                    {
                        Console.WriteLine("Перевод не удался");
                    }

                    Console.WriteLine("История транзакций для первого счета:");
                    myAccount.PrintTransactions();
                    Console.WriteLine("История транзакций для второго счета:");
                    account2.PrintTransactions();
                }
            }
        }
        

        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
        }
    }
}