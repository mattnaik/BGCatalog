using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Models
{
    public class GamePlayModalViewModel
    {
        public string BoardgameName { get; set; }
        public int BoardgameId { get; set; }
        public IEnumerable<UserBoardgamePlayViewModel> BoardgamePlays { get; set; }
    }
}
