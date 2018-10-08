using System;
using System.Collections.Generic;

namespace BGCatalog.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<BoardgameCollectionItem> BoardgameCollection { get; set; }

        public List<BoardgamePlay> BoardgamePlays { get; set; }

    }
}
