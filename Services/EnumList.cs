namespace WebLaserTag.Services
{
    public class EnumList
    {
        public enum Signal
        {
            GET_SHOT, GIVE_SHOT, HAND_UP, HAND_DOWN, HAND_DEFENCE, GOT_FLAG, START_GAME ,RESTART_GAME, OUT, IN
        }
        
        public enum State
        {
            START_ON_HOLD, AROUND, AIMING, DEAD, DEFENCING, OUT_OF_MAP
        }
        
    }
}