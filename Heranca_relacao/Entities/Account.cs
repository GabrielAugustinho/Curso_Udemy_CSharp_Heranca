using Heranca_relacao.Entities.Exceptions;

namespace Heranca_relacao.Entities
{
    abstract class Account
    {
        public int Number { get; protected set; }
        public string Holder { get; protected set; }
        public double Balance { get; protected set; }
        public double WithDrawLimit { get; set; }

        public Account() { }

        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > WithDrawLimit)
            {
                throw new DomainException("Error on Withdraw: You have limit on withdraw.");
            }
            if (amount > Balance)
            {
                throw new DomainException("Error on Withdraw: Can not do withdraw lather than your balance.");
            }
            Balance -= amount + 5;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}
