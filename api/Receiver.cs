using System;
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
            return Ok(message);
        }
    }
}