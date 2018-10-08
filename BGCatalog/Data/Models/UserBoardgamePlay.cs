using System;
using System.Collections.Generic;

namespace BGCatalog.Web.Data.Models
{
    public partial class UserBoardgamePlay
    {
        public int PlayId { get; set; }
        public int UserDetailId { get; set; }
        public int BoardgameId { get; set; }
        public DateTime DatePlayed { get; set; }

        public virtual Boardgame Boardgame { get; set; }
        public virtual UserDetails User { get; set; }
    }
}
