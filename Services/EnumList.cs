namespace WebLaserTag.Services
{
    public class EnumList
    {
        public enum Signal
        {
            NONE, GET_SHOT, GIVE_SHOT, HAND_UP, HAND_DOWN, HAND_DEFENCE, GOT_FLAG, START_GAME ,RESTART_GAME, OUT, IN, WAIT, MOVE_BACK
        }
        
        public enum State
        {
            START_ON_HOLD, AROUND, AIMING, DEAD, DEFENCING, OUT_OF_MAP, FIGHTING_ZONE
        }
        
    }
}