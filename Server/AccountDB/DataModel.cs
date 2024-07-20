using System.ComponentModel.DataAnnotations.Schema;

namespace AccountDB
{
    public enum ProviderType
    {
        None = 0,
        Guest = 1,
        Facebook = 2,
        Google = 3,
    }

    [Table("Account")]
    public class AccountDb
    {
        public int AccountDbId { get; set; } // PK
        public string LoginProviderUserId { get; set; } = string.Empty;
        public ProviderType LoginProviderType { get; set; }
        public string Username { get; set; } = string.Empty;
    }

    [Table("Ranking")]
    public class RankingDb
    {
        public int RankingDbId { get; set; } // PK
        //public int AccountDbId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}
