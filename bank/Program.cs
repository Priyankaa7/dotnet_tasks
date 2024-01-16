using sbaccount;
using sbtransaction;
using bankRepo;
using bank.Models;

class Program
{
    private static Ace52024Context db = new Ace52024Context();
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
                        AddAccount();
                        break;

                    case 2:
                        SelectData();
                        break;
                    
                    case 3:
                        Console.Write("Enter Account Number: ");
                        int accNum = int.Parse(Console.ReadLine());
                        try
                        {
                            Console.WriteLine(bankRepo.GetAccountDetails(accNum).ToString());
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Console.Write("Enter Account Number: ");
                        int accNumDepo = int.Parse(Console.ReadLine());

                        Console.Write("Enter Amount to Deposit: ");
                        decimal depoAmt = decimal.Parse(Console.ReadLine());

                        try
                        {
                            bankRepo.DepositAmount(accNumDepo, depoAmt);
                            Console.WriteLine("Amount deposited successfully.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        Console.Write("Enter Account Number: ");
                        int accNumWithdraw = int.Parse(Console.ReadLine());

                        Console.Write("Enter Amount to Withdraw: ");
                        decimal withdrawAmt = decimal.Parse(Console.ReadLine());

                        try
                        {
                            bankRepo.WithdrawAmount(accNumWithdraw, withdrawAmt);
                            Console.WriteLine("Amount withdrawn successfully.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        Console.Write("Enter Account Number: ");
                        int accNumTrans = int.Parse(Console.ReadLine());
                        var transactions = bankRepo.GetTransactions(accNumTrans);
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

    public static void AddAccount()
    {
        PriyankaSbaccount s = new PriyankaSbaccount();
        Console.Write("Enter Account Number: ");
        s.AccountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter Customer Name: ");
        s.CustomerName = Console.ReadLine();
        Console.Write("Enter Customer Address: ");
        s.CustomerAddress = Console.ReadLine();
        Console.Write("Enter Current Balance: ");
        s.CurrentBalance = decimal.Parse(Console.ReadLine());
        
        db.PriyankaSbaccounts.Add(s);
        db.SaveChanges();
        Console.WriteLine("Account created successfully.");
    } 
    public static void SelectData()
    {
        Console.WriteLine("\nAll Accounts:");
        foreach (var item in db.PriyankaSbaccounts)
        {
            //System.Console.WriteLine(item.ToString());
            System.Console.WriteLine(item.AccountNumber+" "+item.CustomerName+" "+item.CustomerAddress+" "+item.CurrentBalance);
        }
    }

}
