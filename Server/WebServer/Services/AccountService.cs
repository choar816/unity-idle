namespace WebServer.Services
{
    public class AccountService
    {
        int _idGenerator = 1;

        public int GenerateAccountId()
        {
            _idGenerator++;

            return _idGenerator;
        }
    }
}
