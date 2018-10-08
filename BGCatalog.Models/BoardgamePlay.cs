using System;
using System.Collections.Generic;
using System.Text;

namespace BGCatalog.Models
{
    public class BoardgamePlay
    {
        public int PlayId { get; set; }
        public int UserId { get; set; }
        public int BoardgameId { get; set; }
        public DateTime DatePlayed { get; set; }

    }
}
