using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class SystemOwner : Admin
    {
        public string OwnerID { get; set; } // Unique identifier for the system owner
        public string Name { get; set; } // System owner's full name
        public int MaxLoanMultiplier { get; set; } = 5; // e.g., 5 means max loan = 5 × total deposits


        // List<Account> is the collection of all accounts to loop through
        public void ViewAllAccounts(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.AccountNumber} {account.OwnerID} {account.AccountName}");
            }
       
        }

        public void ViewAllTranscations(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"{transaction.TransactionID} {transaction.SenderAccountNumber} {transaction.TargetAccountNumber} {transaction.Amount} {transaction.TransactionStatus}");
            }

        }

        // e.g., “max loan = 5× total deposits”
        public void SetLoanPolicy(int maxLoanMultiplier)
        {
            MaxLoanMultiplier = maxLoanMultiplier;
        }

        // Set or change that 15-minute wait
        public void SetTransferDelayPolicy()
        {
        }

    }
}
