using System.ComponentModel.DataAnnotations;

namespace WebLaserTag.Models
{
    public class Player
    {
        [Key]
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
        public string GameId { get; set; }
    }
}