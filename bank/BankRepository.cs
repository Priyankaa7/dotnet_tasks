using System.Collections;
using sbaccount;
using sbtransaction;

namespace bankRepo
{
    interface IBankRepository
    {
        void NewAccount(SBAccount acc);
        List<SBAccount> GetAllAccounts();
        SBAccount GetAccountDetails(int accno);
        void DepositAmount(int accno, decimal amt);
        void WithdrawAmount(int accno, decimal amt);
        List<SBTransaction> GetTransactions(int accno);
    }

    class BankRepository : IBankRepository
    {
        List<SBAccount> accounts;
        List<SBTransaction> transactions;
        public BankRepository()
        {
            accounts = new List<SBAccount>();
            transactions = new List<SBTransaction>();
        }

        public void NewAccount(SBAccount acc)
        {
            accounts.Add(acc);
        }

        public List<SBAccount> GetAllAccounts()
        {
            return accounts;
        }

        public SBAccount GetAccountDetails(int accno)
        {
            var account = accounts.Find(a => a.AccountNumber == accno);
            if (account == null)
            {
                System.Console.WriteLine("Account not found!");
            }
            return account;
        }

        public void DepositAmount(int accno, decimal amt)
        {
            var account = GetAccountDetails(accno);
            account.CurrentBalance += amt;

            var transaction = new SBTransaction
            {
                TransactionId = transactions.Count + 1,
                TransactionDate = DateTime.Now,
                AccountNumber = accno,
                Amount = amt,
                TransactionType = "Deposit"
            };
            transactions.Add(transaction);
        }

        public void WithdrawAmount(int accno, decimal amt)
        {
            var account = GetAccountDetails(accno);

            if (account.CurrentBalance < amt)
            {
                System.Console.WriteLine("Balance not sufficient!");
            }

            account.CurrentBalance -= amt;

            var transaction = new SBTransaction
            {
                TransactionId = transactions.Count + 1,
                TransactionDate = DateTime.Now,
                AccountNumber = accno,
                Amount = amt,
                TransactionType = "Withdrawal"
            };
            transactions.Add(transaction);
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            return transactions.FindAll(t => t.AccountNumber == accno);
        }        
    }
}