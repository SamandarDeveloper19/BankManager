using BankManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services
{
    internal class BankService : Account
    {
        public List<Customer> customers = new List<Customer>();

        private int customerNumber { get; set; } = 0;
        public void CreateAccount()
        {
            Console.Write("     Create an account!\nEnter your name: ");
            string name = Console.ReadLine();

            Random random = new Random();
            int id = random.Next();
            Console.WriteLine($"Save your ID: {id}");

            customers.Add(new Customer());
            customers[customerNumber].Name = name;
            customers[customerNumber].CustomerId = id;

            Console.Write("Enter your account number: ");
            string accountNumber = Console.ReadLine();
            customers[customerNumber].AccountNumber = accountNumber;
            customers[customerNumber].Balance = 0;

            Console.WriteLine($"You have successfully registered!");
            customerNumber++;
        }
        public void DeleteAccount()
        {
            Console.WriteLine("     Delete an account!");

            Console.Write("Enter your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool item = false;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerId == id)
                {
                    customers.RemoveAt(i);
                    Console.WriteLine("The account has been deleted!");
                    item = true;
                }
            }

            if (item == false)
            {
                Console.WriteLine("There is not this account in system!");
            }
        }
        public void TransferMoney()
        {
            Console.Write("Enter senderAccount: ");
            string senderAccount = Console.ReadLine();

            Console.Write("Enter receiverAccount: ");
            string receiverAccount = Console.ReadLine();

            Console.Write("Enter value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            bool item1 = false, item2 = false;
            int m = 0, n = 0;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].AccountNumber == senderAccount)
                {
                    m = i;
                    item1 = true;
                }
                if (customers[i].AccountNumber == receiverAccount)
                {
                    n = i;
                    item2 = true;
                }
            }

            if (item1 == true && item2 == true)
            {
                customers[m].Balance -= value;
                customers[n].Balance += value;
                Console.WriteLine("Money has been transferred successfully!");
            }
            else if (item1 == true && item2 == false)
            {
                Console.WriteLine("Money has not been transferred!\n" +
                    "Receiver account has not been found!");
            }
            else if (item1 == false && item2 == true)
            {
                Console.WriteLine("Money has not been transferred!\n" +
                    "Sender account has not been found!");
            }

        }
        public override void Deposit()
        {
            Console.Write("Enter your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int j = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerId == id)
                {
                    Console.Write("How much money do you want to deposit: ");
                    double money = Convert.ToDouble(Console.ReadLine());

                    customers[i].Balance += money;
                    Console.WriteLine("You have deposited!");
                }
                else
                    j++;
            }

            if (j == customers.Count)
                Console.WriteLine("There is not any account like that!");
        }
        public override void Withdraw()
        {
            Console.Write("Enter your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int j = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerId == id)
                {
                    Console.Write("How much money do you want to withdraw: ");
                    double money = Convert.ToDouble(Console.ReadLine());

                    if (customers[i].Balance >= money)
                    {
                        customers[i].Balance -= money;
                        Console.WriteLine("You have withdrawn!");
                    }
                    else
                    {
                        Console.WriteLine("There is not enough money!");
                    }
                }
                else
                    j++;
            }

            if (j == customers.Count)
                Console.WriteLine("There is not any account like that!");
        }
        public override void GetBalance()
        {
            Console.Write("Enter your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int j = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerId == id)
                {
                    Console.WriteLine($"Your balance: {customers[i].Balance.ToString()}");
                }
                else
                    j++;
            }

            if (j == customers.Count)
                Console.WriteLine("There is not any account like that!");
        }

        public void ExecuteAllFunctions()
        {
            Console.WriteLine("Welcome to our bank!");

            while (true)
            {
                Console.WriteLine("\n1. Create an account" +
                "\n2. Make a deposit" +
                "\n3. Withdraw money" +
                "\n4. Get balance" +
                "\n5. Transfer money" +
                "\n6. Delete an account");
                Console.Write("What kind of service do you want: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount(); break;
                    case 2:
                        Deposit(); break;
                    case 3:
                        Withdraw(); break;
                    case 4:
                        GetBalance(); break;
                    case 5:
                        TransferMoney(); break;
                    case 6:
                        DeleteAccount(); break;
                }

                Console.Write("Do you want to do something again [y / n] : ");
                string choice1 = Console.ReadLine();

                if (choice1 == "n")
                {
                    Console.WriteLine("Thank you for your visit!");
                    break;
                }
            }

        }
    }
}
