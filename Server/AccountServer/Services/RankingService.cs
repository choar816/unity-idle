using AccountDB;

namespace AccountServer.Services
{
    public class RankingService
    {
        AccountDbContext _dbContext;

        public RankingService(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateScore(string username, int score)
        {
            RankingDb? rankingDb = _dbContext.Rankings.FirstOrDefault(r => r.Username == username);
            if (rankingDb == null)
            {
                rankingDb = new RankingDb()
                {
                    Username = username
                };
            }

            if (rankingDb.Score > score)
                return true;

            rankingDb.Score = score;

            _dbContext.Rankings.Add(rankingDb);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
