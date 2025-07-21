namespace Magestorm.Legacy.Map
{
    [System.Serializable]
    public class Texture
    {
        public int TextureId;
        public int Width;
        public int Height;
        public int Timer;
        public int SoundId;
        public int NumFrames;
        public int Transparency;
        public int Unknown_07;
        public int ColorTable;
        public int AnimationRandom;
        public int Unknown_10;
        public int Unknown_11;

        public string Identifier;
        public string Name00 = "";
        public string Name01 = "";
        public string Name02 = "";
        public string Name03 = "";

        public bool isAnimated
        {
            get
            {
                if (!string.IsNullOrEmpty(Name01)) return true;
                if (!string.IsNullOrEmpty(Name02)) return true;
                if (!string.IsNullOrEmpty(Name03)) return true;

                return false;
            }
        }
    }
}