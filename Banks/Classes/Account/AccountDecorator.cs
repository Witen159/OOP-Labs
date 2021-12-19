namespace Banks.Classes.Account
{
    public abstract class AccountDecorator : AbstractAccount
    {
        // Уберем возможность для декораторов хранить другие декораторы,
        // так как счета не могут быть одновременно двух типов
        private Account _account;

        public AccountDecorator(Account account)
        {
            _account = account;
        }
    }
}