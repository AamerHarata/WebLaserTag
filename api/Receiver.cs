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
        public IActionResult PlayersData(string id, double xGeo, double yGeo)
        {
            return Ok();
        }
    }
}