using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BGCatalog.Web.Data.Models
{
    public partial class UserDetails 
    {
        public UserDetails()
        {
            UserBoardgameCollections = new HashSet<UserBoardgameCollection>();
            UserBoardgamePlays = new HashSet<UserBoardgamePlay>();
        }

        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserBoardgameCollection> UserBoardgameCollections { get; set; }
        public virtual ICollection<UserBoardgamePlay> UserBoardgamePlays { get; set; }
    }
}
