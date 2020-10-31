using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reborn
{
    public class getmatches
    {
        public Result result { get; set; }
    }
    public class Result
    {
        public List<Matcher> matches { get; set; }
    }
    public class Matcher
    {
        public string  match_id { get; set; }
    }

    public class infomatcher
    {
        public result result { get; set; }
    }
    public class result
    {
        public List<Player> players { get; set; }
        public string radiant_win { get; set; }
        public int duration { get; set; }
        public int start_time { get; set; }
        public int game_mode { get; set; }

    }
    public class Player
    {
        public string account_id { get; set; }
        public int player_slot { get; set; }
        public string hero_id { get; set; }
        public int leaver_status { get; set; }
    }

   

  


}