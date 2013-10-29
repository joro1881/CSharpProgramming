using System; 

namespace GoliathNationalBank
{
    public class LoanAccounts : Accounts, IDepositable
    {
        //field
        private int loanTime;

        //constructor
        public LoanAccounts(Customers client, decimal balance, decimal interest, int loanTime)
            : base(client, balance, interest)
        {
            this.loanTime = loanTime;
        }

        //overridden methods
        public override void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterest()
        {
            if (this.loanTime <= 3 && Client is Individuals)
            {
                return 0;
            }
            else if (this.loanTime <= 2 && Client is Companies)
            {
                return 0;
            }
            else
            {
                return this.loanTime * this.InterestRate;
            }
        }
    }
}
