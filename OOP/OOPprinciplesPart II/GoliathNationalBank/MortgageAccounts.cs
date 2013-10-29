using System; 

namespace GoliathNationalBank
{
    public class MortgageAccounts : Accounts, IDepositable
    {
        //field
        private int mortgageTime;
        
        //constructor
        public MortgageAccounts(Customers client, decimal balance, decimal interest, int mortgageTime)
            : base(client, balance, interest)
        {
            this.mortgageTime = mortgageTime;
        }

        //overridden methods
        public override void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterest()
        {
            if (this.mortgageTime <= 12 && this.Client is Companies)
            {
                return (this.InterestRate / 2) * this.mortgageTime;
            }
            else if (this.mortgageTime <= 6 && this.Client is Individuals)
            {
                return 0;
            }
            else
            {
                return this.InterestRate * this.mortgageTime;
            }
        }
    }
}
