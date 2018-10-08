using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Models
{
    public class BoardgameViewModel
    {
        public int BoardgameId { get; set; }
        public string Name { get; set; }
        public string Bggid { get; set; }
        public short? MinPlayTimeMinutes { get; set; }
        public short? MaxPlayTimeMinutes { get; set; }
        public short? MinPlayers { get; set; }
        public short? MaxPlayers { get; set; }
        public byte[] CoverImage { get; set; }

        public virtual IEnumerable<UserBoardgameCollectionViewModel> UserBoardgameCollections { get; set; }
        public virtual IEnumerable<UserBoardgamePlayViewModel> UserBoardgamePlays { get; set; }
    }
}
