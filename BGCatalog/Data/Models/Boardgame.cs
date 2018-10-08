using System;
using System.Collections.Generic;

namespace BGCatalog.Web.Data.Models
{
    public partial class Boardgame
    {
        public Boardgame()
        {
            UserBoardgameCollections = new HashSet<UserBoardgameCollection>();
            UserBoardgamePlays = new HashSet<UserBoardgamePlay>();
        }

        public int BoardgameId { get; set; }
        public string Name { get; set; }
        public string Bggid { get; set; }
        public short? MinPlayTimeMinutes { get; set; }
        public short? MaxPlayTimeMinutes { get; set; }
        public short? MinPlayers { get; set; }
        public short? MaxPlayers { get; set; }
        public byte[] CoverImage { get; set; }

        public virtual ICollection<UserBoardgameCollection> UserBoardgameCollections { get; set; }
        public virtual ICollection<UserBoardgamePlay> UserBoardgamePlays { get; set; }
    }
}
