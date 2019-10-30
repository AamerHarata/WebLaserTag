using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using WebLaserTag.Data;
using WebLaserTag.Models;

namespace WebLaserTag.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<PlayerData> GetPlayersInGame(string gameId)
        {
            var playerIds = from x in _context.PlayersInGame.OrderByDescending(x=>x.JoinTime)
                where x.GameId == gameId
                select x.PlayerId;
            var playersInGameData = new List<PlayerData>();

            foreach (var id in playerIds)
                playersInGameData.Add(_context.PlayersData.Include(x=>x.Player).SingleOrDefault(x=>x.PlayerId == id));

            return playersInGameData;
        }
    }
}