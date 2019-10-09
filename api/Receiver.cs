using Microsoft.AspNetCore.Mvc;
using WebLaserTag.Data;

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
        public IActionResult PlayersData(string name, double xGeo, double yGeo, bool alive)
        {
            var message = "Hello from the server, I got that from you: Name= "+name+", xGeo= "+xGeo+", yGeo= " + yGeo+ ", alive?= " + alive;
            return Ok(message);
        }
    }
}