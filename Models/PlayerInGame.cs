using System;
using System.ComponentModel.DataAnnotations;
using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerInGame
    {
        public string PlayerId { get; set; }
        public Player Player { get; set; }
        public bool Host { get; set; }
        public string GameId { get; set; }
        public Game Game { get; set; }
        public DateTime JoinTime { get; set; }
    }
}