using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerData
    {


        [Key]
        [ForeignKey("PlayerId")]
        public string PlayerId { get; set; }
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public DateTime TimeStamp { get; set; }
        public EnumList.State CurrentState { get; set; }
        public bool HasFlag { get; set; }
        public int Azimuth { get; set; }
        public string AimingAgainst { get; set; }
        public EnumList.Signal GivenSignal { get; set; }
        public Player Player { get; set; }
        
        
    }
}