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

            var flagPosition = RandomPointInCircle(startX, startY);
            
            var game = new Game
            {
                Host = player,
                Password = password,
                StartX = startX,
                StartY = startY,
                FlagX = flagPosition[0],
                FlagY = flagPosition[1],
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


            var playerInGame = new PlayerInGame{PlayerId = player.Id, Game = game, Player = player, JoinTime = DateTime.Now, Host = true};
            _context.Add(playerInGame);
            _context.SaveChanges();

            var playerData = _context.PlayersData.Include(x => x.Player).SingleOrDefault(x => x.PlayerId == player.Id);
            if (playerData == null)
            {
                playerData = new PlayerData {PlayerId = player.Id, Player = player, CurrentState = EnumList.State.START_ON_HOLD, TimeStamp = DateTime.Now, XGeo = startX, YGeo = startY};
                _context.Add(playerData);
                _context.SaveChanges();
            }
            else
            {
                playerData.CurrentState = EnumList.State.START_ON_HOLD;
                playerData.XGeo = startX;
                playerData.YGeo = startY;
                _context.Update(playerData);
                _context.SaveChanges();
            }
            
            
            return Ok(game);
        }

        [Route("api/SearchGames")]
        public IActionResult SearchGames()
        {
            var games = _context.Games.Include(x=>x.Host).Where(x => !x.Ended).OrderByDescending(x=>x.TimeStamp).ToList();
            if (games.Any())
                return Ok(games);
            return NotFound("No games -- You can start new one and invite your friends to play");
        }

        [Route("api/JoinGame")]
        public IActionResult JoinGame(string gameId, string playerId, string password)
        {
            var game = _context.Games.Include(x=>x.Host).SingleOrDefault(x=>x.Id == gameId);
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

            var playerJoin = new PlayerInGame {PlayerId = player.Id, Game = game, Player = player, JoinTime = DateTime.Now};
            
            _context.Add(playerJoin);
            _context.SaveChanges();


            var playerData = _context.PlayersData.Include(x => x.Player).SingleOrDefault(x => x.PlayerId == playerId);
            if (playerData == null)
            {
                playerData = new PlayerData {PlayerId = playerId, Player = player, CurrentState = EnumList.State.START_ON_HOLD, TimeStamp = DateTime.Now};
                _context.Add(playerData);
                _context.SaveChanges();
            }
            else
            {
                playerData.CurrentState = _context.PlayersData.Include(x => x.Player).SingleOrDefault(x => x.PlayerId == game.HostId)
                                              .CurrentState == EnumList.State.START_ON_HOLD ? EnumList.State.START_ON_HOLD : EnumList.State.AROUND;
                _context.Update(playerData);
                _context.SaveChanges();
            }
            
            
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
        public IActionResult AwaitPlayers(string gameId)
        {

            if (string.IsNullOrEmpty(gameId))
                return BadRequest("game Id is null");
            
            var game = _context.Games.Find(gameId);
            if (game == null)
                return NotFound("No games found");
            
            var signal = EnumList.Signal.WAIT.ToString();
                

            var playersInGame = _context.PlayersInGame.Include(x=>x.Player).Include(x => x.Game).Where(x => x.GameId == gameId).ToList();

            var host =_context.PlayersData.Find(playersInGame.SingleOrDefault(x => x.Host)?.PlayerId);
            if (host == null)
                return NotFound("Host not found");
            
            
            if(!playersInGame.Any())
                return NotFound("No players joined yet");

            var players = new List<Player>();
            foreach (var player in playersInGame)
            {
                players.Add(player.Player);
            }
            
            if(host.CurrentState != EnumList.State.START_ON_HOLD)
                signal = EnumList.Signal.IN.ToString();

            
            
            return  Ok(new {players, signal});
        }
        
        
        
        
        
        [Route("api/UpdatePlayerData/")]
        public IActionResult UpdatePlayerData(string gameId, string playerId, double xGeo, double yGeo, bool hasFlag, EnumList.State currentState, int azimuth, string aimingAgainst)
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
                    TimeStamp = DateTime.Now, PlayerId = playerId, Azimuth = azimuth, AimingAgainst = aimingAgainst
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
                playerData.Azimuth = azimuth;
                playerData.AimingAgainst = aimingAgainst;

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
                        YGeo = selectedPlayer.YGeo, CurrentState = selectedPlayer.CurrentState.ToString(), HasFlag = selectedPlayer.HasFlag,
                        GivenSignal = selectedPlayer.GivenSignal.ToString()
                    });
            }
                
            
           
            
            return Ok(new {players = players});
        }


        [Route("api/ExternalSignal")]
        public IActionResult ExternalSignal(string playerId, EnumList.Signal signal)
        {
            var player = _context.PlayersData.Include(x => x.Player).SingleOrDefault(x => x.PlayerId == playerId);
            if (player == null)
                return BadRequest("Player not found");
            player.GivenSignal = signal;
            _context.Update(player);
            _context.SaveChanges();
            return Ok();

        }

        private double[] RandomPointInCircle(double x0, double y0)
        {
            var rand = new Random();
            var radius = rand.NextDouble() * (0.0022 - 0.0006) + 0.0006;
            var x = rand.NextDouble() * ((x0 + radius) - (x0 - radius)) + (x0 - radius);

            var ys = GetYValue(x, x0, y0, radius);
            var randomIndex = new Random();
            var y = ys[randomIndex.Next(ys.Length)];
            
            //ToDo :: Change return value
            return new []{x, y};

        }

        private double[] GetYValue(double x, double x0, double y0, double r)
        {
            var pointOnRadius = Math.Sqrt(-(x - x0) * (x - x0) + r * r);
            return new double[]{pointOnRadius + y0, - pointOnRadius + y0};
        }


        [Route("api/TestValue/")]
        public IActionResult TestValue()
        {
            return Ok(new {Value = RandomPointInCircle(52, 6)});
        }
        
        
        
        
        
        
        
        
        
        
        
    }
}