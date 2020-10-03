namespace Reborn
{
    public class infoprofile
    {
        public string tracked_until { get; set; }
        public string rank_tier { get; set; }
        public string solo_competitive_rank { get; set; }
        public string leaderboard_rank { get; set; }
        public Profile profile { get; set; }
    }
    public class Profile
    {
        public string personaname { get; set; }
        public string avatarfull { get; set; }
        public string avatarmedium { get; set; }
        public string avatar { get; set; }
        public string name { get; set; }
        public string loccountrycode { get; set; }
            
    }
}
