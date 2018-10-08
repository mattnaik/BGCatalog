using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGCatalog.Models;
using BGCatalog.Web.Data;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using BGCatalog.Web.Models;
using Microsoft.Extensions.Logging;

namespace BGCatalog.Controllers
{

    public class HomeController : Controller
    {
        UserService _userService;
        private readonly ILogger _logger;
        public HomeController(UserService userService,
            ILogger<HomeController> log)
        {
            _userService = userService;
            _logger = log;
        }
        [Authorize]
        public IActionResult Index(MainPageViewModel model)
        {
            string email = HttpContext.User.Identity.Name;
            model.UserBoardgameCollection = _userService.GetUsersBoardgames(email);
            return View(model);
        }

        public IActionResult SearchBGG(string search)
        {
            string url = string.Concat(@"https://www.boardgamegeek.com/xmlapi/search?search=", search);
            string jsonResult = string.Empty;
            using (var client = new HttpClient())
            { 
                var result = client.GetStreamAsync(url).Result;

                XmlDocument doc = new XmlDocument();
                doc.Load(result);
                _logger.LogDebug(doc.OuterXml);
                jsonResult = JsonConvert.SerializeXmlNode(doc);
            }
            return Json(JsonConvert.DeserializeObject(jsonResult));
        }

        public IActionResult AddGame(int SelectedGameId)
        {
            string url = string.Format(@"https://www.boardgamegeek.com/xmlapi/boardgame/{0}", SelectedGameId);
            string message = string.Empty;
            using (var client = new HttpClient())
            {
                var result = client.GetStreamAsync(url).Result;

                XmlDocument doc = new XmlDocument();
                doc.Load(result);

                message = _userService.AddBoardgameToCollectionXml(HttpContext.User.Identity.Name, doc);
            }

            return RedirectToAction("Index", new { message });
        }

        public IActionResult DeleteGameFromCollection(int gameid)
        {
            string email = HttpContext.User.Identity.Name;
            string message = _userService.DeleteGameFromCollection(email, gameid);
            return RedirectToAction("Index", new { message });
        }

        public IActionResult GamePlayModal(int gameid)
        {
            string email = HttpContext.User.Identity.Name;
            var model = _userService.GetBoardgamePlaysForGame(email, gameid);

            return PartialView("_GamePlayModal", model);
        }

        public IActionResult AddPlay(DateTime AddPlay, int gameid)
        {
            string email = HttpContext.User.Identity.Name;
            string message = _userService.AddPlay(email, AddPlay, gameid);
            return RedirectToAction("Index", new { message });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
