using System;
using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public DateTime TimeStamp { get; set; }
        public EnumList.State CurrentState { get; set; }
        public bool HasFlag { get; set; }
    }
}