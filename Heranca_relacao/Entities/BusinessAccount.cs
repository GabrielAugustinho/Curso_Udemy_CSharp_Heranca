using Heranca_relacao.Entities.Exceptions;

namespace Heranca_relacao.Entities
{
    class BusinessAccount : Account
    {
        public double LoanLimit { get; set; }

        public BusinessAccount() { }

        public BusinessAccount(int number, string holder, double balance, double withDrawLimit, double loanLimit)
            : base(number, holder, balance, withDrawLimit)
        {
            LoanLimit = loanLimit;
        }

        public void Loan(double amount)
        {
            if (amount > LoanLimit)
            {
                throw new DomainException("Error on Withdraw: You have limit on loan.");
            }

            Balance += amount;
        }
    }
}
