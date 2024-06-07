using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.LINQ
{
    internal class Program
    {
        class BankClient
        {
            public int AccountNumber { get; set; }
            public string Name { get; set; }
            public double Income { get; set; } //доход
            public double Expenses { get; set; } //расход
            public double TaxAmount => Income * 0.05; //налог
            public double Balance => Income - Expenses - TaxAmount;
        }
        static void Main(string[] args)
        {
            List<BankClient> clients = new List<BankClient>
        {
            new BankClient { AccountNumber = 1, Name = "John Doe", Income = 5000, Expenses = 3000 },
            new BankClient { AccountNumber = 2, Name = "Jane Smith", Income = 4000, Expenses = 4500 },
            new BankClient { AccountNumber = 3, Name = "Bob Johnson", Income = 6000, Expenses = 5500 },
            new BankClient { AccountNumber = 4, Name = "Emma Anderson", Income = 3000, Expenses = 2700 },
            new BankClient { AccountNumber = 5, Name = "Maks Brown", Income = 4500, Expenses = 4000 },
            new BankClient { AccountNumber = 6, Name = "Bob Wilson", Income = 6000, Expenses = 5500 },
            new BankClient { AccountNumber = 7, Name = "Emma Davis", Income = 5200, Expenses = 1000 },
            new BankClient { AccountNumber = 8, Name = "Olivia Taylo", Income = 1000, Expenses = 1200 },
            new BankClient { AccountNumber = 9, Name = "Bob Anderson", Income = 1500, Expenses = 200 },
        };

            // 1) Количество клиентов с отрицательным балансом
            var negative_balance = clients.Count(c => c.Balance < 0);
            Console.WriteLine("Количество клиентов с отрицательным балансом: " + negative_balance);
            Console.WriteLine();
            // 2) Клиент с самым большим балансом с учетом уплаты налогов
            var greater_balance = clients.OrderByDescending(c => c.Balance).First();
            Console.WriteLine("Клиент с самым большим балансом с учетом уплаты налогов: " + greater_balance.Name);
            Console.WriteLine();
            // 3) Средний доход по счетам с отрицательным балансом
            var average_negative_balance = clients.Where(c => c.Balance < 0).Average(c => c.Income);
            Console.WriteLine("Средний доход по счетам с отрицательным балансом: " + average_negative_balance);
            Console.WriteLine();
            // 4) Суммарная сумма налогов со всех клиентов
            var totalTaxAmount = clients.Sum(c => c.TaxAmount);
            Console.WriteLine("Суммарная сумма налогов со всех клиентов: " + totalTaxAmount);
        }
    }
}
