using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerDataViewModel
    {
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public EnumList.State CurrentState { get; set; }
        public bool HasFlag { get; set; }
        public EnumList.Signal GivenSignal { get; set; }
    }
}