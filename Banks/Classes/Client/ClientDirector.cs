namespace Banks.Classes.Client
{
    public class ClientDirector
    {
        private static int _clientId = 1;
        private IClientBuilder _builder;

        public IClientBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildDefaultClient(string name, string surname)
        {
            _builder.Reset();
            _builder.BuildName(name);
            _builder.BuildSurname(surname);
            _builder.BuildId(_clientId);
            _clientId++;
            _builder.BuildVerification();
        }

        public void BuildClientWithPassport(string name, string surname, int passportNumber)
        {
            _builder.Reset();
            _builder.BuildName(name);
            _builder.BuildSurname(surname);
            _builder.BuildPassport(passportNumber);
            _builder.BuildId(_clientId);
            _clientId++;
            _builder.BuildVerification();
        }

        public void BuildClientWithAddress(string name, string surname, string address)
        {
            _builder.Reset();
            _builder.BuildName(name);
            _builder.BuildSurname(surname);
            _builder.BuildAddress(address);
            _builder.BuildId(_clientId);
            _clientId++;
            _builder.BuildVerification();
        }

        public void BuildFullClient(string name, string surname, int passportNumber, string address)
        {
            _builder.Reset();
            _builder.BuildName(name);
            _builder.BuildSurname(surname);
            _builder.BuildPassport(passportNumber);
            _builder.BuildAddress(address);
            _builder.BuildId(_clientId);
            _clientId++;
            _builder.BuildVerification();
        }
    }
}