namespace Heranca_relacao.Entities
{
    sealed class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount() { }
        public SavingsAccount(int number, string holder, double balance, double interestRate) : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }

        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

        public sealed override void Withdraw(double amount)
        {
            // Balance -= amount; Caso não descontasse R$ 5

            // Caso desconte além do atual mais R$ 2
            base.Withdraw(amount);
            Balance -= 2;
        }
    }
}
