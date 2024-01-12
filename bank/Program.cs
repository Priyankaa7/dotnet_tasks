using sbaccount;
using sbtransaction;
using bankRepo;

class Program
{
    public static void Main()
    {
        IBankRepository bankRepo = new BankRepository();

        Console.WriteLine("1. Create New Account");
        Console.WriteLine("2. View All Accounts");
        Console.WriteLine("3. View Account Details");
        Console.WriteLine("4. Deposit Amount");
        Console.WriteLine("5. Withdraw Amount");
        Console.WriteLine("6. View Transactions");
        Console.WriteLine("0. Exit");

        while (true)
        {
            Console.Write("\nEnter your choice (0-6): ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        return;

                    case 1:
                        Console.Write("Enter Account Number: ");
                        int accNumber = int.Parse(Console.ReadLine());

                        Console.Write("Enter Customer Name: ");
                        string custName = Console.ReadLine();

                        Console.Write("Enter Customer Address: ");
                        string custAddress = Console.ReadLine();

                        Console.Write("Enter Current Balance: ");
                        decimal currBalance = decimal.Parse(Console.ReadLine());

                        SBAccount newAccount = new SBAccount
                        {
                            AccountNumber = accNumber,
                            CustomerName = custName,
                            CustomerAddress = custAddress,
                            CurrentBalance = currBalance,
                        };

                        bankRepo.NewAccount(newAccount);
                        Console.WriteLine("Account created successfully.");
                        break;

                    case 2:
                        Console.WriteLine("\nAll Accounts:");
                        foreach (var acc in bankRepo.GetAllAccounts())
                        {
                            Console.WriteLine(acc.ToString());
                        }
                        break;

                    case 3:
                        Console.Write("Enter Account Number: ");
                        int accNumberDetails = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine(bankRepo.GetAccountDetails(accNumberDetails).ToString());
                        break;

                    case 4:
                        Console.Write("Enter Account Number: ");
                        int accNumberDeposit = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount to Deposit: ");
                        decimal amountToDeposit = decimal.Parse(Console.ReadLine());
                        
                        bankRepo.DepositAmount(accNumberDeposit, amountToDeposit);
                        Console.WriteLine("Amount deposited successfully.");
                        break;

                    case 5:
                        Console.Write("Enter Account Number: ");
                        int accNumberWithdraw = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount to Withdraw: ");
                        decimal amountToWithdraw = decimal.Parse(Console.ReadLine());
                        
                        bankRepo.WithdrawAmount(accNumberWithdraw, amountToWithdraw);
                        Console.WriteLine("Amount withdrawn successfully.");
                        break;

                    case 6:
                        Console.Write("Enter Account Number: ");
                        int accNumberTransactions = int.Parse(Console.ReadLine());
                        var transactions = bankRepo.GetTransactions(accNumberTransactions);
                        Console.WriteLine("\nTransactions:");
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine(transaction.ToString());
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
