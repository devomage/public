namespace Magestorm.Legacy.Map.Trigger
{
    [System.Serializable]
    public class Remote : Trigger
    {
        /// <summary>
        /// 0=instantaneous 1=after duration
        /// </summary>
        public int next_trigger_timing;

        public string on_text;
        public string off_text;
    }
}