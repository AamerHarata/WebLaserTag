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
                return NotFound("Player not found, check host id");
            
            
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
                return NotFound("Game not found / wrong game Id");

            var player = _context.Players.Find(playerId);
            if (player == null)
                return NotFound("Player not found / wrong player Id");

            var playerInGame = _context.PlayersInGame.Include(x => x.Game).Include(x => x.Player)
                .Where(x => x.GameId == gameId).Any(x => x.PlayerId == playerId);
            if (playerInGame)
                return Ok("You are already in the game");
            
            if (password != game.Password)
                return BadRequest("Wrong password, try again!");

            var playerJoin = new PlayerInGame {Game = game, Player = player, JoinTime = DateTime.Now};
            var playerData = new PlayerData {PlayerId = playerId, Player = player, CurrentState = EnumList.State.NONE};
            
            _context.Add(playerJoin);
            _context.SaveChanges();

            _context.Add(playerData);
            _context.SaveChanges();
            
            return Ok("Game Joined -- you will be on hold while the other players join");
        }

        [Route("api/NewPlayer")]
        public IActionResult NewPlayer(string playerId, string name)
        {
            if (string.IsNullOrEmpty(playerId))
                return BadRequest("Player Id is null");
            var checkPlayer = _context.Players.Find(playerId);
            if (checkPlayer != null)
                return BadRequest("Player Id Already Exists!");

            var player = new Player {Id = playerId, Name = name};
            
            _context.Add(player);
            _context.SaveChanges();
            
            return Ok(player);
        }

        [Route("api/AwaitPlayers")]
        public IActionResult AwaitPlayers(string gameId, bool go)
        {

            if (string.IsNullOrEmpty(gameId))
                return BadRequest("game Id is null");
            
            var game = _context.Games.Find(gameId);
            if (game == null)
                return NotFound("No games found");
            
            var signal = EnumList.Signal.WAIT.ToString();
            if (go)
                signal = EnumList.Signal.IN.ToString();

            var playersInGame = _context.PlayersInGame.Include(x=>x.Player).Include(x => x.Game).Where(x => x.GameId == gameId).ToList();
            
            if(!playersInGame.Any())
                return NotFound("No players joined yet");

            var players = new List<Player>();
            foreach (var player in playersInGame)
            {
                players.Add(player.Player);
            }

            
            
            return  Ok(new {players, signal});
        }
        
        
        
        
        
        [Route("api/UpdatePlayerData/")]
        public IActionResult UpdatePlayerData(string gameId, string playerId, double xGeo, double yGeo, bool hasFlag, EnumList.State currentState)
        {
            if (playerId == null)
                return BadRequest("playerId Address is null");
            
            var player = _context.Players.Find(playerId);
            
            if (player == null)
                return NotFound("Player not found; or the playerId is wrong!");

            if (gameId == null)
                return BadRequest("GameId is null");
            var game = _context.Games.Find(gameId);
            
            if(game == null)
                return NotFound("Game is not found");

            var playerData = _context.PlayersData.Find(playerId);
            
            
            if (playerData == null)
            {
                playerData = new PlayerData
                {
                    Player = player, XGeo = xGeo, YGeo = yGeo, HasFlag = hasFlag, CurrentState = currentState,
                    TimeStamp = DateTime.Now,
                    PlayerId = playerId
                };
                
                _context.Add(playerData);
                _context.SaveChanges();
            }
            else
            {
                playerData.XGeo = xGeo;
                playerData.YGeo = yGeo;
                playerData.HasFlag = hasFlag;
                playerData.CurrentState = currentState;

                _context.Update(playerData);
                _context.SaveChanges();
            }

            

            var playersInTheGame = new List<string>();
            var players = new List<PlayerDataViewModel>();
            
            playersInTheGame.AddRange(from x in _context.PlayersInGame.ToList() where x.GameId == game.Id select x.PlayerId);

            foreach (var p in playersInTheGame)
            {
                var selectedPlayer = _context.PlayersData.Include(x=>x.Player).SingleOrDefault(x => x.PlayerId == p);
                if (selectedPlayer != null)
                    players.Add(new PlayerDataViewModel
                    {
                        Id = selectedPlayer.PlayerId, Name = selectedPlayer.Player.Name, XGeo = selectedPlayer.XGeo,
                        YGeo = selectedPlayer.YGeo, CurrentState = selectedPlayer.CurrentState, HasFlag = selectedPlayer.HasFlag,
                        GivenSignal = EnumList.Signal.NONE
                    });
            }
                
            
           
            
            return Ok(players);
        }
        
        
        
        
        
        
        
        
        
        
        
    }
}