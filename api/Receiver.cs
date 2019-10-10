using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLaserTag.Data;
using WebLaserTag.Models;
using WebLaserTag.Services;

namespace WebLaserTag.api
{
    [ApiController]
    public class Receiver : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Receiver(ApplicationDbContext context)
        {
            _context = context;
        }

        

        [Route("api/CreateGame/")]
        public IActionResult CreateGame(string macAddress, string playerName, double startX, double startY, int password)
        {
            var game = new Game
            {
                HostName = playerName,
                Password = password,
                StartX = startX,
                StartY = startY,
                FlagX = startX,
                FlagY = startY
            };
            

            //ToDo :: Use this code to delete the game once it's ended
//            var oldGames = _context.Games.Where(x=>x.Ended).ToList();
//            if (oldGames.Any())
//            {
//                foreach (var oldGame in oldGames)
//                {
//                    var oldPlayers = _context.Players.Include(x => x.Game).Where(x => x.Game == oldGame).ToList();
//                    foreach (var oldPlayer in oldPlayers)
//                    {
//                        _context.RemoveRange(_context.PlayersData.Include(x=>x.Player).Where(x=>x.Player == oldPlayer));
//                        _context.Remove(oldPlayer);
//                        _context.Remove(oldGame);
//                        _context.SaveChanges();
//                    }
//                }
//            }

            //ToDo :: Make it random inside the map range;
            //ToDo :: Make it random inside the map range;

            _context.Add(game);
            _context.SaveChanges();
            
            var player = new Player{MacAddress = macAddress, Name = playerName, Game = game};
            _context.Add(player);
            _context.SaveChanges();

            var response = "Game Created -- ";
            return Ok(new {response, game});
        }

        [Route("api/SearchGames")]
        public IActionResult SearchGames()
        {
            var games = _context.Games.Where(x => !x.Ended).ToList();
            if (games.Any())
                return Ok(games);
            return NotFound("No games -- You can start new one and invite your friends to play");
        }

        [Route("api/NewPlayer")]
        public IActionResult NewPlayer(string gameId, string macAddress, string playerName, int password, double xGeo, double yGeo)
        {
            var game = _context.Games.Find(gameId);
            if (game == null)
                return NotFound("Game not found");

            var players = _context.Players.Include(x => x.Game).ToList();
            if (players.Any(x => x.Game == game && x.MacAddress == macAddress))
                return Ok("You are already in the game");
            
            if (password != game.Password)
                return BadRequest("Wrong password, try again!");
            
            var player = new Player(){Game = game, MacAddress = macAddress, Name = playerName};
            var playerData = new PlayerData(){Player = player, XGeo = xGeo, YGeo = yGeo, CurrentState = EnumList.State.START_ON_HOLD};

            _context.Add(player);
            _context.SaveChanges();
            _context.Add(playerData);
            _context.SaveChanges();
            
            return Ok("Game Joined -- you will be on hold while the other players join");
        }

        [Route("api/AwaitPlayers")]
        public IActionResult AwaitPlayers(string gameId, bool go)
        {
            
            if (go)
            {
                
                return Ok(new {EnumList.Signal.IN});
            }

            var players = _context.Players.Include(x => x.Game).Where(x => x.GameId == gameId).ToList();
            var msg = "We are still waiting players, Now we have: "+players.Count+" players joined";
            
            
            if(!players.Any())
                return NotFound("No players joined yet");
            
            return  Ok(new {msg, players, EnumList.Signal.WAIT});
        }
        
        
        
        
        
        [Route("api/playerData/")]
        public IActionResult PlayersData(string gameId, string macAddress, double xGeo, double yGeo, bool hasFlag, EnumList.State currentState)
        {
            if (macAddress == null)
                return BadRequest("Mac Address is null");
            
            var player = _context.Players.Find(macAddress);
            
            if (player == null)
                return NotFound("Player not found; or the Mac Address is wrong!");
            
            if (gameId == null)
                return BadRequest("Mac Address is null");
            
            var game = _context.Games.Find(gameId);
            if (game == null)
                return NotFound("Game not found; Game Id is incorrect!");

            var playerData = _context.PlayersData.Find(macAddress);

            if (playerData == null)
            {
                var newPlayerData = new PlayerData{Player = player, XGeo = xGeo, YGeo = yGeo, HasFlag = hasFlag, CurrentState = currentState};
                _context.Add(newPlayerData);
                _context.SaveChanges();
                return Ok();
            }

            playerData.XGeo = xGeo;
            playerData.YGeo = yGeo;
            playerData.HasFlag = hasFlag;
            playerData.CurrentState = currentState;

            _context.Update(playerData);
            _context.SaveChanges();


            var playersData = _context.PlayersData.Include(x=>x.Player).Include(x=>x.Player.Game).Where(x=>x.Player.Game == game).ToList();
            
            var playersModel = new List<PlayerDataViewModel>();

            foreach (var data in playersData)
            {
                playersModel.Add(new PlayerDataViewModel{MacAddress = data.Player.MacAddress, Name = data.Player.Name, XGeo = data.XGeo, YGeo = data.YGeo, HasFlag = data.HasFlag,CurrentState = data.CurrentState, GivenSignal = EnumList.Signal.NONE});
            }
            
            return Ok(playersModel);
        }
        
        
        
        
        
        
        
        
        
        
        
    }
}