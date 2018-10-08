using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Models
{
    public class UserBoardgamePlayViewModel
    {
        public int PlayId { get; set; }
        public int UserDetailId { get; set; }
        public int BoardgameId { get; set; }
        public string BoardgameName { get; set; }
        public DateTime DatePlayed { get; set; }
    }
}
