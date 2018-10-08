using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Models
{
    public class MainPageViewModel
    {
        public string Message { get; set; }
        public IEnumerable<UserBoardgameCollectionViewModel> UserBoardgameCollection {get; set;}
    }
}
