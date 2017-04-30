using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesProject
{
    class Stats
    {
        public int Id { get; }
        public int Map { get; set; }
        public int Hero { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Kill { get; set; }
        public int Assist { get; set; }
        public int Death { get; set; }
        public string ReplayName { get; set; }
        public int Build { get; set; }
    }
}
