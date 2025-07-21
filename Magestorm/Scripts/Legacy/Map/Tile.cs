namespace Magestorm.Legacy.Map
{
    [System.Serializable]
    public class Tile
    {
        public int index;
        public System.Collections.Generic.List<TileBlock> TileBlocks = new System.Collections.Generic.List<TileBlock>();

        public int MaxHeight
        {
            get
            {
                int max = 0;

                foreach (TileBlock block in TileBlocks)
                {
                    if (block.top + block.bottom > max) max = block.top + block.bottom;
                }

                return max;
            }
        }

        public int HighestBottomClosestToCenter
        {
            get
            {
                short height = 500;

                #region smallest of the 4 center blocks - ring #1

                short bottom = 0;

                bottom = TileBlocks[28 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                bottom = TileBlocks[29 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                bottom = TileBlocks[36 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                bottom = TileBlocks[37 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                if (height != 500) return height;

                #endregion

                #region smallest of ring #2

                height = 500;

                bottom = TileBlocks[19 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[20 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[21 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[22 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[27 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                bottom = TileBlocks[30 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[35 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[38 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                bottom = TileBlocks[43 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[44 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[45 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;
                bottom = TileBlocks[46 - 1].bottom;
                if (bottom < height && bottom != 0) height = bottom;

                #endregion

                return height;
            }
        }
    }
}