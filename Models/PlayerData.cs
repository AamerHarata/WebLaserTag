using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerData
    {
//        [Key]
//        public string MacAddress { get; set; }
        [Required]
        [Key]
        [ForeignKey("PlayerMacAddress")]
        public string PlayerMacAddress { get; set; }
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public DateTime TimeStamp { get; set; }
        public EnumList.State CurrentState { get; set; }
        public bool HasFlag { get; set; }
        public Player Player { get; set; }
        
        
    }
}