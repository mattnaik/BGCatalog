using System;
using System.Collections.Generic;
using System.Text;

namespace BGCatalog.Models
{
    public class BoardgameCollectionItem
    {
        public int UserId { get; set; }
        public Boardgame Boardgame { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
