using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Models
{
    public class UserViewModel
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        //public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<UserBoardgameCollectionViewModel> UserBoardgameCollections { get; set; }
        public IEnumerable<UserBoardgamePlayViewModel> UserBoardgamePlays { get; set; }
    }
}
