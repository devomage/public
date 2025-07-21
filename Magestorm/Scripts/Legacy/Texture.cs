namespace Magestorm.Legacy
{
    [System.Serializable]
    public class Texture
    {
        public int index = -555;
        public string name = "";
        public int wbits = -555;
        public int hbits = -555;
        public int translucent = -555;
        public int sound = -555;
        public int timer = -555;
        public int numframes = -555;
        public string[] files;
        public int color_table = -555;

        //public List<Texture> textures = new List<Texture>();
        //public List<Sprite> sprites = new List<Sprite>();
    }
}