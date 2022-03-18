using System;

namespace ConsolingBank
{
    
    public class Account
    {
        private const double Rate = 0.035;

        private double _balance;

        public Account(string name, int accountNumber, double balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public int AccountNumber { get; }

        public string Name { get; }

        public double Balance
        {
            get { return _balance; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The balance can't be set to an amount less than 0.");  
                }
                _balance = value;
            }
        }

        public double Withdraw(double amount, double fee)
        {
            if (amount +fee < 0 || amount + fee > _balance)
            {
                throw new InvalidOperationException("Manage your account wisely so you don't overdraw.");
            }
            return Balance -= (amount + fee);
        }

        public double Deposit(double amount)
        {
            if ( amount < 0)
            {
                throw new InvalidOperationException("The amount can't be less than 0");
            }
            return Balance += amount;
        }

        public double AddInterest() => Balance *= (1 + Rate);

        public void DisplayAccount() => Console.WriteLine($"{AccountNumber}\t{Name}\t{_balance:c}");
    }
}