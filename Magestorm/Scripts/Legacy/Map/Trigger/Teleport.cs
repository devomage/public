namespace Magestorm.Legacy.Map.Trigger
{
    [System.Serializable]
    public class Teleport : Trigger
    {
        /// <summary>
        /// Random Teleporter -> Set to number of destinations
        /// </summary>
        public int random;

        /// <summary>
        /// Team Teleporter -> Destinations correspond to teams
        /// </summary>
        public int team;

        /// <summary>
        /// Locations of Teleport Destinations
        /// </summary>
        public int x0;
        public int y0;
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public int x3;
        public int y3;
        public int x4;
        public int y4;
        public int x5;
        public int y5;
        public int x6;
        public int y6;

        public int on_sound;
        public bool valhalla;
    }
}