using BGCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGCatalog.Web.Extensions;
using System.Xml;
using BGCatalog.Web.Data.Models;
using System.Net.Http;

namespace BGCatalog.Web.Data
{
    public class UserService
    {
        readonly BgCatalogContext _context;

        public UserService(BgCatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return _context.UserDetails.Select(x => new UserViewModel
            {
                UserDetailId = x.UserDetailId,
                UserName = x.UserName,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserBoardgameCollections = x.UserBoardgameCollections
                    .Select(ubc => new UserBoardgameCollectionViewModel
                    {
                        UserDetailId = ubc.UserDetailId,
                        BoardgameId = ubc.BoardgameId,
                        BoardgameName = ubc.Boardgame.Name,
                        DateAdded = ubc.DateAdded
                    }),
                UserBoardgamePlays = x.UserBoardgamePlays
                    .Select(ubp => new UserBoardgamePlayViewModel
                    {
                        PlayId = ubp.PlayId,
                        UserDetailId = ubp.UserDetailId,
                        BoardgameId = ubp.BoardgameId,
                        BoardgameName = ubp.Boardgame.Name,
                        DatePlayed = ubp.DatePlayed

                    })
            });
        }

        public IEnumerable<UserBoardgameCollectionViewModel> GetUsersBoardgames(string UserEmail)
        {

            var Plays = _context.UserBoardgamePlays.Where(x => x.User.Email == UserEmail).Select(x => x);
            var query2 = _context.UserBoardgameCollections.Where(x => x.User.Email == UserEmail);

            return query2.Select(x => new UserBoardgameCollectionViewModel
            {
                BoardgameId = x.Boardgame.BoardgameId,
                CoverImage = x.Boardgame.CoverImage,
                MaxPlayers = x.Boardgame.MaxPlayers,
                MinPlayers = x.Boardgame.MinPlayers,
                BoardgameName = x.Boardgame.Name,
                DateAdded = x.DateAdded,
                PlayCount = Plays.Where(p => p.BoardgameId == x.Boardgame.BoardgameId).Count()
            });
                
        }

        public string DeleteGameFromCollection(string UserEmail, int GameId)
        {
            UserDetails user = _context.UserDetails.Where(u => u.Email == UserEmail).FirstOrDefault();
            if (user == null)
            {
                return "Error: The email supplied is not a valid user";
            }
            var ubc = _context.UserBoardgameCollections.Where(x => x.BoardgameId == GameId && x.UserDetailId == user.UserDetailId).SingleOrDefault();
            _context.Remove(ubc);
            _context.SaveChanges();

            return "Successfully deleted this game from your collection";
        }

        internal string AddPlay(string email, DateTime addPlay, int gameid)
        {
            UserDetails user = _context.UserDetails.Where(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                return "Error: The email supplied is not a valid user";
            }

            var ubp = new UserBoardgamePlay
            {
                BoardgameId = gameid,
                UserDetailId = user.UserDetailId,
                DatePlayed = addPlay
            };

            _context.Add(ubp);
            _context.SaveChanges();

            return "Successfully added your game play";
    }

        public GamePlayModalViewModel GetBoardgamePlaysForGame(string email, int gameid)
        {
            GamePlayModalViewModel model = new GamePlayModalViewModel();
            UserDetails user = _context.UserDetails.Where(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                return model;
            }
            Boardgame game = _context.Boardgames.Where(x => x.BoardgameId == gameid).FirstOrDefault();
            if (game == null)
            {
                return model;
            }

            model.BoardgameName = game.Name;
            model.BoardgameId = game.BoardgameId;
            model.BoardgamePlays = _context.UserBoardgamePlays
                .Where(p => p.BoardgameId == game.BoardgameId && p.UserDetailId == user.UserDetailId)
                .Select(ubp => new UserBoardgamePlayViewModel {
                    BoardgameId = ubp.BoardgameId,
                    PlayId = ubp.PlayId,
                    BoardgameName = game.Name,
                    DatePlayed = ubp.DatePlayed,
                    UserDetailId = user.UserDetailId
                });

            return model;
        }

        public string AddBoardgameToCollectionXml(string UserEmail, XmlDocument doc)
        {
            UserDetails user = _context.UserDetails.Where(u => u.Email == UserEmail).FirstOrDefault();
            if(user == null)
            {
                return "Error: The email supplied is not a valid user";
            }
            string BggId = doc.SelectSingleNode("/boardgames/boardgame").Attributes["objectid"].Value;
            Boardgame game = _context.Boardgames.Where(x => x.Bggid == BggId).FirstOrDefault();
            if (game == null)
            {
                game = new Boardgame
                {
                    Bggid = BggId,
                    MaxPlayers = short.TryParse(doc.SelectSingleNode("/boardgames/boardgame/maxplayers").InnerText, out var maxvalue) ? maxvalue : (short)0,
                    MinPlayers = short.TryParse(doc.SelectSingleNode("/boardgames/boardgame/minplayers").InnerText, out var minvalue) ? minvalue : (short)0,
                    MaxPlayTimeMinutes = short.TryParse(doc.SelectSingleNode("/boardgames/boardgame/maxplaytime").InnerText, out var maxplayvalue) ? maxplayvalue : (short)0,
                    MinPlayTimeMinutes = short.TryParse(doc.SelectSingleNode("/boardgames/boardgame/minplaytime").InnerText, out var minplayvalue) ? minplayvalue : (short)0,
                    Name = doc.SelectSingleNode("/boardgames/boardgame/name[@primary='true']").InnerText,
                    CoverImage = DownloadImage(doc.SelectSingleNode("/boardgames/boardgame/thumbnail").InnerText)
                };

                _context.Add(game);
                _context.SaveChanges();
            }

            var ubc = _context.UserBoardgameCollections.Where(x => x.BoardgameId == game.BoardgameId && x.UserDetailId == user.UserDetailId).SingleOrDefault();

            if (ubc == null)
            { 
                var usergame = new UserBoardgameCollection
                {
                    BoardgameId = game.BoardgameId,
                    UserDetailId = user.UserDetailId,
                    DateAdded = DateTime.Now
                };
            

                _context.Add(usergame);
                _context.SaveChanges();

                return "Successfully added game to your collection";
            }
            else
            {
                return "This boardgame already belongs to your collection";
            }

        }

        private byte[] DownloadImage(string Url)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetByteArrayAsync(Url).Result;
                return result;
            }
        }
    }
}
