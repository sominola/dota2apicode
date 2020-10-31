using System.Collections.Generic;

namespace Reborn
{
    public class github
    {
        public Mode[] Modes { get; set; }
        public Dictionary<string, Hero> heroes { get; set; }
        public Dictionary<string, Rank> ranks { get; set; }

    }
    public class Rank
    {
        public string source { get; set; }
    }
    public class Hero
    {
        public string name { get; set; }
        public long id { get; set; }
        public string localized_name { get; set; }
    }

    public class Mode
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}
