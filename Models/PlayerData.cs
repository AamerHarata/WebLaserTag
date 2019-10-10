using System;
using System.ComponentModel.DataAnnotations;
using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerData
    {
//        [Key]
//        public string MacAddress { get; set; }
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public DateTime TimeStamp { get; set; }
        public EnumList.State CurrentState { get; set; }
        public bool HasFlag { get; set; }
        public Player Player { get; set; }
        [Key]
        public string PlayerMacAddress { get; set; }
    }
}