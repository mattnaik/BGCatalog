using System;
using System.Collections.Generic;
using System.Text;

namespace BGCatalog.Models
{
    public class Boardgame
    {
        public int BoardgameId { get; set; }
        public string Name { get; set; }
        public string BGGID { get; set; }
        public int MinPlayTimeMinutes { get; set; }
        public int MaxPlayTimeMinutes { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public byte[] CoverImage { get; set; }

    }
}
