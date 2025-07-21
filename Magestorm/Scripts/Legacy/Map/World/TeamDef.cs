namespace Magestorm.Legacy.Map.World
{
    using Magestorm.Legacy;

    [System.Serializable]
    public class TeamDef
    {
        public TeamType team;

        /// <summary>
        /// player start position
        /// </summary>
        public int startx;
        public int starty;

        /// <summary>
        /// player start rotation
        /// </summary>
        public int starta;

        /// <summary>
        /// player raise position
        /// </summary>
        public int raisex;
        public int raisey;

        /// <summary>
        /// player raise rotation
        /// </summary>
        public int raisea;
    }
}