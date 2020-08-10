namespace WpfApp1
{
        public class infoprofile
        {
            public string tracked_until { get; set; }
            public string rank_tier { get; set; }
            public string leaderboard_rank { get; set; }
            public Profile profile { get; set; }
        }
        public class Profile
        {
            public string personaname { get; set; }
            public string avatarfull { get; set; }
            public string name { get; set; }
        }
}
