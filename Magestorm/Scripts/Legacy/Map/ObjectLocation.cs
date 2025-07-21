namespace Magestorm.Legacy.Map
{
    [System.Serializable]
    public class ObjectLocation
    {
        public int index;
        public int ObjectId;
        public int X;
        public int Y;

        /// <summary>
        /// Distance from the block or tile directly below
        /// </summary>
        public int Z;
    }
}