using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Models
{
    public class UserBoardgameCollectionViewModel
    {
        public int UserDetailId { get; set; }
        public int BoardgameId { get; set; }
        public string BoardgameName { get; set; }
        public DateTime? DateAdded { get; set; }
        public short? MinPlayers { get; set; }
        public short? MaxPlayers { get; set; }
        public byte[] CoverImage { get; set; }
        public int PlayCount { get; set; }

    }
}
