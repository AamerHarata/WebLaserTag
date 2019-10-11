using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLaserTag.Data;
using WebLaserTag.Models;

namespace WebLaserTag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult PlayerData(string gameId)
        {
            if (gameId == null)
                return BadRequest("Game Id is null");
            ViewBag.gameId = gameId;
            return View();
        }

        public IActionResult Players(string gameId)
        {
            if (gameId == null)
                return BadRequest("Game Id is null");
            ViewBag.gameId = gameId;
            return View();
        }

        


        [Route("/LivePlayerData/")]
        public IActionResult LivePlayerData(string gameId)
        {
            if (gameId == null)
                return BadRequest("Game Id is null");
            return PartialView("_LivePlayersData", _context.PlayersData.Include(x=>x.Player.Game).Where(x=>x.Player.GameId == gameId).OrderByDescending(x=>x.TimeStamp));
        }
        
        [Route("/LivePlayer/")]
        public IActionResult LivePlayer(string gameId)
        {
            if (gameId == null)
                return BadRequest("Game Id is null");
            return PartialView("_LivePlayer", _context.Players.Include(x=>x.Game).Where(x=>x.GameId == gameId).ToList());
        }
        
        
        [Route("/LiveGame/")]
        public IActionResult LiveGame()
        {
            return PartialView("_LiveGame", _context.Games.OrderByDescending(x=>x.TimeStamp).ToList());
        }


        public IActionResult DeleteGame(string gameId)
        {
            var game = _context.Games.Find(gameId);
            if (game == null)
                return BadRequest("Game not found");

            var players = _context.Players.Include(x => x.Game).Where(x => x.GameId == gameId).ToList();
            
            var playersData = new List<PlayerData>();
            foreach (var player in players)
            {
                playersData.Add(_context.PlayersData.Include(x=>x.Player).SingleOrDefault(x => x.PlayerMacAddress == player.MacAddress));
            }

            _context.Remove(game);
            _context.RemoveRange(players);
            _context.RemoveRange(playersData);
            _context.SaveChanges();
            

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult DeleteData()
        {
            _context.RemoveRange(_context.Games.ToList());
            _context.RemoveRange(_context.PlayersData.ToList());
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
