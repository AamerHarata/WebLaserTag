using System;
using System.Collections.Generic;

namespace WebLaserTag.Models
{
    public class Game
    {
        public string Id { get; set; }
        
        public string Name { get; set; } // ToDo :: Use this name to show instead of game id 
        public string Password { get; set; }
        public bool Ended { get; set; }
        public DateTime TimeStamp { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double FlagX { get; set; }
        public double FlagY { get; set; }
        public string FlagHolder { get; set; }
        
        public string HostId { get; set; }
        public Player Host { get; set; }
    }
}