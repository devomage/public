namespace Magestorm.Legacy.Map
{
    [System.Serializable]
    public class Object
    {
        public int index;
        public int DefinitionId;
        public int imageid;
        public int unknown_03;
        public int unknown_04;
        public int image_timer;
        public int width;
        public int height;
        public int unknown_08;

        /// <summary>
        /// 1 = image is transparent
        /// </summary>
        public int Transparency;

        /// <summary>
        /// additional height
        /// </summary>
        public int Z;

        public int EffectSoundID;
        public int unused_01;
        public int unknown_12;
        public int LightingEffect;
        public int unknown_14;

        /// <summary>
        /// makes the object lighter or darker - 256 turn image #1 black - change this to 'brightness'
        /// </summary>
        public int Contrast;

        public int ObjectBrightness;
        public int SoundID;
        public int distance;
        public int unused_02;
        public int unused_03;
        public int unknown_19;
        public int flicker1;
        public int flicker2;
        public string Identifier = "";
    }
}