using BGCatalog.DataAccess.Interfaces;
using BGCatalog.Models;
using BGCatalogDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BGCatalog.DataAccess.Concrete
{
    class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IDapperQueryWrapper _dapperQuery;

        public UserRepository(IDbConnectionFactory conn, IDapperQueryWrapper dapperQuery)
        {
            _dbConnectionFactory = conn;
            _dapperQuery = dapperQuery;
        }

        public DatabaseSaveResult AddBoardgamePlay(BoardgamePlay boardgamePlay)
        {
            throw new NotImplementedException();
        }

        public DatabaseSaveResult AddBoardgameToCollection(Boardgame game, User user)
        {
            throw new NotImplementedException();
        }

        public AuthenticateUserResponse AuthenticateUser(string username, string password)
        {
            //add password hash
            //check against users in the database
            //return response
            return new AuthenticateUserResponse();
        }

        public User GetUser(int UserId)
        {
            //get user from database
            return new User();
        }

        public User GetUser(string Username)
        {
            //get user from database
            return new User();
        }
    }
}
