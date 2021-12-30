namespace Banks.Classes.Client
{
    public class ClientBuilder : IClientBuilder
    {
        private Client _client = new Client();

        public ClientBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._client = new Client();
        }

        public void BuildId(int id)
        {
            this._client.Id = id;
        }

        public void BuildName(string name)
        {
            this._client.Name = name;
        }

        public void BuildSurname(string surname)
        {
            this._client.Surname = surname;
        }

        public void BuildAddress(string address)
        {
            this._client.Address = address;
        }

        public void BuildPassport(int passportNumber)
        {
            this._client.PassportNumber = passportNumber;
        }

        public void BuildVerification()
        {
            this._client.Verification = (this._client.Address != null) && (this._client.PassportNumber != 0);
        }

        public Client GetClient()
        {
            Client result = this._client;

            return result;
        }
    }
}