using System; 

namespace GoliathNationalBank
{
    public class DepositAccounts : Accounts, IDrowable 
    {
        //field
        private int depositeTime;

        //constructor
        public DepositAccounts(Customers client, decimal balance, decimal interest, int depositeTime)
            : base(client, balance, interest)
        {
            this.depositeTime = depositeTime;
        }
        
        //overridden methods
        public override void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public override void Drow(decimal money)
        {
            if (this.Balance > money)
            {
                this.Balance -= money;
            }
            else
            {
                throw new InvalidOperationException("You don't have so much money in the account");
            }
        }

        public override decimal CalculateInterest()
        {
            if (this.Balance <= 1000)
            {
                return 0;
            }
            else
            {
                return this.depositeTime * this.InterestRate;
            }
        }
    }
}
