namespace Magestorm.Legacy
{
    [System.Serializable]
    public class Image
    {
        public int index;
        public string name = "";
        public int wbits;
        public int hbits;
        public int wpixels;
        public int hpixels;
        public int numviews;
        public bool system;
        public int numinseq;
        public int[] imageseq;
        public int[] viewimage;
        public int color_table;
        public bool mirror;
        public int numindeathseq;
        public int[] deathseq;

        public int width;
        public int height;

        public int cols;
        public int rows;
    }
}