using System;
using System.Globalization;
using System.Collections.Generic;
using Heranca_relacao.Entities;

namespace Heranca_relacao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Upcasting e Downcasting

            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            // UPCASTING

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "João", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Ana", 0.0, 0.01);

            // DOWNCASTING "Operaão insegura."

            // Casting --> (BusinessAccount)acc2 --> acc2 as BusinessAccount
            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.0);

            // Testar os tipos
            if (acc3 is BusinessAccount)
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                acc5.Loan(100.0);
                Console.WriteLine("Loan!");
            }
            else if (acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = acc3 as SavingsAccount;
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }




            // Sobreescrever

            Account acc7 = new SavingsAccount(1002, "Ana", 500.0, 0.01);

            //acc6.Withdraw(10.0);
            acc7.Withdraw(10.0);

            //Console.WriteLine(acc6.Balance);
            Console.WriteLine(acc7.Balance);




            // Classes Abstratas

            // Agora o account não pode ser instanciado pois é do tipo Abstract (polimorfismo e reuso)
            // Account acc6 = new Account(1001, "Alex", 500.0); 

            List<Account> list = new List<Account>();
            list.Add(new SavingsAccount(1001, "Alex", 500.0, 0.01));
            list.Add(new BusinessAccount(1002, "Maria", 500.0, 400.0));
            list.Add(new SavingsAccount(1003, "Bob", 500.0, 0.01));
            list.Add(new BusinessAccount(1002, "Anna", 500.0, 500.0));

            double sum = 0.0;

            foreach (Account acc in list)
            {
                sum += acc.Balance;
            }

            Console.WriteLine("Total Balance: " + sum.ToString("F2", CultureInfo.InvariantCulture));

            foreach (Account acc in list)
            {
                acc.Withdraw(10.0);
            }

            foreach (Account acc in list)
            {
                Console.WriteLine("Update balance for accont: "
                    + acc.Number
                    + ": "
                    + acc.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
