using System;
using System.Collections.Generic;

namespace WebLaserTag.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string HostName { get; set; }
        public int Password { get; set; }
        public bool Ended { get; set; }
        public DateTime TimeStamp { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double FlagX { get; set; }
        public double FlagY { get; set; }
        public string FlagHolder { get; set; }
    }
}