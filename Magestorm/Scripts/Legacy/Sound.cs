namespace Magestorm.Legacy
{
    [System.Serializable]
    public class Sound
    {
        public static System.Collections.Generic.List<Sound> sounds = new System.Collections.Generic.List<Sound>();

        public int index;
        public string file = "";
        public int volume;

        //public static System.Collections.Generic.List<Magestorm.Legacy_Sound> Load(UnityEngine.TextAsset textasset)
        //{
        //    INIParser inifile = new INIParser();
        //    inifile.Open(textasset);
        //    inifile.Close();

        //    return Loader_Sounds(inifile);
        //}

        //private static System.Collections.Generic.List<Magestorm.Legacy_Sound> Loader_Sounds(INIParser inifile)
        //{
        //    sounds = new System.Collections.Generic.List<Magestorm.Legacy_Sound>();

        //    int numsounds = int.Parse(inifile.ReadValue("winsounds", "numsounds", "0"));

        //    for (int i = 0; i < numsounds; i++)
        //    {
        //        Magestorm.Legacy_Sound sound = new Magestorm.Legacy_Sound();

        //        string file = inifile.ReadValue(string.Format("winsound{0:00}", i), "file", "");
        //        string volume = inifile.ReadValue(string.Format("winsound{0:00}", i), "volume", "0");

        //        sound.index = i;
        //        sound.file = file;
        //        sound.volume = int.Parse(volume);

        //        sounds.Add(sound);
        //    }

        //    inifile.Close();

        //    return sounds;
        //}
    }
}