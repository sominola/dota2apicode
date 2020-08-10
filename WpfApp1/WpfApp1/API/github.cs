using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class github
    {
        public Mode[] Modes { get; set; }
        public Dictionary<string, Hero> heroes { get; set; }
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
