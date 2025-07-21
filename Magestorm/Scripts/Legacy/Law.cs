namespace Magestorm.Legacy
{
    [System.Serializable]
    public class Law
    {
        public int index;
        public string name = "";
        public System.Collections.Generic.Dictionary<int, int> list = new System.Collections.Generic.Dictionary<int, int>();
    }
}