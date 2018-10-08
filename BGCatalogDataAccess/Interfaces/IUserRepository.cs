using BGCatalog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BGCatalogDataAccess.Interfaces
{
    public interface IUserRepository
    {
        AuthenticateUserResponse AuthenticateUser(string username, string password);
        User GetUser(int UserId);
        User GetUser(string Username);
        DatabaseSaveResult AddBoardgameToCollection(Boardgame game, User user);
        DatabaseSaveResult AddBoardgamePlay(BoardgamePlay boardgamePlay);
    }
}
