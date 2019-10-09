using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

        [Route("api/player/")]
        public IActionResult PlayersData(string name, double xGeo, double yGeo, bool hasFlag, EnumList.State currentState)
        {
            var playerData = new PlayerData()
                {Name = name, XGeo = xGeo, YGeo = yGeo, HasFlag = hasFlag, CurrentState = currentState, TimeStamp = DateTime.Now};

            _context.Add(playerData);
            _context.SaveChanges();
            var message = "Hello from the server, I got that from you: Name= "+name+", xGeo= "+xGeo+", yGeo= " + yGeo+ ", HasFlag?= " + hasFlag;
            
            var player1 = new PlayerData(){CurrentState = EnumList.State.DEAD, HasFlag = false, XGeo = 1.2444, YGeo = 2.555, Id = "PLAYER_NUMBER_1"};
            var player2 = new PlayerData(){CurrentState = EnumList.State.AROUND, HasFlag = false, XGeo = 3.5434, YGeo = 0.2342, Id = "PLAYER_NUMBER_2"};
            var player3 = new PlayerData(){CurrentState = EnumList.State.OUT_OF_MAP, HasFlag = true, XGeo = 8.215, YGeo = 7.3110, Id = "PLAYER_NUMBER_3"};

            var players = new List<PlayerData>() {player1, player2, player3};
            
            return Ok(players);
        }
    }
}