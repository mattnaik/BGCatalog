using BGCatalog.DataAccess.Interfaces;
using BGCatalog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BGCatalog.DataAccess.Concrete
{
    public class BoardgameRepository : IBoardgameRepository
    {
        public DatabaseSaveResult AddBoardgame(Boardgame boardgame)
        {
            throw new NotImplementedException();
        }

        public List<Boardgame> SearchBoardgames(string name, int? numberOfPlayers)
        {
            throw new NotImplementedException();
        }
    }
}
