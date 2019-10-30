using WebLaserTag.Services;

namespace WebLaserTag.Models
{
    public class PlayerDataViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public string CurrentState { get; set; }
        public bool HasFlag { get; set; }
        public string GivenSignal { get; set; }
    }
}