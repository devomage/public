namespace Magestorm.Legacy
{
    [System.Serializable]
    public class Arena
    {
        public string name = "";
        public byte index;
        public byte MusicTrack;
        public bool enabled;
        public string description = "";
        public byte maxplayers;
        public ushort timelimit;
        public float expbonus;
        public TeamType[] teams = new TeamType[0];
        public string scenename = "";
        public MusicTrack music;
    }
    public enum MusicTrack
    {
        None, menu, chat, grid00, grid01, grid02, grid03
    }
}