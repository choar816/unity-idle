using GameDB;

namespace WebServer.Services
{
    public class AccountService
    {
        GameDbContext _dbContext;

        public AccountService(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        int _idGenerator = 1;

        public int GenerateAccountId()
        {
            _idGenerator++;

            return _idGenerator;
        }
    }
}
