using BankManager.Services;

namespace BankManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankService bankService = new BankService();
            bankService.ExecuteAllFunctions();
        }
    }
}