using System.Collections.Generic;
using WebLaserTag.Models;

namespace WebLaserTag.Services
{
    public interface IPlayerService
    {
        List<PlayerData> GetPlayersInGame(string id);
    }
}