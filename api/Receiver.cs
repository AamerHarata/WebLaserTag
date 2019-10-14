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
        public IActionResult CreateGame(string hostId, double startX, double startY, string password)
        {

            var player = _context.Players.Find(hostId);
            if (player == null)
                return NotFound("Player not found, check player id");
            
            
            var game = new Game
            {
                Host = player,
                Password = password,
                StartX = startX,
                StartY = startY,
                FlagX = startX,
                FlagY = startY,
                TimeStamp = DateTime.Now,
                FlagHolder = "None"
            };
            

            //ToDo :: Make it random inside the map range;
            //ToDo :: Make it random inside the map range;

            _context.Add(game);
            _context.SaveChanges();

            game.Name = player.Name + "-" + game.Id.Split("-")[0];
            _context.Update(game);
            _context.SaveChanges();


            _context.Add(new PlayerInGame {Game = game, Player = player, JoinTime = DateTime.Now, Host = true});
            _context.SaveChanges();

            return Ok(game);
        }

        [Route("api/SearchGames")]
        public IActionResult SearchGames()
        {
            var games = _context.Games.Include(x=>x.Host).Where(x => !x.Ended).ToList();
            if (games.Any())
                return Ok(games);
            return NotFound("No games -- You can start new one and invite your friends to play");
        }

        [Route("api/JoinGame")]
        public IActionResult JoinGame(string gameId, string playerId, string password)
        {
            var game = _context.Games.Find(gameId);
            if (game == null)
                return NotFound("Game not found");

            var player = _context.Players.Find(playerId);
            if (player == null)
                return NotFound("Player not found");

            var playerInGame = _context.PlayersInGame.Include(x => x.Game).Include(x => x.Player)
                .Where(x => x.GameId == gameId).Any(x => x.PlayerId == playerId);
            if (playerInGame)
                return Ok("You are already in the game");
            
            if (password != game.Password)
                return BadRequest("Wrong password, try again!");

            var playerJoin = new PlayerInGame {Game = game, Player = player, JoinTime = DateTime.Now};
            _context.Add(playerJoin);
            _context.SaveChanges();
            
            return Ok("Game Joined -- you will be on hold while the other players join");
        }

        [Route("api/NewPlayer")]
        public IActionResult NewPlayer(string playerId, string name)
        {
            var checkPlayer = _context.Players.Find(playerId);
            if (checkPlayer != null)
                return BadRequest("Player Id Already Exist!");

            var player = new Player {Id = playerId, Name = name};
            _context.Add(player);
            _context.SaveChanges();

            return Ok(player);
        }

        [Route("api/AwaitPlayers")]
        public IActionResult AwaitPlayers(string gameId, bool go)
        {
            
            if (go)
            {
                
                return Ok(new {EnumList.Signal.IN});
            }

            var playersInGame = _context.PlayersInGame.Include(x=>x.Player).Include(x => x.Game).Where(x => x.GameId == gameId).ToList();
            
            if(!playersInGame.Any())
                return NotFound("No players joined yet");

            var players = new List<Player>();
            foreach (var player in playersInGame)
            {
                players.Add(player.Player);
            }
            
            return  Ok(new {players, EnumList.Signal.WAIT});
        }
        
        
        
        
        
        [Route("api/playerData/")]
        public IActionResult PlayersData(string gameId, string playerId, double xGeo, double yGeo, bool hasFlag, EnumList.State currentState)
        {
            if (playerId == null)
                return BadRequest("playerId Address is null");
            
            var player = _context.Players.Find(playerId);
            
            if (player == null)
                return NotFound("Player not found; or the playerId is wrong!");
            
            if (gameId == null)
                return BadRequest("gameId is null");
            
            var game = _context.Games.Find(gameId);
            if (game == null)
                return NotFound("Game not found; Game Id is incorrect!");

            //ToDo :: A bug here, the player data become always null
            var playerData = _context.PlayersData.Find(playerId);
            
            //ToDo :: The same bug happened in the next line

            if (playerData == null)
            {
                var newPlayerData = new PlayerData{Player = player, XGeo = xGeo, YGeo = yGeo, HasFlag = hasFlag, CurrentState = currentState, TimeStamp = DateTime.Now};
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


//            var playersData = _context.PlayersData.Include(x=>x.Player).Include(x=>x.Player.Game).Where(x=>x.Player.Game == game).ToList();
            
            var playersModel = new List<PlayerDataViewModel>();

//            foreach (var data in playersData)
//            {
//                playersModel.Add(new PlayerDataViewModel{MacAddress = data.Player.Id, Name = data.Player.Name, XGeo = data.XGeo, YGeo = data.YGeo, HasFlag = data.HasFlag,CurrentState = data.CurrentState, GivenSignal = EnumList.Signal.NONE});
//            }
            
            return Ok(playersModel);
        }
        
        
        
        
        
        
        
        
        
        
        
    }
}