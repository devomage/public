namespace Magestorm.Legacy.Map
{
    [System.Serializable]
    public class TileBlock
    {
        public int index;
        public short top;
        public short bottom;

        public TileBlock(short top, short bottom, int index)
        {
            this.top = top;
            this.bottom = bottom;
            this.index = index;
        }

        public TileBlock()
        {

        }
    }
}