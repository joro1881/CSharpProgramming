using System; 

namespace GoliathNationalBank
{
    public class Accounts : IDepositable
    {
        //field
        private Customers client;
        private decimal balance;
        private decimal interest_rate;
        private int number_of_months { get; set; }

        //constructor

        protected Accounts(Customers cliets, decimal balance, decimal interest_rate)
        {
            this.Client = client;
            this.Balance = balance;
            this.InterestRate = interest_rate;
        }

        //properties
        protected decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interest_rate; }
            set { this.interest_rate = value; }
        }

        public Customers Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        //methods
        public virtual void Deposit(decimal money)
        {
        }

        public virtual void Drow(decimal money)
        {
        }

        public virtual decimal CalculateInterest()
        {
            return number_of_months * this.InterestRate;
        }
    }
}
