namespace Magestorm.Legacy.Map.Trigger
{
    [System.Serializable]
    public class Trigger
    {
        public int index;
        public string type;

        /// <summary>
        /// Texture when trigger is OFF
        /// </summary>
        public int texture_off;

        /// <summary>
        /// Texture when trigger is ON
        /// </summary>
        public int texture_on;

        /// <summary>
        /// Time in msec to reset from ON to OFF automatically
        /// </summary>
        public int reset_timer;

        /// <summary>
        /// Trigger is Enabled
        /// </summary>
        public bool enabled;

        /// <summary>
        /// Initial state -> 0=OFF 1=ON
        /// </summary>
        public bool initial_state;

        /// <summary>
        /// Next trigger in chain
        /// </summary>
        public int next_trigger;
    }
}