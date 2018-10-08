using System;
using System.Collections.Generic;
using System.Text;
using BGCatalog.Models;

namespace BGCatalog.DataAccess.Interfaces
{
    public interface IBoardgameRepository
    {
        DatabaseSaveResult AddBoardgame(Boardgame boardgame);
        List<Boardgame> SearchBoardgames(string name, int? numberOfPlayers);

    }
}
