using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLaserTag.Models
{
    public class Flag
    {
        [Key]
        [ForeignKey("PlayerId")]
        public string GameId { get; set; }
        
        public double XGeo { get; set; }
        public double YGeo { get; set; }
        public bool Free { get; set; }
        public string holderId { get; set; }
        
        public Game Game { get; set; }
    }
}