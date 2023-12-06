using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Classes
{
    internal class Account
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        public virtual void Deposit()
        {
            Console.Write("How much money do you want to deposit: ");
            double money = Convert.ToDouble(Console.ReadLine());
            Balance += money;
            Console.WriteLine("You have deposited!");
        }
        public virtual void Withdraw()
        {
            Console.Write("How much money do you want to withdraw: ");
            double money = Convert.ToDouble(Console.ReadLine());

            if (Balance >= money)
            {
                Balance -= money;
                Console.WriteLine("You have withdrawn!");
            }
        }
        public virtual void GetBalance()
        {
            Console.WriteLine($"Your balance: {Balance.ToString()}");
        }
    }
}
