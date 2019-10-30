using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLaserTag.Data;
using WebLaserTag.Models;
using WebLaserTag.Services;

namespace WebLaserTag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlayerService _playerService;

        public HomeController(ApplicationDbContext context, IPlayerService playerService)
        {
            _context = context;
            _playerService = playerService;
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

        [Route("/livePlayerDataTest/")]
        public IActionResult LiveTest(string gameId)
        {
            return Ok(_playerService.GetPlayersInGame(gameId));
        }

        


        [Route("/LivePlayerData/")]
        public IActionResult LivePlayerData(string gameId)
        {
            if (gameId == null)
                return BadRequest("Game Id is null");

            var game = _context.Games.Find(gameId);
            if (game == null)
                return BadRequest("Game not found");

            var playersInGame = from x in _context.PlayersInGame.Include(x => x.Game).ToList()
                where x.GameId == gameId
                select x.PlayerId;

//            var allPlayersData = _context.PlayersData.Include(x => x.Player).ToList();
            
            var playerData = playersInGame.Select(playerId => _context.PlayersData.Include(x => x.Player).SingleOrDefault(x => x.PlayerId == playerId)).ToList();

//            foreach (var player in allPlayersData)
//                playerData.Add(player);

            return PartialView("_LivePlayersData", playerData);
        }
        
        [Route("/LivePlayer/")]
        public IActionResult LivePlayer(string gameId)
        {
            if (gameId == null)
                return BadRequest("Game Id is null");
            return PartialView("_LivePlayer", _context.PlayersInGame.Include(x=>x.Player).Where(x=>x.GameId == gameId).ToList());
        }
        
        
        [Route("/LiveGame/")]
        public IActionResult LiveGame()
        {
            return PartialView("_LiveGame", _context.Games.Include(x=>x.Host).OrderByDescending(x=>x.TimeStamp).ToList());
        }


        public IActionResult DeleteGame(string gameId)
        {
            var game = _context.Games.Find(gameId);
            if (game == null)
                return BadRequest("Game not found");

            var players = _context.PlayersInGame.Include(x => x.Game).Where(x => x.GameId == game.Id).ToList();
            
            _context.RemoveRange(players);
            _context.SaveChanges();
            _context.Remove(game);
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
