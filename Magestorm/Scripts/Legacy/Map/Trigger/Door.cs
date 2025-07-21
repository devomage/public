namespace Magestorm.Legacy.Map.Trigger
{
    [System.Serializable]
    public class Door : Trigger
    {
        /// <summary>
        /// 0=swing, 1=x-slide, 2=y-slide, 3=h-slide
        /// </summary>
        public int slide_axis;

        /// <summary>
        /// Start angle of Door in Degrees
        /// </summary>
        public int start_angle;

        /// <summary>
        /// End Angle of door in Degrees
        /// </summary>
        public int end_angle;

        /// <summary>
        /// Rate of door swing in Degrees/second
        /// </summary>
        public int max_angle_rate;


        public int on_sound;
        public int off_sound;

        /// <summary>
        /// Amount to slide in units
        /// </summary>
        public int slide_amount;

        /// <summary>
        /// Rate of slide in units/second
        /// </summary>
        public int max_rate;

        public string disabled_text = "";
    }
}